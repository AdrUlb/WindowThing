using static RenderThing.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Gl;

public enum TextureMagFilter : GLenum
{
	Nearest = GL_NEAREST,
	Linear = GL_LINEAR,
}
