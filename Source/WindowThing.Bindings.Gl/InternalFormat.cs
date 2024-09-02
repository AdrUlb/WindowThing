using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum InternalFormat : GLenum
{
    Rgb = _glRgb,
    Rgba = _glRgba,
    LuminanceAlpha = _glLuminanceAlpha,
    Luminance = _glLuminance,
    Alpha = _glAlpha
}
