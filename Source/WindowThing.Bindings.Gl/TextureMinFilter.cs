using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum TextureMinFilter : GLenum
{
	Nearest = _glNearest,
	Linear = _glLinear,
	NearestMipmapNearest = _glNearestMipmapNearest,
	LinearMipmapNearest = _glLinearMipmapNearest,
	NearestMipmapLinear = _glNearestMipmapLinear,
	LinearMipmapLinear = _glLinearMipmapLinear
}
