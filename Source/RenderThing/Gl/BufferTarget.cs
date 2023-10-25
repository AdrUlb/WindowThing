using static RenderThing.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Gl;

public enum BufferTarget : GLenum
{
	Array = GL_ARRAY_BUFFER,
	AtomicCounter = GL_ATOMIC_COUNTER_BUFFER,
	CopyRead = GL_COPY_READ_BUFFER,
	CopyWrite = GL_COPY_WRITE_BUFFER,
	DrawIndirect = GL_DRAW_INDIRECT_BUFFER,
	DispatchIndirect = GL_DISPATCH_INDIRECT_BUFFER,
	ElementArray = GL_ELEMENT_ARRAY_BUFFER,
	PixelPack = GL_PIXEL_PACK_BUFFER,
	PixelUnpack = GL_PIXEL_UNPACK_BUFFER,
	ShaderStorage = GL_SHADER_STORAGE_BUFFER,
	TransformFeedback = GL_TRANSFORM_FEEDBACK_BUFFER,
	Uniform = GL_UNIFORM_BUFFER
}
