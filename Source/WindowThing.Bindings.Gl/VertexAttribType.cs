using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum VertexAttribType : GLenum
{
	Byte = _glByte,
	UnsignedByte = _glUnsignedByte,
	Short = _glShort,
	UnsignedShort = _glUnsignedShort,
	Int = _glInt,
	UnsignedInt = _glUnsignedInt,
	HalfFloat = _glHalfFloat,
	Float = _glFloat,
	Fixed = _glFixed,
	Int2101010Rev = _glInt2101010Rev,
	UnsignedInt2101010Rev = _glUnsignedInt2101010Rev
}
