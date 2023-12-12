namespace RenderThing.Bindings.FreeType;

public struct FtBitmap
{
	public uint rows;
	public uint width;
	public int pitch;
	public nint buffer;
	private ushort num_grays;
	private byte pixel_mode;
	private byte palette_mode;
	private nint palette;
}
