#pragma warning disable IDE0051 // Remove unused private members

using FtPos = System.Int64;

namespace WindowThing.Bindings.FreeType;

internal readonly struct FtBBox
{
#pragma warning disable CS0169 // Field is never used
	private readonly FtPos _xMin, _yMin;
	private readonly FtPos _xMax, _yMax;
#pragma warning restore CS0169 // Field is never used
}
