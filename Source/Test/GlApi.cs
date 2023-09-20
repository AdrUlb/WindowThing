using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using ARenderer.Gl;

namespace Test;

internal unsafe class GlApi : IGlApi
{
	public delegate nint ProcGetProcAddress(string proc);

	private delegate void ProcViewport(int x, int y, uint width, uint height);
	private delegate void ProcClear(ClearMask mask);
	private delegate void ProcClearColor(float red, float green, float blue, float alpha);
	private delegate void ProcGenBuffers(uint n, uint* buffers);
	private delegate void ProcDeleteBuffers(uint n, uint* buffers);
	private delegate void ProcBindBuffer(BufferTarget target, uint buffer);
	private delegate void ProcGenVertexArrays(uint n, uint* arrays);
	private delegate void ProcDeleteVertexArrays(uint n, uint* arrays);
	private delegate void ProcBindVertexArray(uint array);
	private delegate void ProcBufferData(BufferTarget target, nuint size, void* data, BufferUsage usage);
	private delegate void ProcBufferSubData(BufferTarget target, nint offset, nuint size, void* data);
	private delegate void ProcVertexAttribPointer(uint index, int size, VertexAttribType type, bool normalized, uint stride, nuint pointer);
	private delegate void ProcVertexAttribIPointer(uint index, int size, VertexAttribType type, uint stride, nuint pointer);
	private delegate void ProcEnableVertexAttribArray(uint index);
	private delegate void ProcDisableVertexAttribArray(uint index);
	private delegate void ProcDrawArrays(DrawMode mode, int first, uint count);
	private delegate uint ProcCreateShader(ShaderType shaderType);
	private delegate void ProcDeleteShader(uint shader);
	private delegate void ProcShaderSource(uint shader, uint count, byte** @string, int* length);
	private delegate void ProcCompileShader(uint shader);
	private delegate void ProcGetShaderiv(uint shader, ShaderParameterName pname, int* @params);
	private delegate void ProcGetShaderInfoLog(uint shader, uint maxLength, out uint length, byte* outInfoLog);
	private delegate uint ProcCreateProgram();
	private delegate void ProcDeleteProgram(uint program);
	private delegate void ProcAttachShader(uint program, uint shader);
	private delegate void ProcDetachShader(uint program, uint shader);
	private delegate void ProcLinkProgram(uint program);
	private delegate void ProcGetProgramiv(uint program, ProgramParameterName pname, int* @params);
	private delegate void ProcGetProgramInfoLog(uint program, uint maxLength, out uint length, byte* outInfoLog);
	private delegate void ProcUseProgram(uint program);
	private delegate int ProcGetUniformLocation(uint program, byte* name);
	private delegate void ProcUniformMatrix4fv(int location, uint count, bool transpose, void* value);
	private delegate void ProcUniform1iv(int location, uint count, int* value);
	private delegate void ProcDrawElements(DrawMode mode, uint count, IndexType type, void* indices);
	private delegate void ProcGenTextures(uint n, uint* textures);
	private delegate void ProcDeleteTextures(uint n, uint* textures);
	private delegate void ProcBindTexture(TextureTarget target, uint texture);

	private delegate void ProcTexImage2D(TextureTarget target, int level, InternalFormat internalFormat, uint width, uint height, int border, PixelFormat format,
		PixelType type, void* data);

	private delegate void ProcTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, uint width, uint height, PixelFormat format, PixelType type,
		void* data);

	private delegate void ProcGenerateMipmap(TextureTarget target);
	private delegate void ProcTexParameteri(TextureTarget target, TextureParameter pname, int param);
	private delegate void ProcActiveTexture(uint texture);

	private delegate void ProcGetIntegerv(IntegerParameterName pname, int* data);
	private delegate byte* ProcGetString(StringName name);

	private readonly ProcViewport glViewport;
	private readonly ProcClear glClear;
	private readonly ProcClearColor glClearColor;
	private readonly ProcGenBuffers glGenBuffers;
	private readonly ProcDeleteBuffers glDeleteBuffers;
	private readonly ProcBindBuffer glBindBuffer;
	private readonly ProcGenVertexArrays glGenVertexArrays;
	private readonly ProcDeleteVertexArrays glDeleteVertexArrays;
	private readonly ProcBindVertexArray glBindVertexArray;
	private readonly ProcBufferData glBufferData;
	private readonly ProcBufferSubData glBufferSubData;
	private readonly ProcVertexAttribPointer glVertexAttribPointer;
	private readonly ProcEnableVertexAttribArray glEnableVertexAttribArray;
	private readonly ProcDisableVertexAttribArray glDisableVertexAttribArray;
	private readonly ProcDrawArrays glDrawArrays;
	private readonly ProcCreateShader glCreateShader;
	private readonly ProcDeleteShader glDeleteShader;
	private readonly ProcShaderSource glShaderSource;
	private readonly ProcCompileShader glCompileShader;
	private readonly ProcGetShaderiv glGetShaderiv;
	private readonly ProcGetShaderInfoLog glGetShaderInfoLog;
	private readonly ProcCreateProgram glCreateProgram;
	private readonly ProcDeleteProgram glDeleteProgram;
	private readonly ProcAttachShader glAttachShader;
	private readonly ProcDetachShader glDetachShader;
	private readonly ProcLinkProgram glLinkProgram;
	private readonly ProcGetProgramiv glGetProgramiv;
	private readonly ProcGetProgramInfoLog glGetProgramInfoLog;
	private readonly ProcUseProgram glUseProgram;
	private readonly ProcGetUniformLocation glGetUniformLocation;
	private readonly ProcUniformMatrix4fv glUniformMatrix4fv;
	private readonly ProcUniform1iv glUniform1iv;
	private readonly ProcDrawElements glDrawElements;
	private readonly ProcGenTextures glGenTextures;
	private readonly ProcDeleteTextures glDeleteTextures;
	private readonly ProcBindTexture glBindTexture;
	private readonly ProcTexImage2D glTexImage2D;
	private readonly ProcTexSubImage2D glTexSubImage2D;
	private readonly ProcGenerateMipmap glGenerateMipmap;
	private readonly ProcTexParameteri glTexParameteri;
	private readonly ProcActiveTexture glActiveTexture;
	private readonly ProcVertexAttribIPointer glVertexAttribIPointer;
	private readonly ProcGetIntegerv glGetIntegerv;
	private readonly ProcGetString glGetString;

	public GlApi(ProcGetProcAddress procGetProcAddress)
	{
		glViewport = Marshal.GetDelegateForFunctionPointer<ProcViewport>(procGetProcAddress("glViewport"));
		glClear = Marshal.GetDelegateForFunctionPointer<ProcClear>(procGetProcAddress("glClear"));
		glClearColor = Marshal.GetDelegateForFunctionPointer<ProcClearColor>(procGetProcAddress("glClearColor"));
		glGenBuffers = Marshal.GetDelegateForFunctionPointer<ProcGenBuffers>(procGetProcAddress("glGenBuffers"));
		glDeleteBuffers = Marshal.GetDelegateForFunctionPointer<ProcDeleteBuffers>(procGetProcAddress("glDeleteBuffers"));
		glBindBuffer = Marshal.GetDelegateForFunctionPointer<ProcBindBuffer>(procGetProcAddress("glBindBuffer"));
		glGenVertexArrays = Marshal.GetDelegateForFunctionPointer<ProcGenVertexArrays>(procGetProcAddress("glGenVertexArrays"));
		glDeleteVertexArrays = Marshal.GetDelegateForFunctionPointer<ProcDeleteVertexArrays>(procGetProcAddress("glDeleteVertexArrays"));
		glBindVertexArray = Marshal.GetDelegateForFunctionPointer<ProcBindVertexArray>(procGetProcAddress("glBindVertexArray"));
		glBufferData = Marshal.GetDelegateForFunctionPointer<ProcBufferData>(procGetProcAddress("glBufferData"));
		glBufferSubData = Marshal.GetDelegateForFunctionPointer<ProcBufferSubData>(procGetProcAddress("glBufferSubData"));
		glVertexAttribPointer = Marshal.GetDelegateForFunctionPointer<ProcVertexAttribPointer>(procGetProcAddress("glVertexAttribPointer"));
		glVertexAttribIPointer = Marshal.GetDelegateForFunctionPointer<ProcVertexAttribIPointer>(procGetProcAddress("glVertexAttribIPointer"));
		glEnableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<ProcEnableVertexAttribArray>(procGetProcAddress("glEnableVertexAttribArray"));
		glDisableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<ProcDisableVertexAttribArray>(procGetProcAddress("glDisableVertexAttribArray"));
		glDrawArrays = Marshal.GetDelegateForFunctionPointer<ProcDrawArrays>(procGetProcAddress("glDrawArrays"));
		glCreateShader = Marshal.GetDelegateForFunctionPointer<ProcCreateShader>(procGetProcAddress("glCreateShader"));
		glDeleteShader = Marshal.GetDelegateForFunctionPointer<ProcDeleteShader>(procGetProcAddress("glDeleteShader"));
		glShaderSource = Marshal.GetDelegateForFunctionPointer<ProcShaderSource>(procGetProcAddress("glShaderSource"));
		glCompileShader = Marshal.GetDelegateForFunctionPointer<ProcCompileShader>(procGetProcAddress("glCompileShader"));
		glGetShaderiv = Marshal.GetDelegateForFunctionPointer<ProcGetShaderiv>(procGetProcAddress("glGetShaderiv"));
		glGetShaderInfoLog = Marshal.GetDelegateForFunctionPointer<ProcGetShaderInfoLog>(procGetProcAddress("glGetShaderInfoLog"));
		glCreateProgram = Marshal.GetDelegateForFunctionPointer<ProcCreateProgram>(procGetProcAddress("glCreateProgram"));
		glDeleteProgram = Marshal.GetDelegateForFunctionPointer<ProcDeleteProgram>(procGetProcAddress("glDeleteProgram"));
		glAttachShader = Marshal.GetDelegateForFunctionPointer<ProcAttachShader>(procGetProcAddress("glAttachShader"));
		glDetachShader = Marshal.GetDelegateForFunctionPointer<ProcDetachShader>(procGetProcAddress("glDetachShader"));
		glLinkProgram = Marshal.GetDelegateForFunctionPointer<ProcLinkProgram>(procGetProcAddress("glLinkProgram"));
		glGetProgramiv = Marshal.GetDelegateForFunctionPointer<ProcGetProgramiv>(procGetProcAddress("glGetProgramiv"));
		glGetProgramInfoLog = Marshal.GetDelegateForFunctionPointer<ProcGetProgramInfoLog>(procGetProcAddress("glGetProgramInfoLog"));
		glUseProgram = Marshal.GetDelegateForFunctionPointer<ProcUseProgram>(procGetProcAddress("glUseProgram"));
		glGetUniformLocation = Marshal.GetDelegateForFunctionPointer<ProcGetUniformLocation>(procGetProcAddress("glGetUniformLocation"));
		glUniformMatrix4fv = Marshal.GetDelegateForFunctionPointer<ProcUniformMatrix4fv>(procGetProcAddress("glUniformMatrix4fv"));
		glUniform1iv = Marshal.GetDelegateForFunctionPointer<ProcUniform1iv>(procGetProcAddress("glUniform1iv"));
		glDrawElements = Marshal.GetDelegateForFunctionPointer<ProcDrawElements>(procGetProcAddress("glDrawElements"));
		glGenTextures = Marshal.GetDelegateForFunctionPointer<ProcGenTextures>(procGetProcAddress("glGenTextures"));
		glDeleteTextures = Marshal.GetDelegateForFunctionPointer<ProcDeleteTextures>(procGetProcAddress("glDeleteTextures"));
		glBindTexture = Marshal.GetDelegateForFunctionPointer<ProcBindTexture>(procGetProcAddress("glBindTexture"));
		glTexImage2D = Marshal.GetDelegateForFunctionPointer<ProcTexImage2D>(procGetProcAddress("glTexImage2D"));
		glTexSubImage2D = Marshal.GetDelegateForFunctionPointer<ProcTexSubImage2D>(procGetProcAddress("glTexSubImage2D"));
		glGenerateMipmap = Marshal.GetDelegateForFunctionPointer<ProcGenerateMipmap>(procGetProcAddress("glGenerateMipmap"));
		glTexParameteri = Marshal.GetDelegateForFunctionPointer<ProcTexParameteri>(procGetProcAddress("glTexParameteri"));
		glActiveTexture = Marshal.GetDelegateForFunctionPointer<ProcActiveTexture>(procGetProcAddress("glActiveTexture"));
		glGetIntegerv = Marshal.GetDelegateForFunctionPointer<ProcGetIntegerv>(procGetProcAddress("glGetIntegerv"));
		glGetString = Marshal.GetDelegateForFunctionPointer<ProcGetString>(procGetProcAddress("glGetString"));
	}

	public void Viewport(int x, int y, uint width, uint height) => glViewport(x, y, width, height);

	public void ClearColor(float red, float green, float blue, float alpha) => glClearColor(red, green, blue, alpha);

	public void Clear(ClearMask mask) => glClear(mask);

	public void GenBuffers(Span<uint> buffers)
	{
		fixed (uint* buffersPtr = buffers)
			glGenBuffers((uint)buffers.Length, buffersPtr);
	}

	public uint GenBuffer()
	{
		uint buffer;
		glGenBuffers(1, &buffer);
		return buffer;
	}

	public void DeleteBuffers(ReadOnlySpan<uint> buffers)
	{
		fixed (uint* buffersPtr = buffers)
			glDeleteBuffers((uint)buffers.Length, buffersPtr);
	}

	public void DeleteBuffer(uint buffer)
	{
		glDeleteBuffers(1, &buffer);
	}

	public void BindBuffer(BufferTarget target, uint buffer) => glBindBuffer(target, buffer);

	public void GenVertexArrays(Span<uint> arrays)
	{
		fixed (uint* arraysPtr = arrays)
			glGenVertexArrays((uint)arrays.Length, arraysPtr);

		Span<byte> ptr = stackalloc byte[10];

		for (var i = 0; i < ptr.Length; i++)
			ptr[i] = 0;
	}

	public uint GenVertexArray()
	{
		uint array;
		glGenVertexArrays(1, &array);
		return array;
	}

	public void DeleteVertexArrays(ReadOnlySpan<uint> arrays)
	{
		fixed (uint* arraysPtr = arrays)
			glDeleteVertexArrays((uint)arrays.Length, arraysPtr);
	}

	public void DeleteVertexArray(uint array) => glDeleteVertexArrays(1, &array);

	public void BindVertexArray(uint array) => glBindVertexArray(array);

	public void BufferData<T>(BufferTarget target, ReadOnlySpan<T> data, BufferUsage usage) where T : unmanaged
	{
		var size = (nuint)data.Length * (nuint)sizeof(T);
		fixed (T* dataPtr = data)
			glBufferData(target, size, dataPtr, usage);
	}

	public void BufferData(BufferTarget target, nuint size, nuint data, BufferUsage usage)
	{
		glBufferData(target, size, (void*)data, usage);
	}

	public void BufferSubData<T>(BufferTarget target, nint offset, ReadOnlySpan<T> data) where T : unmanaged
	{
		var size = (nuint)data.Length * (nuint)sizeof(T);
		fixed (T* dataPtr = data)
			glBufferSubData(target, offset, size, dataPtr);
	}

	public void VertexAttribPointer(uint index, int size, VertexAttribType type, bool normalized, uint stride, nuint pointer) =>
		glVertexAttribPointer(index, size, type, normalized, stride, pointer);

	public void VertexAttribIPointer(uint index, int size, VertexAttribType type, uint stride, nuint pointer) =>
		glVertexAttribIPointer(index, size, type, stride, pointer);

	public void EnableVertexAttribArray(uint index) => glEnableVertexAttribArray(index);

	public void DisableVertexAttribArray(uint index) => glDisableVertexAttribArray(index);

	public void DrawArrays(DrawMode mode, int first, uint count) => glDrawArrays(mode, first, count);

	public uint CreateShader(ShaderType shaderType) => glCreateShader(shaderType);

	public void DeleteShader(uint shader) => glDeleteShader(shader);

	public void ShaderSource(uint shader, string source)
	{
		Span<byte> stringBuffer = stackalloc byte[Encoding.UTF8.GetByteCount(source)];
		Encoding.UTF8.GetBytes(source, stringBuffer);

		var length = source.Length;

		fixed (byte* stringBufferPtr = stringBuffer)
			glShaderSource(shader, 1, &stringBufferPtr, &length);
	}

	public void CompileShader(uint shader) => glCompileShader(shader);

	public int GetShaderiv(uint shader, ShaderParameterName pname)
	{
		int ret;
		glGetShaderiv(shader, pname, &ret);
		return ret;
	}

	public string GetShaderInfoLog(uint shader)
	{
		var infoLogLength = GetShaderiv(shader, ShaderParameterName.InfoLogLength);

		if (infoLogLength == 0)
			return "";

		var infoLog = stackalloc byte[infoLogLength];

		glGetShaderInfoLog(shader, (uint)infoLogLength, out _, infoLog);

		return Marshal.PtrToStringUTF8((nint)infoLog) ?? "";
	}

	public uint CreateProgram() => glCreateProgram();

	public void DeleteProgram(uint program) => glDeleteProgram(program);

	public void AttachShader(uint program, uint shader) => glAttachShader(program, shader);

	public void DetachShader(uint program, uint shader) => glDetachShader(program, shader);

	public void LinkProgram(uint program) => glLinkProgram(program);

	public int GetProgramiv(uint program, ProgramParameterName pname)
	{
		int ret;
		glGetProgramiv(program, pname, &ret);
		return ret;
	}

	public string GetProgramInfoLog(uint program)
	{
		var infoLogLength = GetProgramiv(program, ProgramParameterName.InfoLogLength);

		if (infoLogLength == 0)
			return "";

		var infoLog = stackalloc byte[infoLogLength];

		glGetProgramInfoLog(program, (uint)infoLogLength, out _, infoLog);

		return Marshal.PtrToStringUTF8((nint)infoLog) ?? "";
	}

	public void UseProgram(uint program) => glUseProgram(program);

	public int GetUniformLocation(uint program, string name)
	{
		Span<byte> stringBuffer = stackalloc byte[Encoding.UTF8.GetByteCount(name)];
		Encoding.UTF8.GetBytes(name, stringBuffer);

		fixed (byte* stringBufferPtr = stringBuffer)
			return glGetUniformLocation(program, stringBufferPtr);
	}

	public void UniformMatrix4fv(int location, uint count, bool transpose, in Matrix4x4 value)
	{
		fixed (void* valuePtr = &value)
			glUniformMatrix4fv(location, count, transpose, valuePtr);
	}

	public void Uniform1iv(int location, ReadOnlySpan<int> value)
	{
		fixed (int* valuePtr = value)
			glUniform1iv(location, (uint)value.Length, valuePtr);
	}

	public void DrawElements<T>(DrawMode mode, uint count, IndexType type, Span<T> indices) where T : unmanaged
	{
		fixed (void* indicesPtr = indices)
			glDrawElements(mode, count, type, indicesPtr);
	}

	public void DrawElements(DrawMode mode, uint count, IndexType type, nuint indices) =>
		glDrawElements(mode, count, type, (void*)indices);

	public void GenTextures(Span<uint> textures)
	{
		fixed (uint* texturesPtr = textures)
			glGenTextures((uint)textures.Length, texturesPtr);
	}

	public uint GenTexture()
	{
		uint texture;
		glGenTextures(1, &texture);
		return texture;
	}

	public void DeleteTextures(ReadOnlySpan<uint> textures)
	{
		fixed (uint* texturesPtr = textures)
			glGenTextures((uint)textures.Length, texturesPtr);
	}

	public void DeleteTexture(uint texture) => glDeleteTextures(1, &texture);

	public void BindTexture(TextureTarget target, uint texture) => glBindTexture(target, texture);

	public void TexImage2D<T>(TextureTarget target, int level, InternalFormat internalFormat, uint width, uint height, int border, PixelFormat format,
		PixelType type,
		ReadOnlySpan<T> data) where T : unmanaged
	{
		fixed (void* dataPtr = data)
			glTexImage2D(target, level, internalFormat, width, height, border, format, type, dataPtr);
	}

	public void TexImage2D(TextureTarget target, int level, InternalFormat internalFormat, uint width, uint height, int border, PixelFormat format, PixelType type,
		nuint data)
	{
		glTexImage2D(target, level, internalFormat, width, height, border, format, type, (void*)0);
	}
	public void TexSubImage2D<T>(TextureTarget target, int level, int xoffset, int yoffset, uint width, uint height, PixelFormat format, PixelType type,
		ReadOnlySpan<T> data) where T : unmanaged
	{
		fixed (void* dataPtr = data)
			glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, dataPtr);
	}

	public void GenerateMipmap(TextureTarget target) => glGenerateMipmap(target);

	public void TexParameteri(TextureTarget target, TextureParameter pname, int param) => glTexParameteri(target, pname, param);
	public void ActiveTexture(uint texture) => glActiveTexture(texture);

	public void GetIntegerv(IntegerParameterName pname, Span<int> data)
	{
		fixed (int* dataPtr = data)
			glGetIntegerv(pname, dataPtr);
	}

	public void GetIntegerv(IntegerParameterName pname, out int data)
	{
		fixed (int* dataPtr = &data)
			glGetIntegerv(pname, dataPtr);
	}

	public string GetString(StringName name) => Marshal.PtrToStringUTF8((nint)glGetString(name)) ?? throw new();
}
