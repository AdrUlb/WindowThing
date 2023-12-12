using FtInt = System.Int32;
using FtUInt = System.UInt32;

namespace RenderThing.Bindings.FreeType;

public unsafe readonly struct FtGlyphSlot
{
	public readonly FtGlyphSlotRec* Rec;
}

public unsafe struct FtGlyphSlotRec
{
	private FtLibrary library;
	private FtFace face;
	private FtGlyphSlot next;
	private FtUInt glyph_index;
	private FtGeneric generic;
	
	public FtGlyphMetrics metrics;
	private FtFixed linearHoriAdvance;
	private FtFixed linearVertAdvance;
	public FtVector advance;
	
	private FtGlyphFormat format;
	
	public FtBitmap bitmap;
	public FtInt bitmap_left;
	public FtInt bitmap_top;
}
