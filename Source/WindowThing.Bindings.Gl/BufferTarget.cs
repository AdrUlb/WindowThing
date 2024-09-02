using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum BufferTarget : GLenum
{
	Array = _glArrayBuffer,
	AtomicCounter = _glAtomicCounterBuffer,
	CopyRead = _glCopyReadBuffer,
	CopyWrite = _glCopyWriteBuffer,
	DrawIndirect = _glDrawIndirectBuffer,
	DispatchIndirect = _glDispatchIndirectBuffer,
	ElementArray = _glElementArrayBuffer,
	PixelPack = _glPixelPackBuffer,
	PixelUnpack = _glPixelUnpackBuffer,
	ShaderStorage = _glShaderStorageBuffer,
	TransformFeedback = _glTransformFeedbackBuffer,
	Uniform = _glUniformBuffer
}
