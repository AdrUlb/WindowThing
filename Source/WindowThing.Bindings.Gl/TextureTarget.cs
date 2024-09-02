using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum TextureTarget : GLenum
{
	Texture2D = _glTexture2D,
	Texture2DMultisample = _glTexture2DMultisample,
	Texture3D = _glTexture3D,
	Texture2DArray = _glTexture2DArray,
	TextureCubeMap = _glTextureCubeMap
}
