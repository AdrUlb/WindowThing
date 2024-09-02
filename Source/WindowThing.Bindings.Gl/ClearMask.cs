using static WindowThing.Bindings.Gl.Constants;
using GLbitfield = System.UInt32;

namespace WindowThing.Bindings.Gl;

[Flags]
public enum ClearMask : GLbitfield
{
	DepthBuffer = _glDepthBufferBit,
	StencilBuffer = _glStencilBufferBit,
	ColorBuffer = _glColorBufferBit
}
