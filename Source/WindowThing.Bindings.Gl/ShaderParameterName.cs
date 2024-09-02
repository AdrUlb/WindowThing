using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum ShaderParameterName : GLenum
{
	Type = _glShaderType,
	DeleteStatus = _glDeleteStatus,
	CompileStatus = _glCompileStatus,
	InfoLogLength = _glInfoLogLength,
	SourceLength = _glShaderSourceLength
}
