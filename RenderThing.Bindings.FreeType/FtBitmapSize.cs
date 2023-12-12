namespace RenderThing.Bindings.FreeType;
using FtShort = System.Int16;
using FtPos = System.Int64;

internal struct FtBitmapSize
{
	private FtShort height;
	private FtShort width;

	private FtPos size;

	private FtPos x_ppem;
	private FtPos y_ppem;
}
