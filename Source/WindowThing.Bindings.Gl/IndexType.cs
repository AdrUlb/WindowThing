using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum IndexType : GLenum
{
	UnsignedByte = _glUnsignedByte,
	UnsignedShort = _glUnsignedShort,
	UnsignedInt = _glUnsignedInt
}
