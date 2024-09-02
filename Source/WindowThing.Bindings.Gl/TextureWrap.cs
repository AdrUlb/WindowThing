using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum TextureWrap : GLenum
{
	ClampToEdge = _glClampToEdge,
	MirroredRepeat = _glMirroredRepeat,
	Repeat = _glRepeat
}
