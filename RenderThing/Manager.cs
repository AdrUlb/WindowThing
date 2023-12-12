using RenderThing.Bindings.FreeType;
using RenderThing.Bindings.Glfw;
using System.Reflection;
using System.Runtime.InteropServices;

namespace RenderThing;

internal static class Manager
{
	private static bool isInit;
	private static readonly object initLock = new();

	private static nint libGlfwHandle = 0;
	private static nint libFreetypeHandle = 0;

	internal static FtLibrary FtLib;

	private static nint GlfwImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		if (libraryName != Glfw.LibraryName)
			return 0;

		if (libGlfwHandle != 0)
			return libGlfwHandle;

		var (ridOs, libName) =
			OperatingSystem.IsLinux() ? ("linux", "libglfw.so.3.3") :
			OperatingSystem.IsWindows() ? ("win", "glfw3.dll") :
			throw new PlatformNotSupportedException();

		var ridPlatform = RuntimeInformation.ProcessArchitecture switch
		{
			Architecture.X64 => "x64",
			Architecture.X86 => "x86",
			_ => throw new PlatformNotSupportedException()
		};

		var rid = $"{ridOs}-{ridPlatform}";
		var libPath = Path.Combine(AppContext.BaseDirectory, "runtimes", rid, libName);

		libGlfwHandle = NativeLibrary.Load(libPath);

		return libGlfwHandle;
	}

	private static nint FreetypeImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		if (libraryName != Ft.LibraryName)
			return 0;

		if (libFreetypeHandle != 0)
			return libFreetypeHandle;

		var (ridOs, libName) =
			OperatingSystem.IsLinux() ? ("linux", "libfreetype.so") :
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

		libFreetypeHandle = NativeLibrary.Load(libPath);

		return libFreetypeHandle;
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

			NativeLibrary.SetDllImportResolver(typeof(Glfw).Assembly, GlfwImportResolver);
			NativeLibrary.SetDllImportResolver(typeof(Ft).Assembly, FreetypeImportResolver);
			Glfw.Init();
			Ft.InitFreeType(out FtLib);
			AppDomain.CurrentDomain.ProcessExit += AppDomain_CurrentDomain_ProcessExit;

			isInit = true;
		}
	}

	internal static void Clean()
	{
		lock (initLock)
		{
			if (!isInit)
				return;

			AppDomain.CurrentDomain.ProcessExit -= AppDomain_CurrentDomain_ProcessExit;
			Ft.DoneFreeType(FtLib);
			Glfw.Terminate();

			isInit = false;
		}
	}
}
