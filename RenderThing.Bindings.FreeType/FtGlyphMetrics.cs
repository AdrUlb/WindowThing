using FtPos = System.Int64;

namespace RenderThing.Bindings.FreeType;

public struct FtGlyphMetrics
{
	public FtPos width;
	public FtPos height;

	private FtPos horiBearingX;
	private FtPos horiBearingY;
	private FtPos horiAdvance;

	private FtPos vertBearingX;
	private FtPos vertBearingY;
	private FtPos vertAdvance;
}
