using static RenderThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Bindings.Gl;

public enum IntegerParameterName : GLenum
{
    MaxTextureImageUnits = GL_MAX_TEXTURE_IMAGE_UNITS
}
