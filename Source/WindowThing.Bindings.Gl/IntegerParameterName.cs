﻿using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum IntegerParameterName : GLenum
{
    MaxTextureImageUnits = _glMaxTextureImageUnits
}
