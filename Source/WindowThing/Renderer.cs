using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WindowThing.Bindings.Gl;
using WindowThing.Bindings.Gl.Abstractions;

namespace WindowThing;

public sealed class Renderer : IDisposable
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct Vertex(Vector2 position, Vector4 color, Vector2 texCoord = new(), int texIndex = -1)
	{
		public Vector2 Position = position;
		public Vector4 Color = color;
		public Vector2 TexCoord = texCoord;
		public int TexIndex = texIndex;
	}

	private const string _vertexShaderSource =
		"""
		#version 330 core
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

	private const string _fragmentShaderSource =
		"""
		#version 330 core
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
				case -1: texColor = vec4(1.0, 1.0, 1.0, 1.0); break;
				$texIndexCases$
			}
			
			oColor = texColor * vColor;
		}
		""";

	private const int _verticesPerQuad = 4;
	private const int _indicesPerQuad = 6;
	private const int _maxQuadsPerBatch = 20_000;

	internal readonly Gl Gl;

	private readonly int _maxTexturesPerBatch;

	private readonly ProgramObject _spo;
	private readonly BufferObject _vbo;
	private readonly BufferObject _ebo;
	private readonly VertexArrayObject _vao;

	private readonly Vertex[] _batchVertices = new Vertex[_verticesPerQuad * _maxQuadsPerBatch];
	private int _batchQuadCount = 0;
	private int _batchTextureCount = 0;

	private readonly Texture[] _batchTextures;

	[ThreadStatic]
	internal static Gl? ThreadGl;

	internal unsafe Renderer(Gl gl)
	{
		if (ThreadGl != null)
			throw new UnreachableException();

		Gl = gl;
		ThreadGl = gl;

		// Get maximum number of textures that the shader can access at the same time
		Gl.GetIntegerv(IntegerParameterName.MaxTextureImageUnits, out _maxTexturesPerBatch);
		var texIndexCases = new StringBuilder();

		// sampler2D arrays may only be indexed using a constant according to the specification
		// generate a switch statement so that the shader may use a variable index
		for (var i = 0; i < _maxTexturesPerBatch; i++)
			texIndexCases.Append("case ").Append(i).Append(": texColor = texture(uTextures[").Append(i).Append("], vTexCoord); break;");
		var fragmentShaderSourceRep = new StringBuilder(_fragmentShaderSource);
		fragmentShaderSourceRep.Replace("$texIndexCases$", texIndexCases.ToString());
		fragmentShaderSourceRep.Replace("$texturesPerBatch$", _maxTexturesPerBatch.ToString());

		// Compile and link the shader program
		using (var vso = new ShaderObject(Gl, ShaderType.Vertex, _vertexShaderSource))
		using (var fso = new ShaderObject(Gl, ShaderType.Fragment, fragmentShaderSourceRep.ToString()))
			_spo = new(Gl, vso, fso);

		_vbo = new(Gl);
		_ebo = new(Gl);
		_vao = new(Gl);

		Gl.BindVertexArray(_vao);

		Gl.BindBuffer(BufferTarget.Array, _vbo);
		Gl.BufferData(BufferTarget.Array, (nuint)sizeof(Vertex) * _verticesPerQuad * _maxQuadsPerBatch, 0, BufferUsage.DynamicDraw);
		nuint offset = 0;
		Gl.VertexAttribPointer(0, 2, VertexAttribType.Float, false, (uint)sizeof(Vertex), offset);
		offset += (nuint)sizeof(Vector2);

		Gl.VertexAttribPointer(1, 4, VertexAttribType.Float, false, (uint)sizeof(Vertex), offset);
		offset += (nuint)sizeof(Vector4);

		Gl.VertexAttribPointer(2, 2, VertexAttribType.Float, false, (uint)sizeof(Vertex), offset);
		offset += (nuint)sizeof(Vector2);

		Gl.VertexAttribIPointer(3, 1, VertexAttribType.Int, (uint)sizeof(Vertex), offset);
		offset += sizeof(int);

		Gl.EnableVertexAttribArray(0);
		Gl.EnableVertexAttribArray(1);
		Gl.EnableVertexAttribArray(2);
		Gl.EnableVertexAttribArray(3);

		Gl.BindBuffer(BufferTarget.ElementArray, _ebo);
		var indices = new uint[_indicesPerQuad * _maxQuadsPerBatch];
		for (var i = 0; i < _maxQuadsPerBatch; i++)
		{
			indices[(i * _indicesPerQuad) + 0] = 0 + ((uint)i * _verticesPerQuad);
			indices[(i * _indicesPerQuad) + 1] = 1 + ((uint)i * _verticesPerQuad);
			indices[(i * _indicesPerQuad) + 2] = 2 + ((uint)i * _verticesPerQuad);
			indices[(i * _indicesPerQuad) + 3] = 0 + ((uint)i * _verticesPerQuad);
			indices[(i * _indicesPerQuad) + 4] = 2 + ((uint)i * _verticesPerQuad);
			indices[(i * _indicesPerQuad) + 5] = 3 + ((uint)i * _verticesPerQuad);
		}
		Gl.BufferData<uint>(BufferTarget.ElementArray, indices, BufferUsage.StaticDraw);

		Gl.BindVertexArray(0);

		Gl.Enable(Cap.Blend);
		Gl.BlendFunc(BlendFactor.SrcAlpha, BlendFactor.OneMinusSrcAlpha);

		_batchTextures = new Texture[_maxTexturesPerBatch];

		var loc = _spo.GetUniformLocation("uTextures");
		Span<int> textureIndices = new int[_maxTexturesPerBatch];
		for (var i = 0; i < textureIndices.Length; i++)
			textureIndices[i] = i;
		_spo.Uniform1Iv(loc, textureIndices);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector4 ColorToVec4(Color color) => new(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);

	internal void SetViewportSize(uint width, uint height)
	{
		Gl.Viewport(0, 0, width, height);

		var projection = Matrix4x4.CreateOrthographicOffCenter(0.0f, width, height, 0.0f, -1.0f, 1.0f);
		var loc = _spo.GetUniformLocation("uProjection");
		_spo.UniformMatrix4(loc, 1, false, projection);
	}

	public void Clear(Color color)
	{
		var colorVec = ColorToVec4(color);
		Gl.ClearColor(colorVec.X, colorVec.Y, colorVec.Z, colorVec.W);
		Gl.Clear(ClearMask.ColorBuffer);
	}

	private int GetBatchTextureIndex(Texture texture)
	{
		for (var i = 0; i < _batchTextureCount; i++)
			if (_batchTextures[i] == texture)
				return i;

		return -1;
	}

	private int BatchPushTexture(Texture texture)
	{
		if (_batchTextureCount == _maxTexturesPerBatch)
			throw new InvalidOperationException();

		_batchTextures[_batchTextureCount] = texture;

		return _batchTextureCount++;
	}

	private void BatchPushQuad(in Vertex v1, in Vertex v2, in Vertex v3, in Vertex v4)
	{
		if (_batchQuadCount == _maxQuadsPerBatch)
			throw new InvalidOperationException();

		_batchVertices[(_batchQuadCount * _verticesPerQuad) + 0] = v1;
		_batchVertices[(_batchQuadCount * _verticesPerQuad) + 1] = v2;
		_batchVertices[(_batchQuadCount * _verticesPerQuad) + 2] = v3;
		_batchVertices[(_batchQuadCount * _verticesPerQuad) + 3] = v4;
		_batchQuadCount++;
	}

	public void FillRect(Vector2 position, Vector2 size, Color color)
	{
		if (_batchQuadCount == _maxQuadsPerBatch)
			Commit();

		BatchPushQuad(
			new(new(position.X, position.Y), ColorToVec4(color)),
			new(new(position.X, position.Y + size.Y), ColorToVec4(color)),
			new(new(position.X + size.X, position.Y + size.Y), ColorToVec4(color)),
			new(new(position.X + size.X, position.Y), ColorToVec4(color))
		);
	}

	public void DrawTextureSection(Texture texture, Vector2 sectionOffset, Vector2 sectionSize, Vector2 position, Vector2 size, Color tint)
	{
		if (_batchQuadCount == _maxQuadsPerBatch)
			Commit();

		var texIndex = GetBatchTextureIndex(texture);

		if (texIndex == -1)
		{
			if (_batchTextureCount == _maxTexturesPerBatch)
				Commit();

			texIndex = BatchPushTexture(texture);
		}

		// One step moved to just before rendering: dividing by the texture size. This is to make sure texture
		// coordinates are correctly calculated for textures that were modified before the frame finished rendering
		var texTopLeft = sectionOffset;
		var texTopRight = sectionOffset + sectionSize with { Y = 0 };
		var texBottomLeft = sectionOffset + sectionSize with { X = 0 };
		var texBottomRight = sectionOffset + sectionSize;

		BatchPushQuad(
			new(new(position.X, position.Y), ColorToVec4(tint), texTopLeft, texIndex),
			new(new(position.X, position.Y + size.Y), ColorToVec4(tint), texBottomLeft, texIndex),
			new(new(position.X + size.X, position.Y + size.Y), ColorToVec4(tint), texBottomRight, texIndex),
			new(new(position.X + size.X, position.Y), ColorToVec4(tint), texTopRight, texIndex)
		);
	}

	public void DrawTexture(Texture texture, Vector2 position, Vector2 size, Color tint) =>
		DrawTextureSection(texture, new(0, 0), new(texture.Width, texture.Height), position, size, tint);

	public void DrawText(string text, Font font, Vector2 position, Color color)
	{
		var pos = position;

		foreach (var c in text)
		{
			if (c == '\n')
			{
				pos.Y += font.Size;
				pos.X = position.X;
				continue;
			}

			var fontChar = font.GetChar(c);

			var visiblePos = pos + (fontChar.DrawOffset with { Y = font.Size - fontChar.DrawOffset.Y });
			DrawTextureSection(font.Texture, fontChar.SectionOffset, fontChar.Size, visiblePos, fontChar.Size, color);

			pos += fontChar.Advance;
		}
	}

	internal void Commit()
	{
		// Finish calculating texcoords
		for (var i = 0; i < _batchQuadCount * _verticesPerQuad; i++)
		{
			if (_batchVertices[i].TexIndex < 0)
				continue;

			var texture = _batchTextures[_batchVertices[i].TexIndex];
			var texSize = new Vector2(texture.Width, texture.Height);
			_batchVertices[i].TexCoord /= texSize;
		}

		for (var i = 0u; i < _batchTextureCount; i++)
		{
			Gl.ActiveTexture(Constants._glTexture0 + i);
			Gl.BindTexture(TextureTarget.Texture2D, _batchTextures[i].Id);
			_batchTextures[i].CommitGlTexture();
		}

		Gl.BindBuffer(BufferTarget.Array, _vbo);
		Gl.BufferSubData<Vertex>(BufferTarget.Array, 0, _batchVertices.AsSpan()[0..(_batchQuadCount * _verticesPerQuad)]);

		_spo.Use();

		Gl.BindVertexArray(_vao);
		Gl.DrawElements(DrawMode.Triangles, (uint)(_batchQuadCount * _indicesPerQuad), IndexType.UnsignedInt, 0);
		Gl.BindVertexArray(0);

		_batchQuadCount = 0;
		_batchTextureCount = 0;
	}

	private void Dispose(bool disposing)
	{
		ThreadGl = null;
		_vao.Dispose();
		_ebo.Dispose();
		_vbo.Dispose();
		_spo.Dispose();
	}

	~Renderer() => Dispose(false);

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		Dispose(true);
	}
}
