using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum PixelType : GLenum
{
	UnsignedByte = _glUnsignedByte,
	Byte = _glByte,
	UnsignedShort = _glUnsignedShort,
	Short = _glShort,
	UnsignedInt = _glUnsignedInt,
	Int = _glInt,
	HalfFloat = _glHalfFloat,
	Float = _glFloat,
	UnsignedShort565 = _glUnsignedShort565,
	UnsignedShort4444 = _glUnsignedShort4444,
	UnsignedShort5551 = _glUnsignedShort5551,
	UnsignedInt2101010Rev = _glUnsignedInt2101010Rev,
	UnsignedInt10F11F11FRev = _glUnsignedInt10F11F11FRev,
	UnsignedInt5999Rev = _glUnsignedInt5999Rev,
	UnsignedInt248 = _glUnsignedInt248,
	Float32UnsignedInt248Rev = _glFloat32UnsignedInt248Rev
}
