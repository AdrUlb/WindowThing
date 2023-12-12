using static RenderThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Bindings.Gl;

public enum IndexType : GLenum
{
	UnsignedByte = GL_UNSIGNED_BYTE,
	UnsignedShort = GL_UNSIGNED_SHORT,
	UnsignedInt = GL_UNSIGNED_INT
}
