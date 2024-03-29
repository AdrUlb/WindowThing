#pragma warning disable IDE0051 // Remove unused private members

using FtPos = System.Int64;

namespace RenderThing.Bindings.FreeType;

internal readonly struct FtBBox
{
	private readonly FtPos xMin, yMin;
	private readonly FtPos xMax, yMax;
}
