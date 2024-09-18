using System.Runtime.InteropServices;
using FtUInt = System.UInt32;
using FtLong = System.Int64;
using FtULong = System.UInt64;

namespace WindowThing.Bindings.FreeType;

public static partial class Ft
{
	public const string LibraryName = "freetype";

	[LibraryImport(LibraryName, EntryPoint = "FT_Init_FreeType")]
	private static partial FtError NativeInitFreeType(out FtLibrary alibrary);

	[LibraryImport(LibraryName, EntryPoint = "FT_Done_FreeType")]
	private static partial FtError NativeDoneFreeType(FtLibrary library);

	[LibraryImport(LibraryName, EntryPoint = "FT_New_Face")]
	private static partial FtError NativeNewFace(FtLibrary library, [MarshalAs(UnmanagedType.LPUTF8Str)] string filepathname, FtLong faceIndex, out FtFace aface);

	[LibraryImport(LibraryName, EntryPoint = "FT_Done_Face")]
	private static partial FtError NativeDoneFace(FtFace face);

	[LibraryImport(LibraryName, EntryPoint = "FT_Set_Char_Size")]
	private static partial FtError NativeSetCharSize(FtFace face, FtF26Dot6 charWidth, FtF26Dot6 charHeight, FtUInt horzResolution, FtUInt vertResolution);

	[LibraryImport(LibraryName, EntryPoint = "FT_Load_Char")]
	private static partial FtError NativeLoadChar(FtFace face, FtULong charCode, FtLoadFlags loadFlags);

	public static FtError InitFreeType(out FtLibrary alibrary) => NativeInitFreeType(out alibrary);
	public static FtError DoneFreeType(FtLibrary library) => NativeDoneFreeType(library);

	public static FtError NewFace(FtLibrary library, string filepathname, FtLong faceIndex, out FtFace aface) =>
		NativeNewFace(library, filepathname, faceIndex, out aface);

	public static FtError DoneFace(FtFace face) => NativeDoneFace(face);

	public static FtError SetCharSize(FtFace face, FtF26Dot6 charWidth, FtF26Dot6 charHeight, FtUInt horzResolution, FtUInt vertResolution) =>
		NativeSetCharSize(face, charWidth, charHeight, horzResolution, vertResolution);

	public static FtError LoadChar(FtFace face, FtULong charCode, FtLoadFlags loadFlags) => NativeLoadChar(face, charCode, loadFlags);
}
