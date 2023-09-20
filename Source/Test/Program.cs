using System.Drawing;
using System.Runtime.InteropServices;
using SdlSharp;
using ARenderer;
using Test;

nint libSdl = 0;

NativeLibrary.SetDllImportResolver(typeof(Sdl).Assembly, (name, _, _) =>
{
	if (name != Sdl.LibraryName)
		return 0;

	if (libSdl != 0)
		return libSdl;

	var libName =
		OperatingSystem.IsLinux() ? "libSDL2.so" :
		OperatingSystem.IsWindows() ? "SDL2.dll" :
		throw new PlatformNotSupportedException();

	var ridOs =
		OperatingSystem.IsLinux() ? "linux" :
		OperatingSystem.IsWindows() ? "win" :
		throw new PlatformNotSupportedException();

	var ridPlatform = RuntimeInformation.ProcessArchitecture switch
	{
		Architecture.X64 => "x64",
		Architecture.X86 => "x86",
		_ => throw new PlatformNotSupportedException()
	};

	var rid = $"{ridOs}-{ridPlatform}";
	var libPath = Path.Combine(AppContext.BaseDirectory, "runtimes", rid, libName);

	libSdl = NativeLibrary.Load(libPath);

	return libSdl;
});

Sdl.Init(SdlInitFlags.Video);

Sdl.GL_SetAttribute(SdlGlAttribute.ContextProfileMask, SdlGlProfile.Core);
Sdl.GL_SetAttribute(SdlGlAttribute.ContextMajorVersion, 3);
Sdl.GL_SetAttribute(SdlGlAttribute.ContextMinorVersion, 3);

var window = Sdl.CreateWindow("Simple Renderer Test", 640, 480, SdlWindowFlags.OpenGl | SdlWindowFlags.Shown | SdlWindowFlags.Resizable);
var context = Sdl.GL_CreateContext(window);

var open = true;

Sdl.GL_SetSwapInterval(0);

using (var renderer = new Renderer(new GlApi(Sdl.GL_GetProcAddress)))
{
	renderer.UpdateViewportSize(640, 480);
	
	while (open)
	{
		while (Sdl.PollEvent(out var ev))
		{
			switch (ev.Type)
			{
				case SdlEventType.Quit:
					open = false;
					break;
				case SdlEventType.WindowEvent:
					switch (ev.Window.Event)
					{
						case SdlWindowEventId.SizeChanged:
							Sdl.GetWindowSize(window, out var w, out var h);
							renderer.UpdateViewportSize((uint)w, (uint)h);
							break;
					}
					break;
			}
		}

		renderer.Clear(Color.Orange);

		renderer.FillRect(new(100.0f, 100.0f), new(100.0f, 100.0f), Color.Red);
		renderer.FillRect(new(150.0f, 150.0f), new(100.0f, 100.0f), Color.Green);
		renderer.FillRect(new(200.0f, 200.0f), new(100.0f, 100.0f), Color.Blue);

		renderer.BatchCommit();

		Sdl.GL_SwapWindow(window);

		//Console.WriteLine(Stopwatch.GetElapsedTime(start).TotalMilliseconds);
	}
}

Sdl.GL_DeleteContext(context);
Sdl.DestroyWindow(window);

Sdl.Quit();
