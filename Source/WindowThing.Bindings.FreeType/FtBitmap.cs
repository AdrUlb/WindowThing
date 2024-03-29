#pragma warning disable IDE0051 // Remove unused private members

namespace RenderThing.Bindings.FreeType;

public struct FtBitmap
{
	public uint rows;
	public uint width;
	public int pitch;
	public nint buffer;
	private readonly ushort num_grays;
	private readonly byte pixel_mode;
	private readonly byte palette_mode;
	private readonly nint palette;
}
