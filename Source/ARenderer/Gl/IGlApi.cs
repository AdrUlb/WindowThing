using System.Numerics;

namespace ARenderer.Gl;

public interface IGlApi
{
	void Viewport(int x, int y, uint width, uint height);
	void ClearColor(float red, float green, float blue, float alpha);
	void Clear(ClearMask mask);
	void GenBuffers(Span<uint> buffers);
	uint GenBuffer();
	void DeleteBuffers(ReadOnlySpan<uint> buffers);
	void DeleteBuffer(uint buffer);
	void BindBuffer(BufferTarget target, uint buffer);
	void GenVertexArrays(Span<uint> arrays);
	uint GenVertexArray();
	void DeleteVertexArray(uint array);
	void BindVertexArray(uint array);
	void BufferData<T>(BufferTarget target, ReadOnlySpan<T> data, BufferUsage usage) where T : unmanaged;
	void BufferData(BufferTarget target, nuint size, nuint data, BufferUsage usage);
	void BufferSubData<T>(BufferTarget target, nint offset, ReadOnlySpan<T> data) where T : unmanaged;
	void VertexAttribPointer(uint index, int size, VertexAttribType type, bool normalized, uint stride, nuint pointer);
	void VertexAttribIPointer(uint index, int size, VertexAttribType type, uint stride, nuint pointer);
	void EnableVertexAttribArray(uint index);
	void DisableVertexAttribArray(uint index);
	void DrawArrays(DrawMode mode, int first, uint count);
	uint CreateShader(ShaderType shaderType);
	void DeleteShader(uint shader);
	void ShaderSource(uint shader, string source);
	void CompileShader(uint shader);
	int GetShaderiv(uint shader, ShaderParameterName pname);
	string GetShaderInfoLog(uint shader);
	uint CreateProgram();
	void DeleteProgram(uint program);
	void AttachShader(uint program, uint shader);
	void DetachShader(uint program, uint shader);
	void LinkProgram(uint program);
	int GetProgramiv(uint program, ProgramParameterName pname);
	string GetProgramInfoLog(uint program);
	void UseProgram(uint program);
	int GetUniformLocation(uint program, string name);
	void UniformMatrix4fv(int location, uint count, bool transpose, in Matrix4x4 value);
	void Uniform1iv(int location, ReadOnlySpan<int> value);
	void DrawElements<T>(DrawMode mode, uint count, IndexType type, Span<T> indices) where T : unmanaged;
	void DrawElements(DrawMode mode, uint count, IndexType type, nuint indices);
	void GenTextures(Span<uint> textures);
	uint GenTexture();
	void DeleteTextures(ReadOnlySpan<uint> textures);
	void DeleteTexture(uint texture);
	void BindTexture(TextureTarget target, uint texture);

	void TexImage2D<T>(TextureTarget target, int level, InternalFormat internalFormat, uint width, uint height, int border, PixelFormat format, PixelType type,
		ReadOnlySpan<T> data) where T : unmanaged;

	void TexImage2D(TextureTarget target, int level, InternalFormat internalFormat, uint width, uint height, int border, PixelFormat format, PixelType type,
		nuint data);

	void TexSubImage2D<T>(TextureTarget target, int level, int xoffset, int yoffset, uint width, uint height, PixelFormat format, PixelType type,
		ReadOnlySpan<T> data) where T : unmanaged;

	void GenerateMipmap(TextureTarget target);
	void TexParameteri(TextureTarget target, TextureParameter pname, int param);
	void ActiveTexture(uint texture);
	void GetIntegerv(IntegerParameterName pname, Span<int> data);
    void GetIntegerv(IntegerParameterName pname, out int data);
    string GetString(StringName name);
}
