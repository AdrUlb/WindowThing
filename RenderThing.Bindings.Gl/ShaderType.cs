using static RenderThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Bindings.Gl;

public enum ShaderType : GLenum
{
	Vertex = GL_VERTEX_SHADER,
	Fragment = GL_FRAGMENT_SHADER,
	Compute = GL_COMPUTE_SHADER
}
