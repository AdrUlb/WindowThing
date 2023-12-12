using static RenderThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace RenderThing.Bindings.Gl;

public enum StringName : GLenum
{
	Extensions = GL_EXTENSIONS,
	Renderer = GL_RENDERER,
	ShadingLanguageVersion = GL_SHADING_LANGUAGE_VERSION,
	Vendor = GL_VENDOR,
	Version = GL_VERSION
}
