#pragma warning disable IDE0051 // Remove unused private members

using FtInt = System.Int32;
using FtUInt = System.UInt32;

namespace WindowThing.Bindings.FreeType;

public unsafe readonly struct FtGlyphSlot
{
	// ReSharper disable once UnassignedReadonlyField
	public readonly FtGlyphSlotRec* Rec;
}

public struct FtGlyphSlotRec
{
#pragma warning disable CS0169 // Field is never used
	private readonly FtLibrary _library;
	private readonly FtFace _face;
	private readonly FtGlyphSlot _next;
	private readonly FtUInt _glyphIndex;
	private readonly FtGeneric _generic;

	public FtGlyphMetrics Metrics;
	private FtFixed _linearHoriAdvance;
	private FtFixed _linearVertAdvance;
// ReSharper disable UnassignedField.Global
	public FtVector Advance;

	private readonly FtGlyphFormat _format;

	public FtBitmap Bitmap;
	public FtInt BitmapLeft;
	public FtInt BitmapTop;
// ReSharper restore UnassignedField.Global
#pragma warning restore CS0169 // Field is never used
}
