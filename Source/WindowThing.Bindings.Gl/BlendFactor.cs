using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum BlendFactor : GLenum
{
	Zero = _glZero,
	One = _glOne,
	SrcColor = _glSrcColor,
	OneMinusSrcColor = _glOneMinusSrcColor,
	DstColor = _glDstColor,
	OneMinusDstColor = _glOneMinusDstColor,
	SrcAlpha = _glSrcAlpha,
	OneMinusSrcAlpha = _glOneMinusSrcAlpha,
	DstAlpha = _glDstAlpha,
	OneMinusDstAlpha = _glOneMinusDstAlpha,
	ConstantColor = _glConstantColor,
	OneMinusConstantColor = _glOneMinusConstantColor,
	ConstantAlpha = _glConstantAlpha,
	OneMinusConstantAlpha = _glOneMinusConstantAlpha,
	SrcAlphaSaturate = _glSrcAlphaSaturate
}
