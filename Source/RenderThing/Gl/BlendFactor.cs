using static RenderThing.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Gl;

public enum BlendFactor : GLenum
{
	Zero = GL_ZERO,
	One = GL_ONE,
	SrcColor = GL_SRC_COLOR,
	OneMinusSrcColor = GL_ONE_MINUS_SRC_COLOR,
	DstColor = GL_DST_COLOR,
	OneMinusDstColor = GL_ONE_MINUS_DST_COLOR,
	SrcAlpha = GL_SRC_ALPHA,
	OneMinusSrcAlpha = GL_ONE_MINUS_SRC_ALPHA,
	DstAlpha = GL_DST_ALPHA,
	OneMinusDstAlpha = GL_ONE_MINUS_DST_ALPHA,
	ConstantColor = GL_CONSTANT_COLOR,
	OneMinusConstantColor = GL_ONE_MINUS_CONSTANT_COLOR,
	ConstantAlpha = GL_CONSTANT_ALPHA,
	OneMinusConstantAlpha = GL_ONE_MINUS_CONSTANT_ALPHA,
	SrcAlphaSaturate = GL_SRC_ALPHA_SATURATE
}
