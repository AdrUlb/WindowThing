using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum PixelFormat : GLenum
{
	Red = _glRed,
	RedInteger = _glRedInteger,
	Rg = _glRg,
	RgInteger = _glRgInteger,
	Rgb = _glRgb,
	RgbInteger = _glRgbInteger,
	Rgba = _glRgba,
	RgbaInteger = _glRgbaInteger,
	DepthComponent = _glDepthComponent,
	DepthStencil = _glDepthStencil,
	LuminanceAlpha = _glLuminanceAlpha,
	Luminance = _glLuminance,
	Alpha = _glAlpha
}
