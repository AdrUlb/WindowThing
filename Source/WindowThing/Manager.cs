using RenderThing.Bindings.FreeType;
using RenderThing.Bindings.Glfw;
using System.Reflection;
using System.Runtime.InteropServices;

namespace RenderThing;

internal static class Manager
{
	private static bool _isInit;
	private static readonly object _initLock = new();

	private static nint _libGlfwHandle = 0;
	private static nint _libFreetypeHandle = 0;

	internal static FtLibrary FtLib;

	private static nint GlfwImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		if (libraryName != Glfw.LibraryName)
			return 0;

		if (_libGlfwHandle != 0)
			return _libGlfwHandle;

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
		var libPath = Path.Combine(AppContext.BaseDirectory, "runtimes", rid, "native", libName);

		_libGlfwHandle = NativeLibrary.Load(libPath);

		return _libGlfwHandle;
	}

	private static nint FreetypeImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		if (libraryName != Ft.LibraryName)
			return 0;

		if (_libFreetypeHandle != 0)
			return _libFreetypeHandle;

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
		var libPath = Path.Combine(AppContext.BaseDirectory, "runtimes", rid, "native", libName);

		_libFreetypeHandle = NativeLibrary.Load(libPath);

		return _libFreetypeHandle;
	}

	private static void AppDomain_CurrentDomain_ProcessExit(object? sender, EventArgs args)
	{
		Clean();
	}

	internal static void Init()
	{
		lock (_initLock)
		{
			if (_isInit)
				return;

			try
			{
				NativeLibrary.SetDllImportResolver(typeof(Glfw).Assembly, GlfwImportResolver);
				NativeLibrary.SetDllImportResolver(typeof(Ft).Assembly, FreetypeImportResolver);
			}
			catch { }

			Glfw.Init();
			Ft.InitFreeType(out FtLib);
			AppDomain.CurrentDomain.ProcessExit += AppDomain_CurrentDomain_ProcessExit;

			_isInit = true;
		}
	}

	internal static void Clean()
	{
		lock (_initLock)
		{
			if (!_isInit)
				return;

			AppDomain.CurrentDomain.ProcessExit -= AppDomain_CurrentDomain_ProcessExit;
			Ft.DoneFreeType(FtLib);
			Glfw.Terminate();

			_isInit = false;
		}
	}
}
