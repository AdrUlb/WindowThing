using static RenderThing.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Gl;

public enum ShaderParameterName : GLenum
{
	Type = GL_SHADER_TYPE,
	DeleteStatus = GL_DELETE_STATUS,
	CompileStatus = GL_COMPILE_STATUS,
	InfoLogLength = GL_INFO_LOG_LENGTH,
	SourceLength = GL_SHADER_SOURCE_LENGTH
}
