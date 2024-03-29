#pragma warning disable IDE0051 // Remove unused private members

using FtPos = System.Int64;

namespace RenderThing.Bindings.FreeType;

public struct FtGlyphMetrics
{
	public FtPos width;
	public FtPos height;

	private readonly FtPos horiBearingX;
	private readonly FtPos horiBearingY;
	private readonly FtPos horiAdvance;

	private readonly FtPos vertBearingX;
	private readonly FtPos vertBearingY;
	private readonly FtPos vertAdvance;
}
