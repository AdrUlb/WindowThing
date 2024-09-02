using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowThing.Bindings.Gl;

public unsafe class DesktopGl(DesktopGl.ProcGetProcAddress procGetProcAddress) : Gl
{
	public delegate nint ProcGetProcAddress(string proc);


	private readonly delegate* unmanaged<int, int, uint, uint, void> _glViewport = (delegate* unmanaged<int, int, uint, uint, void>)procGetProcAddress("glViewport");
	private readonly delegate* unmanaged<ClearMask, void> _glClear = (delegate* unmanaged<ClearMask, void>)procGetProcAddress("glClear");
	private readonly delegate* unmanaged<float, float, float, float, void> _glClearColor = (delegate* unmanaged<float, float, float, float, void>)procGetProcAddress("glClearColor");
	private readonly delegate* unmanaged<uint, uint*, void> _glGenBuffers = (delegate* unmanaged<uint, uint*, void>)procGetProcAddress("glGenBuffers");
	private readonly delegate* unmanaged<uint, uint*, void> _glDeleteBuffers = (delegate* unmanaged<uint, uint*, void>)procGetProcAddress("glDeleteBuffers");
	private readonly delegate* unmanaged<BufferTarget, uint, void> _glBindBuffer = (delegate* unmanaged<BufferTarget, uint, void>)procGetProcAddress("glBindBuffer");
	private readonly delegate* unmanaged<uint, uint*, void> _glGenVertexArrays = (delegate* unmanaged<uint, uint*, void>)procGetProcAddress("glGenVertexArrays");
	private readonly delegate* unmanaged<uint, uint*, void> _glDeleteVertexArrays = (delegate* unmanaged<uint, uint*, void>)procGetProcAddress("glDeleteVertexArrays");
	private readonly delegate* unmanaged<uint, void> _glBindVertexArray = (delegate* unmanaged<uint, void>)procGetProcAddress("glBindVertexArray");
	private readonly delegate* unmanaged<BufferTarget, nuint, void*, BufferUsage, void> _glBufferData = (delegate* unmanaged<BufferTarget, nuint, void*, BufferUsage, void>)procGetProcAddress("glBufferData");
	private readonly delegate* unmanaged<BufferTarget, nint, nuint, void*, void> _glBufferSubData = (delegate* unmanaged<BufferTarget, nint, nuint, void*, void>)procGetProcAddress("glBufferSubData");
	private readonly delegate* unmanaged<uint, int, VertexAttribType, bool, uint, nuint, void> _glVertexAttribPointer =
		(delegate* unmanaged<uint, int, VertexAttribType, bool, uint, nuint, void>)procGetProcAddress("glVertexAttribPointer");
	private readonly delegate* unmanaged<uint, void> _glEnableVertexAttribArray = (delegate* unmanaged<uint, void>)procGetProcAddress("glEnableVertexAttribArray");
	private readonly delegate* unmanaged<uint, void> _glDisableVertexAttribArray = (delegate* unmanaged<uint, void>)procGetProcAddress("glDisableVertexAttribArray");
	private readonly delegate* unmanaged<DrawMode, int, uint, void> _glDrawArrays = (delegate* unmanaged<DrawMode, int, uint, void>)procGetProcAddress("glDrawArrays");
	private readonly delegate* unmanaged<ShaderType, uint> _glCreateShader = (delegate* unmanaged<ShaderType, uint>)procGetProcAddress("glCreateShader");
	private readonly delegate* unmanaged<uint, void> _glDeleteShader = (delegate* unmanaged<uint, void>)procGetProcAddress("glDeleteShader");
	private readonly delegate* unmanaged<uint, uint, byte**, int*, void> _glShaderSource = (delegate* unmanaged<uint, uint, byte**, int*, void>)procGetProcAddress("glShaderSource");
	private readonly delegate* unmanaged<uint, void> _glCompileShader = (delegate* unmanaged<uint, void>)procGetProcAddress("glCompileShader");
	private readonly delegate* unmanaged<uint, ShaderParameterName, int*, void> _glGetShaderIv = (delegate* unmanaged<uint, ShaderParameterName, int*, void>)procGetProcAddress("glGetShaderiv");
	private readonly delegate* unmanaged<uint, uint, out uint, byte*, void> _glGetShaderInfoLog = (delegate* unmanaged<uint, uint, out uint, byte*, void>)procGetProcAddress("glGetShaderInfoLog");
	private readonly delegate* unmanaged<uint> _glCreateProgram = (delegate* unmanaged<uint>)procGetProcAddress("glCreateProgram");
	private readonly delegate* unmanaged<uint, void> _glDeleteProgram = (delegate* unmanaged<uint, void>)procGetProcAddress("glDeleteProgram");
	private readonly delegate* unmanaged<uint, uint, void> _glAttachShader = (delegate* unmanaged<uint, uint, void>)procGetProcAddress("glAttachShader");
	private readonly delegate* unmanaged<uint, uint, void> _glDetachShader = (delegate* unmanaged<uint, uint, void>)procGetProcAddress("glDetachShader");
	private readonly delegate* unmanaged<uint, void> _glLinkProgram = (delegate* unmanaged<uint, void>)procGetProcAddress("glLinkProgram");
	private readonly delegate* unmanaged<uint, ProgramParameterName, int*, void> _glGetProgramIv = (delegate* unmanaged<uint, ProgramParameterName, int*, void>)procGetProcAddress("glGetProgramiv");
	private readonly delegate* unmanaged<uint, uint, out uint, byte*, void> _glGetProgramInfoLog = (delegate* unmanaged<uint, uint, out uint, byte*, void>)procGetProcAddress("glGetProgramInfoLog");
	private readonly delegate* unmanaged<uint, void> _glUseProgram = (delegate* unmanaged<uint, void>)procGetProcAddress("glUseProgram");
	private readonly delegate* unmanaged<uint, byte*, int> _glGetUniformLocation = (delegate* unmanaged<uint, byte*, int>)procGetProcAddress("glGetUniformLocation");
	private readonly delegate* unmanaged<int, uint, bool, void*, void> _glUniformMatrix4Fv = (delegate* unmanaged<int, uint, bool, void*, void>)procGetProcAddress("glUniformMatrix4fv");
	private readonly delegate* unmanaged<int, uint, int*, void> _glUniform1Iv = (delegate* unmanaged<int, uint, int*, void>)procGetProcAddress("glUniform1iv");
	private readonly delegate* unmanaged<DrawMode, uint, IndexType, void*, void> _glDrawElements = (delegate* unmanaged<DrawMode, uint, IndexType, void*, void>)procGetProcAddress("glDrawElements");
	private readonly delegate* unmanaged<uint, uint*, void> _glGenTextures = (delegate* unmanaged<uint, uint*, void>)procGetProcAddress("glGenTextures");
	private readonly delegate* unmanaged<uint, uint*, void> _glDeleteTextures = (delegate* unmanaged<uint, uint*, void>)procGetProcAddress("glDeleteTextures");
	private readonly delegate* unmanaged<TextureTarget, uint, void> _glBindTexture = (delegate* unmanaged<TextureTarget, uint, void>)procGetProcAddress("glBindTexture");
	private readonly delegate* unmanaged<TextureTarget, int, InternalFormat, uint, uint, int, PixelFormat, PixelType, void*, void> _glTexImage2D =
		(delegate* unmanaged<TextureTarget, int, InternalFormat, uint, uint, int, PixelFormat, PixelType, void*, void>)procGetProcAddress("glTexImage2D");
	private readonly delegate* unmanaged<TextureTarget, int, int, int, uint, uint, PixelFormat, PixelType, void*, void> _glTexSubImage2D =
		(delegate* unmanaged<TextureTarget, int, int, int, uint, uint, PixelFormat, PixelType, void*, void>)procGetProcAddress("glTexSubImage2D");
	private readonly delegate* unmanaged<TextureTarget, void> _glGenerateMipmap = (delegate* unmanaged<TextureTarget, void>)procGetProcAddress("glGenerateMipmap");
	private readonly delegate* unmanaged<TextureTarget, TextureParameter, int, void> _glTexParameterI = (delegate* unmanaged<TextureTarget, TextureParameter, int, void>)procGetProcAddress("glTexParameteri");
	private readonly delegate* unmanaged<uint, void> _glActiveTexture = (delegate* unmanaged<uint, void>)procGetProcAddress("glActiveTexture");
	private readonly delegate* unmanaged<uint, int, VertexAttribType, uint, nuint, void> _glVertexAttribIPointer =
		(delegate* unmanaged<uint, int, VertexAttribType, uint, nuint, void>)procGetProcAddress("glVertexAttribIPointer");
	private readonly delegate* unmanaged<IntegerParameterName, int*, void> _glGetIntegerV = (delegate* unmanaged<IntegerParameterName, int*, void>)procGetProcAddress("glGetIntegerv");
	private readonly delegate* unmanaged<StringName, nint> _glGetString = (delegate* unmanaged<StringName, nint>)procGetProcAddress("glGetString");
	private readonly delegate* unmanaged<Cap, void> _glEnable = (delegate* unmanaged<Cap, void>)procGetProcAddress("glEnable");
	private readonly delegate* unmanaged<Cap, void> _glDisable = (delegate* unmanaged<Cap, void>)procGetProcAddress("glDisable");
	private readonly delegate* unmanaged<BlendFactor, BlendFactor, void> _glBlendFunc = (delegate* unmanaged<BlendFactor, BlendFactor, void>)procGetProcAddress("glBlendFunc");

	public override void Viewport(int x, int y, uint width, uint height) => _glViewport(x, y, width, height);

	public override void ClearColor(float red, float green, float blue, float alpha) => _glClearColor(red, green, blue, alpha);

	public override void Clear(ClearMask mask) => _glClear(mask);

	public override void GenBuffers(Span<uint> buffers)
	{
		fixed (uint* buffersPtr = buffers)
			_glGenBuffers((uint)buffers.Length, buffersPtr);
	}

	public override uint GenBuffer()
	{
		uint buffer;
		_glGenBuffers(1, &buffer);
		return buffer;
	}

	public override void DeleteBuffers(ReadOnlySpan<uint> buffers)
	{
		fixed (uint* buffersPtr = buffers)
			_glDeleteBuffers((uint)buffers.Length, buffersPtr);
	}

	public override void DeleteBuffer(uint buffer)
	{
		_glDeleteBuffers(1, &buffer);
	}

	public override void BindBuffer(BufferTarget target, uint buffer) => _glBindBuffer(target, buffer);

	public override void GenVertexArrays(Span<uint> arrays)
	{
		fixed (uint* arraysPtr = arrays)
			_glGenVertexArrays((uint)arrays.Length, arraysPtr);

		Span<byte> ptr = stackalloc byte[10];

		for (var i = 0; i < ptr.Length; i++)
			ptr[i] = 0;
	}

	public override uint GenVertexArray()
	{
		uint array;
		_glGenVertexArrays(1, &array);
		return array;
	}

	public override void DeleteVertexArrays(ReadOnlySpan<uint> arrays)
	{
		fixed (uint* arraysPtr = arrays)
			_glDeleteVertexArrays((uint)arrays.Length, arraysPtr);
	}

	public override void DeleteVertexArray(uint array) => _glDeleteVertexArrays(1, &array);

	public override void BindVertexArray(uint array) => _glBindVertexArray(array);

	public override void BufferData<T>(BufferTarget target, ReadOnlySpan<T> data, BufferUsage usage)
	{
		var size = (nuint)data.Length * (nuint)sizeof(T);
		fixed (T* dataPtr = data)
			_glBufferData(target, size, dataPtr, usage);
	}

	public override void BufferData(BufferTarget target, nuint size, nuint data, BufferUsage usage)
	{
		_glBufferData(target, size, (void*)data, usage);
	}

	public override void BufferSubData<T>(BufferTarget target, nint offset, ReadOnlySpan<T> data)
	{
		var size = (nuint)data.Length * (nuint)sizeof(T);
		fixed (T* dataPtr = data)
			_glBufferSubData(target, offset, size, dataPtr);
	}

	public override void VertexAttribPointer(uint index, int size, VertexAttribType type, bool normalized, uint stride, nuint pointer) =>
		_glVertexAttribPointer(index, size, type, normalized, stride, pointer);

	public override void VertexAttribIPointer(uint index, int size, VertexAttribType type, uint stride, nuint pointer) =>
		_glVertexAttribIPointer(index, size, type, stride, pointer);

	public override void EnableVertexAttribArray(uint index) => _glEnableVertexAttribArray(index);

	public override void DisableVertexAttribArray(uint index) => _glDisableVertexAttribArray(index);

	public override void DrawArrays(DrawMode mode, int first, uint count) => _glDrawArrays(mode, first, count);

	public override uint CreateShader(ShaderType shaderType) => _glCreateShader(shaderType);

	public override void DeleteShader(uint shader) => _glDeleteShader(shader);

	public override void ShaderSource(uint shader, string source)
	{
		Span<byte> stringBuffer = stackalloc byte[Encoding.UTF8.GetByteCount(source)];
		Encoding.UTF8.GetBytes(source, stringBuffer);

		var length = source.Length;

		fixed (byte* stringBufferPtr = stringBuffer)
			_glShaderSource(shader, 1, &stringBufferPtr, &length);
	}

	public override void CompileShader(uint shader) => _glCompileShader(shader);

	public override int GetShaderiv(uint shader, ShaderParameterName pname)
	{
		int ret;
		_glGetShaderIv(shader, pname, &ret);
		return ret;
	}

	public override string GetShaderInfoLog(uint shader)
	{
		var infoLogLength = GetShaderiv(shader, ShaderParameterName.InfoLogLength);

		if (infoLogLength == 0)
			return "";

		var infoLog = stackalloc byte[infoLogLength];

		_glGetShaderInfoLog(shader, (uint)infoLogLength, out _, infoLog);

		return Marshal.PtrToStringUTF8((nint)infoLog) ?? "";
	}

	public override uint CreateProgram() => _glCreateProgram();

	public override void DeleteProgram(uint program) => _glDeleteProgram(program);

	public override void AttachShader(uint program, uint shader) => _glAttachShader(program, shader);

	public override void DetachShader(uint program, uint shader) => _glDetachShader(program, shader);

	public override void LinkProgram(uint program) => _glLinkProgram(program);

	public override int GetProgramIv(uint program, ProgramParameterName pname)
	{
		int ret;
		_glGetProgramIv(program, pname, &ret);
		return ret;
	}

	public override string GetProgramInfoLog(uint program)
	{
		var infoLogLength = GetProgramIv(program, ProgramParameterName.InfoLogLength);

		if (infoLogLength == 0)
			return "";

		var infoLog = stackalloc byte[infoLogLength];

		_glGetProgramInfoLog(program, (uint)infoLogLength, out _, infoLog);

		return Marshal.PtrToStringUTF8((nint)infoLog) ?? "";
	}

	public override void UseProgram(uint program) => _glUseProgram(program);

	public override int GetUniformLocation(uint program, string name)
	{
		Span<byte> stringBuffer = stackalloc byte[Encoding.UTF8.GetByteCount(name)];
		Encoding.UTF8.GetBytes(name, stringBuffer);

		fixed (byte* stringBufferPtr = stringBuffer)
			return _glGetUniformLocation(program, stringBufferPtr);
	}

	public override void UniformMatrix4Fv(int location, uint count, bool transpose, in Matrix4x4 value)
	{
		fixed (void* valuePtr = &value)
			_glUniformMatrix4Fv(location, count, transpose, valuePtr);
	}

	public override void Uniform1Iv(int location, ReadOnlySpan<int> value)
	{
		fixed (int* valuePtr = value)
			_glUniform1Iv(location, (uint)value.Length, valuePtr);
	}

	public override void DrawElements<T>(DrawMode mode, uint count, IndexType type, Span<T> indices)
	{
		fixed (void* indicesPtr = indices)
			_glDrawElements(mode, count, type, indicesPtr);
	}

	public override void DrawElements(DrawMode mode, uint count, IndexType type, nuint indices) =>
		_glDrawElements(mode, count, type, (void*)indices);

	public override void GenTextures(Span<uint> textures)
	{
		fixed (uint* texturesPtr = textures)
			_glGenTextures((uint)textures.Length, texturesPtr);
	}

	public override uint GenTexture()
	{
		uint texture;
		_glGenTextures(1, &texture);
		return texture;
	}

	public override void DeleteTextures(ReadOnlySpan<uint> textures)
	{
		fixed (uint* texturesPtr = textures)
			_glGenTextures((uint)textures.Length, texturesPtr);
	}

	public override void DeleteTexture(uint texture) => _glDeleteTextures(1, &texture);

	public override void BindTexture(TextureTarget target, uint texture) => _glBindTexture(target, texture);

	public override void TexImage2D<T>(TextureTarget target, int level, InternalFormat internalFormat, uint width, uint height, int border, PixelFormat format, PixelType type, ReadOnlySpan<T> data)
	{
		fixed (void* dataPtr = data)
			_glTexImage2D(target, level, internalFormat, width, height, border, format, type, dataPtr);
	}

	public override void TexImage2D(TextureTarget target, int level, InternalFormat internalFormat, uint width, uint height, int border, PixelFormat format, PixelType type,
		nuint data)
	{
		_glTexImage2D(target, level, internalFormat, width, height, border, format, type, (void*)0);
	}

	public override void TexSubImage2D<T>(TextureTarget target, int level, int xoffset, int yoffset, uint width, uint height, PixelFormat format, PixelType type, ReadOnlySpan<T> data)
	{
		fixed (void* dataPtr = data)
			_glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, dataPtr);
	}

	public override void GenerateMipmap(TextureTarget target) => _glGenerateMipmap(target);

	public override void TexParameteri(TextureTarget target, TextureParameter pname, int param) => _glTexParameterI(target, pname, param);
	public override void ActiveTexture(uint texture) => _glActiveTexture(texture);

	public override void GetIntegerv(IntegerParameterName pname, Span<int> data)
	{
		fixed (int* dataPtr = data)
			_glGetIntegerV(pname, dataPtr);
	}

	public override void GetIntegerv(IntegerParameterName pname, out int data)
	{
		fixed (int* dataPtr = &data)
			_glGetIntegerV(pname, dataPtr);
	}

	public override string GetString(StringName name) => Marshal.PtrToStringUTF8(_glGetString(name)) ?? throw new();

	public override void Enable(Cap cap) => _glEnable(cap);
	public override void Disable(Cap cap) => _glDisable(cap);
	public override void BlendFunc(BlendFactor sfactor, BlendFactor dfactor) => _glBlendFunc(sfactor, dfactor);
}
