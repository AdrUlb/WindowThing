using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum ProgramParameterName : GLenum
{
	ActiveAtomicCounterBuffers = _glActiveAtomicCounterBuffers,
	ActiveAttributes = _glActiveAttributes,
	ActiveAttributesMaxLength = _glActiveAttributeMaxLength,
	ActiveUniforms = _glActiveUniforms,
	ActiveUniformBlocks = _glActiveUniformBlocks,
	ActiveUniformBlockMaxNameLength = _glActiveUniformBlockMaxNameLength,
	ActiveUniformMaxLength = _glActiveUniformMaxLength,
	AttachedShaders = _glAttachedShaders,
	ComputeWorkGroupSize = _glComputeWorkGroupSize,
	DeleteStatus = _glDeleteStatus,
	InfoLogLength = _glInfoLogLength,
	LinkStatus = _glLinkStatus,
	ProgramBinaryRetrievableHint = _glProgramBinaryRetrievableHint,
	ProgramSeparable = _glProgramSeparable,
	TransformFeedbackBufferMode = _glTransformFeedbackBufferMode,
	TransformFeedbackVaryings = _glTransformFeedbackVaryings,
	TransformFeedbackVaryingMaxLength = _glTransformFeedbackVaryingMaxLength,
	ValidateStatus = _glValidateStatus
}
