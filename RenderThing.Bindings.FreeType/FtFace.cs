using FtShort = System.Int16;
using FtUShort = System.UInt16;
using FtInt = System.Int32;
using FtLong = System.Int64;

namespace RenderThing.Bindings.FreeType;

public unsafe readonly struct FtFace
{
	public readonly FtFaceRec* Rec;
}

public unsafe struct FtFaceRec
{
	private FtLong num_faces;
	private FtLong face_index;

	private FtLong face_flags;
	private FtLong style_flags;

	private FtLong num_glyphs;

	private nint family_name;
	private nint style_name;

	private FtInt num_fixed_sizes;
	private FtBitmapSize* available_sizes;

	private FtInt num_charmaps;
	private FtCharMap* charmaps;

	private FtGeneric generic;

	private FtBBox bbox;

	private FtUShort units_per_EM;
	private FtShort ascender;
	private FtShort descender;
	private FtShort height;

	private FtShort max_advance_width;
	private FtShort max_advance_height;

	private FtShort underline_position;
	private FtShort underline_thickness;

	public readonly FtGlyphSlot glyph;
}
