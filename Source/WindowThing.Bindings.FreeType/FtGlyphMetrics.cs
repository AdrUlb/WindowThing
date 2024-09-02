#pragma warning disable IDE0051 // Remove unused private members

using FtPos = long;

namespace WindowThing.Bindings.FreeType;

public struct FtGlyphMetrics
{
#pragma warning disable CS0169 // Field is never used
	public FtPos Width;
	public FtPos Height;

	private readonly FtPos _horiBearingX;
	private readonly FtPos _horiBearingY;
	private readonly FtPos _horiAdvance;

	private readonly FtPos _vertBearingX;
	private readonly FtPos _vertBearingY;
	private readonly FtPos _vertAdvance;
#pragma warning restore CS0169 // Field is never used
}
