using static RenderThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Bindings.Gl;

public enum InternalFormat : GLenum
{
    Rgb = GL_RGB,
    Rgba = GL_RGBA,
    LuminanceAlpha = GL_LUMINANCE_ALPHA,
    Luminance = GL_LUMINANCE,
    Alpha = GL_ALPHA
}
