using static RenderThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Bindings.Gl;

public enum PixelFormat : GLenum
{
	Red = GL_RED,
	RedInteger = GL_RED_INTEGER,
	Rg = GL_RG,
	RgInteger = GL_RG_INTEGER,
	Rgb = GL_RGB,
	RgbInteger = GL_RGB_INTEGER,
	Rgba = GL_RGBA,
	RgbaInteger = GL_RGBA_INTEGER,
	DepthComponent = GL_DEPTH_COMPONENT,
	DepthStencil = GL_DEPTH_STENCIL,
	LuminanceAlpha = GL_LUMINANCE_ALPHA,
	Luminance = GL_LUMINANCE,
	Alpha = GL_ALPHA
}
