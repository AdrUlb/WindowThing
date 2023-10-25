using GlfwSharp;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AppThing;

internal static class GlfwManager
{
	private static readonly List<Window> windows = new();
	private static readonly object windowsLock = new();

	private static nint libHandle = 0;
	private static bool isInit = false;
	private static readonly object initLock = new();

	private static nint ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		if (libraryName != Glfw.LibraryName)
			return 0;

		if (libHandle != 0)
			return libHandle;

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

			NativeLibrary.SetDllImportResolver(typeof(Glfw).Assembly, ImportResolver);
			Glfw.Init();
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

			Glfw.Terminate();

			isInit = false;
		}
	}

	internal static void RegisterWindow(Window window)
	{
		lock (windowsLock)
			windows.Add(window);
	}

	internal static void UnregisterWindow(Window window)
	{
		lock (windowsLock)
			windows.Remove(window);
	}
}
