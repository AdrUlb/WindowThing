using static ARenderer.Gl.Constants;
using GLenum = System.UInt32;

namespace ARenderer.Gl;

public enum TextureTarget : GLenum
{
	Texture2D = GL_TEXTURE_2D,
	Texture2DMultisample = GL_TEXTURE_2D_MULTISAMPLE,
	Texture3D = GL_TEXTURE_3D,
	Texture2DArray = GL_TEXTURE_2D_ARRAY,
	TextureCubeMap = GL_TEXTURE_CUBE_MAP
}
