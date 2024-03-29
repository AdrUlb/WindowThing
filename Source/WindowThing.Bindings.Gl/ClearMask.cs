using static RenderThing.Bindings.Gl.Constants;
using GLbitfield = System.UInt32;

namespace RenderThing.Bindings.Gl;

[Flags]
public enum ClearMask : GLbitfield
{
	DepthBuffer = GL_DEPTH_BUFFER_BIT,
	StencilBuffer = GL_STENCIL_BUFFER_BIT,
	ColorBuffer = GL_COLOR_BUFFER_BIT
}
