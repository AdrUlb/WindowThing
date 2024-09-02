#pragma warning disable IDE0051 // Remove unused private members

using FtShort = System.Int16;
using FtPos = System.Int64;

namespace WindowThing.Bindings.FreeType;

internal readonly struct FtBitmapSize
{
#pragma warning disable CS0169 // Field is never used
	private readonly FtShort _height;
	private readonly FtShort _width;

	private readonly FtPos _size;

	private readonly FtPos _xPpem;
	private readonly FtPos _yPpem;
#pragma warning restore CS0169 // Field is never used
}
