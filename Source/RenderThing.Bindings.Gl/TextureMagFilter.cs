using static RenderThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Bindings.Gl;

public enum TextureMagFilter : GLenum
{
	Nearest = GL_NEAREST,
	Linear = GL_LINEAR,
}
