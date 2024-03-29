using static RenderThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Bindings.Gl;

public enum VertexAttribType : GLenum
{
	Byte = GL_BYTE,
	UnsignedByte = GL_UNSIGNED_BYTE,
	Short = GL_SHORT,
	UnsignedShort = GL_UNSIGNED_SHORT,
	Int = GL_INT,
	UnsignedInt = GL_UNSIGNED_INT,
	HalfFloat = GL_HALF_FLOAT,
	Float = GL_FLOAT,
	Fixed = GL_FIXED,
	Int2_10_10_10_REV = GL_INT_2_10_10_10_REV,
	UnsignedInt2_10_10_10_REV = GL_UNSIGNED_INT_2_10_10_10_REV
}
