using static RenderThing.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Gl;

public enum Cap : GLenum
{
	Blend = GL_BLEND,
	CullFace = GL_CULL_FACE,
	DepthTest = GL_DEPTH_TEST,
	Dither = GL_DITHER,
	PolygonOffsetFill = GL_POLYGON_OFFSET_FILL,
	PrimitiveRestartFixedIndex = GL_PRIMITIVE_RESTART_FIXED_INDEX,
	RasterizerDiscard = GL_RASTERIZER_DISCARD,
	SampleAlphaToCoverage = GL_SAMPLE_ALPHA_TO_COVERAGE,
	SampleCoverage = GL_SAMPLE_COVERAGE,
	SampleMask = GL_SAMPLE_MASK,
	ScissorTest = GL_SCISSOR_TEST,
	StencilTest = GL_STENCIL_TEST

}
