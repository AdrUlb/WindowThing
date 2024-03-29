using static RenderThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Bindings.Gl;

public enum ProgramParameterName : GLenum
{
	ActiveAtomicCounterBuffers = GL_ACTIVE_ATOMIC_COUNTER_BUFFERS,
	ActiveAttributes = GL_ACTIVE_ATTRIBUTES,
	ActiveAttributesMaxLength = GL_ACTIVE_ATTRIBUTE_MAX_LENGTH,
	ActiveUniforms = GL_ACTIVE_UNIFORMS,
	ActiveUniformBlocks = GL_ACTIVE_UNIFORM_BLOCKS,
	ActiveUniformBlockMaxNameLength = GL_ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH,
	ActiveUniformMaxLength = GL_ACTIVE_UNIFORM_MAX_LENGTH,
	AttachedShaders = GL_ATTACHED_SHADERS,
	ComputeWorkGroupSize = GL_COMPUTE_WORK_GROUP_SIZE,
	DeleteStatus = GL_DELETE_STATUS,
	InfoLogLength = GL_INFO_LOG_LENGTH,
	LinkStatus = GL_LINK_STATUS,
	ProgramBinaryRetrievableHint = GL_PROGRAM_BINARY_RETRIEVABLE_HINT,
	ProgramSeparable = GL_PROGRAM_SEPARABLE,
	TransformFeedbackBufferMode = GL_TRANSFORM_FEEDBACK_BUFFER_MODE,
	TransformFeedbackVaryings = GL_TRANSFORM_FEEDBACK_VARYINGS,
	TransformFeedbackVaryingMaxLength = GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH,
	ValidateStatus = GL_VALIDATE_STATUS
}
