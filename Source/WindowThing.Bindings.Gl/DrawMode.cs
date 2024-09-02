using static WindowThing.Bindings.Gl.Constants;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public enum DrawMode : GLenum
{
	Points = _glPoints,
	LineStrip = _glLineStrip,
	LineLoop = _glLineLoop,
	Lines = _glLines,
	TriangleStrip = _glTriangleStrip,
	TriangleFan = _glTriangleFan,
	Triangles = _glTriangles
}
