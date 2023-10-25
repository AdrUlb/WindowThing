using RenderThing.Gl;
using RenderThing.Gl.Abstractions;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace RenderThing;

public sealed class GlRenderer : Renderer
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private readonly struct Vertex
	{
		public readonly Vector2 Position;
		public readonly Vector4 Color;
		public readonly Vector2 TexCoord;
		public readonly int TexIndex;

		public Vertex(Vector2 position, Vector4 color, Vector2 texCoord, int texIndex)
		{
			Position = position;
			Color = color;
			TexCoord = texCoord;
			TexIndex = texIndex;
		}

		public Vertex(Vector2 position, Color color, Vector2 texCoord, int texIndex)
		{
			Position = position;
			Color = ColorToVec4(color);
			TexCoord = texCoord;
			TexIndex = texIndex;
		}
	}

	private const string vertexShaderSource =
		"""
		#version 300 es
		precision mediump float;

		layout (location = 0) in vec2 aPos;
		layout (location = 1) in vec4 aColor;
		layout (location = 2) in vec2 aTexCoord;
		layout (location = 3) in int aTexIndex;

		out vec4 vColor;
		out vec2 vTexCoord;
		flat out int vTexIndex;

		uniform mat4 uProjection;

		void main()
		{
			vColor = aColor;
			vTexCoord = aTexCoord;
			vTexIndex = aTexIndex;
			gl_Position = uProjection * vec4(aPos, 0.0, 1.0);
		}
		""";

	private const string fragmentShaderSource =
		"""
		#version 300 es
		precision lowp float;

		in vec4 vColor;
		in vec2 vTexCoord;
		flat in int vTexIndex;

		out vec4 oColor;

		uniform sampler2D uTextures[$texturesPerBatch$];

		void main()
		{
			vec4 texColor;
		
			switch (vTexIndex)
			{
				case 0: texColor = vec4(1.0, 1.0, 1.0, 1.0); break;
				$texIndexCases$
			}
			
			oColor = texColor * vColor;
		}
		""";

	private const int verticesPerQuad = 4;
	private const int indicesPerQuad = 6;
	private const int maxQuadsPerBatch = 20_000;

	private readonly int maxTexturesPerBatch;

	private readonly ProgramObject spo;
	private readonly BufferObject vbo;
	private readonly BufferObject ebo;
	private readonly VertexArrayObject vao;

	private readonly Vertex[] vertices;

	private readonly Dictionary<Texture, uint> knownTextures = new();

	private readonly Texture[] batchTextures = new Texture[16];
	private readonly HashSet<Texture> dirtyTextures = new();
	private readonly HashSet<Texture> deletedTextures = new();

	private int batchTextureCount = 0;

	private int batchQuadCount = 0;

	private readonly IGlApi gl;

	public unsafe GlRenderer(IGlApi gl)
	{
		this.gl = gl;

		gl.Enable(Cap.Blend);
		gl.BlendFunc(BlendFactor.SrcAlpha, BlendFactor.OneMinusSrcAlpha);

		gl.GetIntegerv(IntegerParameterName.MaxTextureImageUnits, out maxTexturesPerBatch);

		var texIndexCases = new StringBuilder();

		for (var i = 0; i < maxTexturesPerBatch; i++)
			texIndexCases.Append("case ").Append(i + 1).Append(": texColor = texture(uTextures[").Append(i).Append("], vTexCoord); break;");

		var fragmentShaderSourceRep = new StringBuilder(fragmentShaderSource);
		fragmentShaderSourceRep.Replace("$texIndexCases$", texIndexCases.ToString());
		fragmentShaderSourceRep.Replace("$texturesPerBatch$", maxTexturesPerBatch.ToString());

		using (var vso = new ShaderObject(gl, ShaderType.Vertex, vertexShaderSource))
		using (var fso = new ShaderObject(gl, ShaderType.Fragment, fragmentShaderSourceRep.ToString()))
			spo = new(gl, vso, fso);

		vbo = new(gl);
		ebo = new(gl);
		vao = new(gl);

		Span<uint> indices = stackalloc uint[indicesPerQuad * maxQuadsPerBatch];

		for (var i = 0; i < maxQuadsPerBatch; i++)
		{
			var quadIndexOffset = i * indicesPerQuad;
			var quadVertexOffset = (uint)i * verticesPerQuad;
			indices[quadIndexOffset + 0] = quadVertexOffset + 0;
			indices[quadIndexOffset + 1] = quadVertexOffset + 1;
			indices[quadIndexOffset + 2] = quadVertexOffset + 3;
			indices[quadIndexOffset + 3] = quadVertexOffset + 1;
			indices[quadIndexOffset + 4] = quadVertexOffset + 2;
			indices[quadIndexOffset + 5] = quadVertexOffset + 3;
		}

		// Create vertex buffer
		gl.BindBuffer(BufferTarget.Array, vbo.Id);
		gl.BufferData(BufferTarget.Array, (nuint)sizeof(Vertex) * verticesPerQuad * maxQuadsPerBatch, 0, BufferUsage.StreamDraw);
		gl.BindBuffer(BufferTarget.Array, 0);

		// Create index buffer
		gl.BindBuffer(BufferTarget.ElementArray, ebo.Id);
		gl.BufferData<uint>(BufferTarget.ElementArray, indices, BufferUsage.StaticDraw);
		gl.BindBuffer(BufferTarget.ElementArray, 0);

		gl.BindVertexArray(vao.Id);

		// Describe vertex buffer layout
		gl.BindBuffer(BufferTarget.Array, vbo.Id);
		gl.VertexAttribPointer(0, 2, VertexAttribType.Float, false, (uint)sizeof(Vertex), 0);
		gl.VertexAttribPointer(1, 4, VertexAttribType.Float, false, (uint)sizeof(Vertex), 2 * sizeof(float));
		gl.VertexAttribPointer(2, 2, VertexAttribType.Float, false, (uint)sizeof(Vertex), 6 * sizeof(float));
		gl.VertexAttribIPointer(3, 1, VertexAttribType.Int, (uint)sizeof(Vertex), 8 * sizeof(float));
		gl.BindBuffer(BufferTarget.Array, 0);

		// Enable vertex attributes
		gl.EnableVertexAttribArray(0);
		gl.EnableVertexAttribArray(1);
		gl.EnableVertexAttribArray(2);
		gl.EnableVertexAttribArray(3);

		// Which element array to use when this VAO is bound
		gl.BindBuffer(BufferTarget.ElementArray, ebo.Id);

		gl.BindVertexArray(0);

		vertices = new Vertex[verticesPerQuad * maxQuadsPerBatch];
	}

	public override void SetSize(uint width, uint height)
	{
		gl.Viewport(0, 0, width, height);

		var projection = Matrix4x4.CreateOrthographicOffCenter(0.0f, width, height, 0.0f, -1.0f, 1.0f);
		var loc = spo.GetUniformLocation("uProjection");
		spo.UniformMatrix4(loc, 1, false, projection);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector4 ColorToVec4(Color color) => new(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);

	public void BatchCommit()
	{
		Span<int> textureUnits = stackalloc int[batchTextureCount];

		for (var i = 0; i < batchTextureCount; i++)
		{
			var texture = batchTextures[i];

			gl.ActiveTexture(Constants.GL_TEXTURE0 + (uint)i);
			gl.BindTexture(TextureTarget.Texture2D, knownTextures[texture]);

			if (dirtyTextures.Contains(texture))
			{
				dirtyTextures.Remove(texture);
				gl.TexSubImage2D<byte>(TextureTarget.Texture2D, 0, 0, 0, texture.Width, texture.Height, PixelFormat.Rgba, PixelType.UnsignedByte, texture.pixels);
			}

			textureUnits[i] = i;
		}

		var loc = spo.GetUniformLocation("uTextures");
		spo.Uniform1iv(loc, textureUnits);

		gl.BindBuffer(BufferTarget.Array, vbo.Id);
		gl.BufferSubData<Vertex>(BufferTarget.Array, 0, vertices);
		gl.BindBuffer(BufferTarget.Array, 0);

		spo.Use();

		gl.BindVertexArray(vao.Id);
		gl.DrawElements(DrawMode.Triangles, (uint)batchQuadCount * indicesPerQuad, IndexType.UnsignedInt, 0);
		gl.BindVertexArray(0);
		
		batchQuadCount = 0;
		batchTextureCount = 0;

		foreach (var tex in deletedTextures)
		{
			gl.DeleteTexture(knownTextures[tex]);
			knownTextures.Remove(tex);
			dirtyTextures.Remove(tex);
		}

		deletedTextures.Clear();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void BatchPushQuad(Vertex v1, Vertex v2, Vertex v3, Vertex v4)
	{
		if (batchQuadCount >= maxQuadsPerBatch)
			throw new UnreachableException("Exceeded batch quad limit.");

		var quadOffset = batchQuadCount * verticesPerQuad;
		vertices[quadOffset + 0] = v1;
		vertices[quadOffset + 1] = v2;
		vertices[quadOffset + 2] = v3;
		vertices[quadOffset + 3] = v4;
		batchQuadCount++;
	}

	private int BatchPushTexture(Texture texture)
	{
		for (var i = 0; i < batchTextureCount; i++)
		{
			if (batchTextures[i] == texture)
				return i;
		}

		if (batchTextureCount >= maxTexturesPerBatch)
			throw new UnreachableException("Exceeded batch texture limit.");

		var texId = batchTextureCount;
		batchTextures[batchTextureCount] = texture;
		batchTextureCount++;

		if (knownTextures.TryGetValue(texture, out var tex))
			return texId;

		tex = gl.GenTexture();
		knownTextures.Add(texture, tex);

		EventHandler onDisposing = null!;
		EventHandler onChanged = null!;

		onDisposing = (_, _) =>
		{
			texture.Disposing -= onDisposing;
			texture.Changed -= onChanged;
			deletedTextures.Add(texture);
		};

		onChanged = (_, _) => dirtyTextures.Add(texture);

		texture.Disposing += onDisposing;
		texture.Changed += onChanged;

		gl.BindTexture(TextureTarget.Texture2D, tex);

		gl.TexParameteri(TextureTarget.Texture2D, TextureParameter.WrapS, (int)TextureWrap.Repeat);
		gl.TexParameteri(TextureTarget.Texture2D, TextureParameter.WrapT, (int)TextureWrap.Repeat);
		gl.TexParameteri(TextureTarget.Texture2D, TextureParameter.MinFilter, (int)TextureMinFilter.Nearest);
		gl.TexParameteri(TextureTarget.Texture2D, TextureParameter.MagFilter, (int)TextureMagFilter.Linear);

		gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba, texture.Width, texture.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, 0);

		gl.GenerateMipmap(TextureTarget.Texture2D);

		dirtyTextures.Add(texture);

		return texId;
	}

	public override void FillRect(Vector2 position, Vector2 size, Color color)
	{
		if (batchQuadCount >= maxQuadsPerBatch)
			BatchCommit();

		BatchPushQuad(
			new(position, color, new(0.0f, 0.0f), 0),
			new(position + size with { Y = 0 }, color, new(1.0f, 0.0f), 0),
			new(position + size, color, new(1.0f, 1.0f), 0),
			new(position + size with { X = 0 }, color, new(0.0f, 1.0f), 0)
		);
	}

	public override void DrawTextureSection(Texture texture, Vector2 position, Vector2 size, Vector2 sectionPos, Vector2 sectionSize)
	{
		var left = sectionPos.X / texture.Width;
		var top = sectionPos.Y / texture.Height;
		var right = (sectionPos.X + sectionSize.X) / texture.Width;
		var bottom = (sectionPos.Y + sectionSize.Y) / texture.Height;
        
		if (batchQuadCount >= maxQuadsPerBatch || batchTextureCount >= maxTexturesPerBatch)
			BatchCommit();

		var texId = BatchPushTexture(texture);

		BatchPushQuad(
			new(position, Color.White, new(left, top), texId + 1),
			new(position + size with { Y = 0 }, Color.White, new(right, top), texId + 1),
			new(position + size, Color.White, new(right, bottom), texId + 1),
			new(position + size with { X = 0 }, Color.White, new(left, bottom), texId + 1)
		);
	}

	public override void Commit() => BatchCommit();

	public override void Clear(Color color)
	{
		var vec4 = ColorToVec4(color);

		gl.ClearColor(vec4.X, vec4.Y, vec4.Z, vec4.W);
		gl.Clear(ClearMask.ColorBuffer);
	}

	protected override void Dispose(bool disposing)
	{
		vao.Dispose();
		ebo.Dispose();
		vbo.Dispose();
		spo.Dispose();
	}

	~GlRenderer() => Dispose(false);
}
