using static ARenderer.Gl.Constants;
using GLenum = System.UInt32;

namespace ARenderer.Gl;

public enum InternalFormat : GLenum
{
    Rgb = GL_RGB,
    Rgba = GL_RGBA,
    LuminanceAlpha = GL_LUMINANCE_ALPHA,
    Luminance = GL_LUMINANCE,
    Alpha = GL_ALPHA
}
