using System.Runtime.InteropServices;
using System.Text;

namespace WindowThing.Bindings.Glfw;

public static partial class Glfw
{
	public const string LibraryName = "glfw";

	public const int Focused = 0x00020001;
	public const int Resizable = 0x00020003;
	public const int Visible = 0x00020004;
	public const int Decorated = 0x00020005;
	public const int AutoIconify = 0x00020006;
	public const int Floating = 0x00020007;
	public const int Maximized = 0x00020008;
	public const int CenterCursor = 0x00020009;
	public const int TransparentFramebuffer = 0x0002000A;
	public const int FocusOnShow = 0x0002000C;
	public const int RedBits = 0x00021001;
	public const int GreenBits = 0x00021002;
	public const int BlueBits = 0x00021003;
	public const int AlphaBits = 0x00021004;
	public const int DepthBits = 0x00021005;
	public const int StencilBits = 0x00021006;
	public const int AccumRedBits = 0x00021007;
	public const int AccumGreenBits = 0x00021008;
	public const int AccumBlueBits = 0x00021009;
	public const int AccumAlphaBits = 0x0002100A;
	public const int AuxBuffers = 0x0002100B;
	public const int Stereo = 0x0002100C;
	public const int Samples = 0x0002100D;
	public const int SrgbCapable = 0x0002100E;
	public const int RefreshRate = 0x0002100F;
	public const int Doublebuffer = 0x00021010;
	public const int ClientApi = 0x00022001;
	public const int ContextVersionMajor = 0x00022002;
	public const int ContextVersionMinor = 0x00022003;
	public const int ContextRobustness = 0x00022005;
	public const int OpenglForwardCompat = 0x00022006;
	public const int OpenglDebugContext = 0x00022007;
	public const int OpenglProfile = 0x00022008;
	public const int ContextReleaseBehavior = 0x00022009;
	public const int ContextCreationApi = 0x0002200B;
	public const int ScaleToMonitor = 0x0002200C;

	public const int CocoaRetinaFramebuffer = 0x00023001;
	public const int CocoaFrameName = 0x00023002;
	public const int CocoaGraphicsSwitching = 0x00023003;

	public const int X11ClassName = 0x00024001;
	public const int X11InstanceName = 0x00024002;

	public const int NoApi = 0;
	public const int OpenglApi = 0x00030001;
	public const int OpenglEsApi = 0x00030002;

	public const int OpenglAnyProfile = 0;
	public const int OpenglCoreProfile = 0x00032001;
	public const int OpenglCompatProfile = 0x00032002;

	public const int AnyReleaseBehavior = 0;
	public const int ReleaseBehaviorFlush = 0x00035001;
	public const int ReleaseBehaviorNone = 0x00035002;

	public delegate void FramebufferSizeFun(GlfwWindowPtr window, int width, int height);
	public delegate void WindowCloseFun(GlfwWindowPtr window);
	public delegate void MouseButtonFun(GlfwWindowPtr window, int button, GlfwMouseButtonAction action, GlfwModifierKeys mods);
	public delegate void CursorPosFun(GlfwWindowPtr window, double xpos, double ypos);
	public delegate void KeyFun(GlfwWindowPtr window, int key, int scancode, GlfwKeyAction action, GlfwModifierKeys mods);

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

	[LibraryImport(LibraryName, EntryPoint = "glfwSetMouseButtonCallback")]
	private static partial MouseButtonFun NativeSetMouseButtonCallback(GlfwWindowPtr window, MouseButtonFun callback);

	[LibraryImport(LibraryName, EntryPoint = "glfwSetCursorPosCallback")]
	private static partial CursorPosFun NativeSetCursorPosCallback(GlfwWindowPtr window, CursorPosFun callback);

	[LibraryImport(LibraryName, EntryPoint = "glfwSetKeyCallback")]
	private static partial KeyFun NativeSetKeyCallback(GlfwWindowPtr window, KeyFun callback);

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

	public static MouseButtonFun SetMouseButtonCallback(GlfwWindowPtr window, MouseButtonFun callback) => NativeSetMouseButtonCallback(window, callback);

	public static CursorPosFun SetCursorPosCallback(GlfwWindowPtr window, CursorPosFun callback) => NativeSetCursorPosCallback(window, callback);

	public static KeyFun SetKeyCallback(GlfwWindowPtr window, KeyFun callback) => NativeSetKeyCallback(window, callback);

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
		for (; strPtr[descLen] != 0; descLen++) { }

		description = Encoding.UTF8.GetString(strPtr, descLen);

		return code;
	}

	public static void SetWindowTitle(GlfwWindowPtr window, string title) => NativeSetWindowTitle(window, title);
}
