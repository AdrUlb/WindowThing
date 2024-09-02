using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum StringName : GLenum
{
	Extensions = _glExtensions,
	Renderer = _glRenderer,
	ShadingLanguageVersion = _glShadingLanguageVersion,
	Vendor = _glVendor,
	Version = _glVersion
}
