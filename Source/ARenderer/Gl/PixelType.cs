using static ARenderer.Gl.Constants;
using GLenum = System.UInt32;

namespace ARenderer.Gl;

public enum PixelType : GLenum
{
	UnsignedByte = GL_UNSIGNED_BYTE,
	Byte = GL_BYTE,
	UnsignedShort = GL_UNSIGNED_SHORT,
	Short = GL_SHORT,
	UnsignedInt = GL_UNSIGNED_INT,
	Int = GL_INT,
	HalfFloat = GL_HALF_FLOAT,
	Float = GL_FLOAT,
	UnsignedShort5_6_5 = GL_UNSIGNED_SHORT_5_6_5,
	UnsignedShort4_4_4_4 = GL_UNSIGNED_SHORT_4_4_4_4,
	UnsignedShort5_5_5_1 = GL_UNSIGNED_SHORT_5_5_5_1,
	UnsignedInt2_10_10_10_REV = GL_UNSIGNED_INT_2_10_10_10_REV,
	UnsignedInt10F_11F_11F_REV = GL_UNSIGNED_INT_10F_11F_11F_REV,
	UnsignedInt5_9_9_9_REV = GL_UNSIGNED_INT_5_9_9_9_REV,
	UnsignedInt24_8 = GL_UNSIGNED_INT_24_8,
	Float32UnsignedInt24_8_REV = GL_FLOAT_32_UNSIGNED_INT_24_8_REV
}
