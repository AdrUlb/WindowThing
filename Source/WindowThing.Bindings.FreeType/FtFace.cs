#pragma warning disable IDE0051 // Remove unused private members

using FtShort = System.Int16;
using FtUShort = System.UInt16;
using FtInt = System.Int32;
using FtLong = System.Int64;

namespace WindowThing.Bindings.FreeType;

public unsafe readonly struct FtFace
{
	// ReSharper disable once UnassignedReadonlyField
	public readonly FtFaceRec* Rec;
}

public unsafe readonly struct FtFaceRec
{
#pragma warning disable CS0169 // Field is never used
	private readonly FtLong _numFaces;
	private readonly FtLong _faceIndex;

	private readonly FtLong _faceFlags;
	private readonly FtLong _styleFlags;

	private readonly FtLong _numGlyphs;

	private readonly nint _familyName;
	private readonly nint _styleName;

	private readonly FtInt _numFixedSizes;
	private readonly FtBitmapSize* _availableSizes;

	private readonly FtInt _numCharmaps;
	private readonly FtCharMap* _charmaps;

	private readonly FtGeneric _generic;

	private readonly FtBBox _bbox;

	private readonly FtUShort _unitsPerEm;
	private readonly FtShort _ascender;
	private readonly FtShort _descender;
	private readonly FtShort _height;

	private readonly FtShort _maxAdvanceWidth;
	private readonly FtShort _maxAdvanceHeight;

	private readonly FtShort _underlinePosition;
	private readonly FtShort _underlineThickness;

	// ReSharper disable once UnassignedReadonlyField
	public readonly FtGlyphSlot Glyph;
#pragma warning restore CS0169 // Field is never used
}
