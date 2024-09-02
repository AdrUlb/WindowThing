using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum Cap : GLenum
{
	Blend = _glBlend,
	CullFace = _glCullFace,
	DepthTest = _glDepthTest,
	Dither = _glDither,
	PolygonOffsetFill = _glPolygonOffsetFill,
	PrimitiveRestartFixedIndex = _glPrimitiveRestartFixedIndex,
	RasterizerDiscard = _glRasterizerDiscard,
	SampleAlphaToCoverage = _glSampleAlphaToCoverage,
	SampleCoverage = _glSampleCoverage,
	SampleMask = _glSampleMask,
	ScissorTest = _glScissorTest,
	StencilTest = _glStencilTest

}
