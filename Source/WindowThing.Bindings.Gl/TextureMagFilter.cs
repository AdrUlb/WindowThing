using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum TextureMagFilter : GLenum
{
	Nearest = _glNearest,
	Linear = _glLinear,
}
