using static ARenderer.Gl.Constants;
using GLenum = System.UInt32;

namespace ARenderer.Gl;

public enum TextureParameter : GLenum
{
	DepthStencilMode = GL_DEPTH_STENCIL_TEXTURE_MODE,
	BaseLevel = GL_TEXTURE_BASE_LEVEL,
	CompareFunc = GL_TEXTURE_COMPARE_FUNC,
	CompareMode = GL_TEXTURE_COMPARE_MODE,
	MinFilter = GL_TEXTURE_MIN_FILTER,
	MagFilter = GL_TEXTURE_MAG_FILTER,
	MinLod = GL_TEXTURE_MIN_LOD,
	MaxLod = GL_TEXTURE_MAX_LOD,
	TextureMaxLevel = GL_TEXTURE_MAX_LEVEL,
	TextureSwizzleR = GL_TEXTURE_SWIZZLE_R,
	TextureSwizzleG = GL_TEXTURE_SWIZZLE_G,
	TextureSwizzleB = GL_TEXTURE_SWIZZLE_B,
	TextureSwizzleA = GL_TEXTURE_SWIZZLE_A,
	WrapS = GL_TEXTURE_WRAP_S,
	WrapT = GL_TEXTURE_WRAP_T,
	WrapR = GL_TEXTURE_WRAP_R
}
