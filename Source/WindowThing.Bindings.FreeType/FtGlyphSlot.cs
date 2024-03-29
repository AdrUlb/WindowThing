#pragma warning disable IDE0051 // Remove unused private members

using FtInt = System.Int32;
using FtUInt = System.UInt32;

namespace RenderThing.Bindings.FreeType;

public unsafe readonly struct FtGlyphSlot
{
	public readonly FtGlyphSlotRec* Rec;
}

public unsafe struct FtGlyphSlotRec
{
	private readonly FtLibrary library;
	private readonly FtFace face;
	private readonly FtGlyphSlot next;
	private readonly FtUInt glyph_index;
	private readonly FtGeneric generic;
	
	public FtGlyphMetrics metrics;
	private FtFixed linearHoriAdvance;
	private FtFixed linearVertAdvance;
	public FtVector advance;
	
	private readonly FtGlyphFormat format;
	
	public FtBitmap bitmap;
	public FtInt bitmap_left;
	public FtInt bitmap_top;
}
