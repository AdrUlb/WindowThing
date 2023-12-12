using System.Runtime.InteropServices;
using System.Text;

namespace RenderThing.Bindings.Glfw;

public static partial class Glfw
{
	public const string LibraryName = "glfw";

	public const int FOCUSED = 0x00020001;
	public const int RESIZABLE = 0x00020003;
	public const int VISIBLE = 0x00020004;
	public const int DECORATED = 0x00020005;
	public const int AUTO_ICONIFY = 0x00020006;
	public const int FLOATING = 0x00020007;
	public const int MAXIMIZED = 0x00020008;
	public const int CENTER_CURSOR = 0x00020009;
	public const int TRANSPARENT_FRAMEBUFFER = 0x0002000A;
	public const int FOCUS_ON_SHOW = 0x0002000C;
	public const int RED_BITS = 0x00021001;
	public const int GREEN_BITS = 0x00021002;
	public const int BLUE_BITS = 0x00021003;
	public const int ALPHA_BITS = 0x00021004;
	public const int DEPTH_BITS = 0x00021005;
	public const int STENCIL_BITS = 0x00021006;
	public const int ACCUM_RED_BITS = 0x00021007;
	public const int ACCUM_GREEN_BITS = 0x00021008;
	public const int ACCUM_BLUE_BITS = 0x00021009;
	public const int ACCUM_ALPHA_BITS = 0x0002100A;
	public const int AUX_BUFFERS = 0x0002100B;
	public const int STEREO = 0x0002100C;
	public const int SAMPLES = 0x0002100D;
	public const int SRGB_CAPABLE = 0x0002100E;
	public const int REFRESH_RATE = 0x0002100F;
	public const int DOUBLEBUFFER = 0x00021010;
	public const int CLIENT_API = 0x00022001;
	public const int CONTEXT_VERSION_MAJOR = 0x00022002;
	public const int CONTEXT_VERSION_MINOR = 0x00022003;
	public const int CONTEXT_ROBUSTNESS = 0x00022005;
	public const int OPENGL_FORWARD_COMPAT = 0x00022006;
	public const int OPENGL_DEBUG_CONTEXT = 0x00022007;
	public const int OPENGL_PROFILE = 0x00022008;
	public const int CONTEXT_RELEASE_BEHAVIOR = 0x00022009;
	public const int CONTEXT_CREATION_API = 0x0002200B;
	public const int SCALE_TO_MONITOR = 0x0002200C;

	public const int COCOA_RETINA_FRAMEBUFFER = 0x00023001;
	public const int COCOA_FRAME_NAME = 0x00023002;
	public const int COCOA_GRAPHICS_SWITCHING = 0x00023003;

	public const int X11_CLASS_NAME = 0x00024001;
	public const int X11_INSTANCE_NAME = 0x00024002;

	public const int NO_API = 0;
	public const int OPENGL_API = 0x00030001;
	public const int OPENGL_ES_API = 0x00030002;

	public const int OPENGL_ANY_PROFILE = 0;
	public const int OPENGL_CORE_PROFILE = 0x00032001;
	public const int OPENGL_COMPAT_PROFILE = 0x00032002;

	public const int ANY_RELEASE_BEHAVIOR = 0;
	public const int RELEASE_BEHAVIOR_FLUSH = 0x00035001;
	public const int RELEASE_BEHAVIOR_NONE = 0x00035002;

	public delegate void FramebufferSizeFun(GlfwWindowPtr window, int width, int height);
	public delegate void WindowCloseFun(GlfwWindowPtr window);

	[LibraryImport(LibraryName, EntryPoint = "glfwInit")]
	private static partial int NativeInit();

	[LibraryImport(LibraryName, EntryPoint = "glfwTerminate")]
	private static partial void NativeTerminate();

	[LibraryImport(LibraryName, EntryPoint = "glfwCreateWindow")]
	private static partial GlfwWindowPtr NativeCreateWindow(int width, int height, [MarshalAs(UnmanagedType.LPUTF8Str)] string title, GlfwMonitorPtr monitor,
		GlfwWindowPtr share);

	[LibraryImport(LibraryName, EntryPoint = "glfwDestroyWindow")]
	private static partial void NativeDestroyWindow(GlfwWindowPtr window);

	[LibraryImport(LibraryName, EntryPoint = "glfwGetWindowSize")]
	private static partial void NativeGetWindowSize(GlfwWindowPtr window, out int width, out int height);

	[LibraryImport(LibraryName, EntryPoint = "glfwSetWindowSize")]
	private static partial void NativeSetWindowSize(GlfwWindowPtr window, int width, int height);

	[LibraryImport(LibraryName, EntryPoint = "glfwWindowShouldClose")]
	private static partial int NativeWindowShouldClose(GlfwWindowPtr window);

	[LibraryImport(LibraryName, EntryPoint = "glfwSetWindowShouldClose")]
	private static partial void NativeSetWindowShouldClose(GlfwWindowPtr window, int value);

	[LibraryImport(LibraryName, EntryPoint = "glfwGetFramebufferSize")]
	private static partial void NativeGetFramebufferSize(GlfwWindowPtr window, out int width, out int height);

	[LibraryImport(LibraryName, EntryPoint = "glfwSetFramebufferSizeCallback")]
	private static partial FramebufferSizeFun NativeSetFramebufferSizeCallback(GlfwWindowPtr window, FramebufferSizeFun callback);

	[LibraryImport(LibraryName, EntryPoint = "glfwSetWindowCloseCallback")]
	private static partial WindowCloseFun NativeSetWindowCloseCallback(GlfwWindowPtr window, WindowCloseFun callback);

	[LibraryImport(LibraryName, EntryPoint = "glfwWindowHint")]
	private static partial void NativeWindowHint(GlfwWindowHint hint, int value);

	[LibraryImport(LibraryName, EntryPoint = "glfwGetWindowContentScale")]
	private static partial void NativeGetWindowContentScale(GlfwWindowPtr window, out float xscale, out float yscale);

	[LibraryImport(LibraryName, EntryPoint = "glfwMakeContextCurrent")]
	private static partial void NativeMakeContextCurrent(GlfwWindowPtr window);

	[LibraryImport(LibraryName, EntryPoint = "glfwGetCurrentContext")]
	private static partial GlfwWindowPtr NativeGetCurrentContext();

	[LibraryImport(LibraryName, EntryPoint = "glfwPollEvents")]
	private static partial void NativePollEvents();

	[LibraryImport(LibraryName, EntryPoint = "glfwSwapBuffers")]
	private static partial void NativeSwapBuffers(GlfwWindowPtr window);

	[LibraryImport(LibraryName, EntryPoint = "glfwShowWindow")]
	private static partial void NativeShowWindow(GlfwWindowPtr window);

	[LibraryImport(LibraryName, EntryPoint = "glfwHideWindow")]
	private static partial void NativeHideWindow(GlfwWindowPtr window);

	[LibraryImport(LibraryName, EntryPoint = "glfwSwapInterval")]
	private static partial void NativeSwapInterval(int interval);

	[LibraryImport(LibraryName, EntryPoint = "glfwGetProcAddress")]
	private static partial nint NativeGetProcAddress([MarshalAs(UnmanagedType.LPUTF8Str)] string procname);

	[LibraryImport(LibraryName, EntryPoint = "glfwGetError")]
	private static unsafe partial int NativeGetError(byte** description);

	[LibraryImport(LibraryName, EntryPoint = "glfwSetWindowTitle")]
	private static unsafe partial void NativeSetWindowTitle(GlfwWindowPtr window, [MarshalAs(UnmanagedType.LPUTF8Str)] string title);

	public static bool Init() => NativeInit() != 0;
	public static void Terminate() => NativeTerminate();

	public static GlfwWindowPtr CreateWindow(int width, int height, string title, GlfwMonitorPtr monitor, GlfwWindowPtr share) =>
		NativeCreateWindow(width, height, title, monitor, share);

	public static void DestroyWindow(GlfwWindowPtr window) => NativeDestroyWindow(window);
	public static void GetWindowSize(GlfwWindowPtr window, out int width, out int height) => NativeGetWindowSize(window, out width, out height);
	public static void SetWindowSize(GlfwWindowPtr window, int width, int height) => NativeSetWindowSize(window, width, height);
	public static bool WindowShouldClose(GlfwWindowPtr window) => NativeWindowShouldClose(window) != 0;

	public static void SetWindowShouldClose(GlfwWindowPtr window, bool value) => NativeSetWindowShouldClose(window, value ? 1 : 0);
	public static void GetFramebufferSize(GlfwWindowPtr window, out int width, out int height) => NativeGetFramebufferSize(window, out width, out height);

	public static FramebufferSizeFun SetFramebufferSizeCallback(GlfwWindowPtr window, FramebufferSizeFun callback) =>
		NativeSetFramebufferSizeCallback(window, callback);

	public static WindowCloseFun SetWindowCloseCallback(GlfwWindowPtr window, WindowCloseFun callback) =>
		NativeSetWindowCloseCallback(window, callback);

	public static void WindowHint(GlfwWindowHint hint, int value) => NativeWindowHint(hint, value);

	public static void GetWindowContentScale(GlfwWindowPtr window, out float xscale, out float yscale) =>
		NativeGetWindowContentScale(window, out xscale, out yscale);

	public static void MakeContextCurrent(GlfwWindowPtr window) => NativeMakeContextCurrent(window);
	public static GlfwWindowPtr GetCurrentContext() => NativeGetCurrentContext();

	public static void PollEvents() => NativePollEvents();

	public static void ShowWindow(GlfwWindowPtr window) => NativeShowWindow(window);
	public static void HideWindow(GlfwWindowPtr window) => NativeHideWindow(window);
	public static void SwapBuffers(GlfwWindowPtr window) => NativeSwapBuffers(window);
	public static void SwapInterval(int interval) => NativeSwapInterval(interval);
	public static nint GetProcAddress(string procname) => NativeGetProcAddress(procname);

	public static unsafe int GetError(out string description)
	{
		byte* strPtr;

		var code = NativeGetError(&strPtr);

		var descLen = 0;
		for (; strPtr[descLen] != 0; descLen++)
			;

		description = Encoding.UTF8.GetString(strPtr, descLen);

		return code;
	}

	public static unsafe void SetWindowTitle(GlfwWindowPtr window, string title) => NativeSetWindowTitle(window, title);
}

