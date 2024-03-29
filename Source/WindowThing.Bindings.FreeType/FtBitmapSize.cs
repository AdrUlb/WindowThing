#pragma warning disable IDE0051 // Remove unused private members

using FtShort = System.Int16;
using FtPos = System.Int64;

namespace RenderThing.Bindings.FreeType;

internal readonly struct FtBitmapSize
{
	private readonly FtShort height;
	private readonly FtShort width;

	private readonly FtPos size;

	private readonly FtPos x_ppem;
	private readonly FtPos y_ppem;
}
