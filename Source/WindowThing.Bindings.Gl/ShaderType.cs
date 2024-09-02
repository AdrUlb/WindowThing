using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum ShaderType : GLenum
{
	Vertex = _glVertexShader,
	Fragment = _glFragmentShader,
	Compute = _glComputeShader
}
