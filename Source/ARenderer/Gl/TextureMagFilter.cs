using static ARenderer.Gl.Constants;
using GLenum = System.UInt32;

namespace ARenderer.Gl;

public enum TextureMagFilter : GLenum
{
	Nearest = GL_NEAREST,
	Linear = GL_LINEAR,
}
