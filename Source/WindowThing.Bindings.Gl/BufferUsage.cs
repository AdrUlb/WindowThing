using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum BufferUsage : GLenum
{
	StreamDraw = _glStreamDraw,
	StreamRead = _glStreamRead, 
	SteamCopy = _glStreamCopy, 
	StaticDraw = _glStaticDraw, 
	StaticRead = _glStaticRead, 
	StaticCopy = _glStaticCopy, 
	DynamicDraw = _glDynamicDraw, 
	DynamicRead = _glDynamicRead, 
	DynamicCopy = _glDynamicCopy
}
