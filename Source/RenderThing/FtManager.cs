using RenderThing.FreeType;
using System.Reflection;
using System.Runtime.InteropServices;
using Ft = RenderThing.FreeType.Ft;

namespace RenderThing;

internal static class FtManager
{
	private static nint libHandle = 0;
	private static bool isInit = false;
	private static readonly object initLock = new();
	private static FtLibrary lib;

	internal static FtLibrary Lib
	{
		get
		{
			lock (initLock)
				return lib;
		}
	}

	private static nint ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		if (libraryName != Ft.LibraryName)
			return 0;

		if (libHandle != 0)
			return libHandle;

		var (ridOs, libName) =
			OperatingSystem.IsLinux() ? ("linux", "libfreetype.so.6.20.1") :
			OperatingSystem.IsWindows() ? ("win", "freetype.dll") :
			throw new PlatformNotSupportedException();

		var ridPlatform = RuntimeInformation.ProcessArchitecture switch
		{
			Architecture.X64 => "x64",
			Architecture.X86 => "x86",
			_ => throw new PlatformNotSupportedException()
		};

		var rid = $"{ridOs}-{ridPlatform}";
		var libPath = Path.Combine(AppContext.BaseDirectory, "runtimes", rid, libName);

		libHandle = NativeLibrary.Load(libPath);

		return libHandle;
	}

	private static void AppDomain_CurrentDomain_ProcessExit(object? sender, EventArgs args)
	{
		Clean();
	}

	internal static void Init()
	{
		lock (initLock)
		{
			if (isInit)
				return;

			NativeLibrary.SetDllImportResolver(typeof(Ft).Assembly, ImportResolver);
			Ft.InitFreeType(out lib);
			AppDomain.CurrentDomain.ProcessExit += AppDomain_CurrentDomain_ProcessExit;

			isInit = true;
		}
	}

	private static void Clean()
	{
		lock (initLock)
		{
			if (!isInit)
				return;

			AppDomain.CurrentDomain.ProcessExit -= AppDomain_CurrentDomain_ProcessExit;

			Ft.FtDoneFreeType(lib);

			isInit = false;
		}
	}
}
