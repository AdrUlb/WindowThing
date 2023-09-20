using static ARenderer.Gl.Constants;
using GLenum = System.UInt32;

namespace ARenderer.Gl;

public enum TextureWrap : GLenum
{
	ClampToEdge = GL_CLAMP_TO_EDGE,
	MirroredRepeat = GL_MIRRORED_REPEAT,
	Repeat = GL_REPEAT
}
