using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum TextureParameter : GLenum
{
	DepthStencilMode = _glDepthStencilTextureMode,
	BaseLevel = _glTextureBaseLevel,
	CompareFunc = _glTextureCompareFunc,
	CompareMode = _glTextureCompareMode,
	MinFilter = _glTextureMinFilter,
	MagFilter = _glTextureMagFilter,
	MinLod = _glTextureMinLod,
	MaxLod = _glTextureMaxLod,
	TextureMaxLevel = _glTextureMaxLevel,
	TextureSwizzleR = _glTextureSwizzleR,
	TextureSwizzleG = _glTextureSwizzleG,
	TextureSwizzleB = _glTextureSwizzleB,
	TextureSwizzleA = _glTextureSwizzleA,
	WrapS = _glTextureWrapS,
	WrapT = _glTextureWrapT,
	WrapR = _glTextureWrapR
}
