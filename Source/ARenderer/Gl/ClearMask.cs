using static ARenderer.Gl.Constants;
using GLbitfield = System.UInt32;

namespace ARenderer.Gl;

[Flags]
public enum ClearMask : GLbitfield
{
	DepthBuffer = GL_DEPTH_BUFFER_BIT,
	StencilBuffer = GL_STENCIL_BUFFER_BIT,
	ColorBuffer = GL_COLOR_BUFFER_BIT
}
