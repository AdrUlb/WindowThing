#pragma warning disable IDE0051 // Remove unused private members

namespace WindowThing.Bindings.FreeType;

public struct FtBitmap
{
#pragma warning disable CS0169 // Field is never used
// ReSharper disable UnassignedField.Global
	public uint Rows;
	public uint Width;
	public int Pitch;
	public nint Buffer;
// ReSharper restore UnassignedField.Global
	private readonly ushort _numGrays;
	private readonly byte _pixelMode;
	private readonly byte _paletteMode;
	private readonly nint _palette;
#pragma warning restore CS0169 // Field is never used
}
