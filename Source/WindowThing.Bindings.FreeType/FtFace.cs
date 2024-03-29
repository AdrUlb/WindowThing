#pragma warning disable IDE0051 // Remove unused private members

using FtShort = System.Int16;
using FtUShort = System.UInt16;
using FtInt = System.Int32;
using FtLong = System.Int64;

namespace RenderThing.Bindings.FreeType;

public unsafe readonly struct FtFace
{
	public readonly FtFaceRec* Rec;
}

public readonly unsafe struct FtFaceRec
{
	private readonly FtLong num_faces;
	private readonly FtLong face_index;

	private readonly FtLong face_flags;
	private readonly FtLong style_flags;

	private readonly FtLong num_glyphs;

	private readonly nint family_name;
	private readonly nint style_name;

	private readonly FtInt num_fixed_sizes;
	private readonly FtBitmapSize* available_sizes;

	private readonly FtInt num_charmaps;
	private readonly FtCharMap* charmaps;

	private readonly FtGeneric generic;

	private readonly FtBBox bbox;

	private readonly FtUShort units_per_EM;
	private readonly FtShort ascender;
	private readonly FtShort descender;
	private readonly FtShort height;

	private readonly FtShort max_advance_width;
	private readonly FtShort max_advance_height;

	private readonly FtShort underline_position;
	private readonly FtShort underline_thickness;

	public readonly FtGlyphSlot glyph;
}
