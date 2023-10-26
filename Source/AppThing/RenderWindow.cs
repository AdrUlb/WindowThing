using GlfwSharp;
using RenderThing;
using RenderThing.Gl;
using System.Drawing;
using System.Numerics;

namespace AppThing;

public class RenderWindow : IDisposable
{
	public delegate void CloseEventHandler();
	public delegate void RenderEventHandler(Renderer renderer);

	public event CloseEventHandler? Close;

	public event RenderEventHandler? Render;

	private readonly GlfwWindowPtr glfwWindow;
	private readonly Renderer renderer;
	private readonly Glfw.FramebufferSizeFun framebufferSizeFun;
	private bool sizeChanged = false;

	private bool isDisposed = false;
	private bool keepThreadAlive = true;

	private readonly Thread thread;

	public Size Size
	{
		get
		{
			Glfw.GetWindowSize(glfwWindow, out var w, out var h);
			return new(w, h);
		}

		set => Glfw.SetWindowSize(glfwWindow, value.Width, value.Height);
	}
	
	public Vector2 ContentScale
	{
		get
		{
			Glfw.GetWindowContentScale(glfwWindow, out var xscale, out var yscale);
			return new(xscale, yscale);
		}
	}

	public RenderWindow(WindowOptions options)
	{
		GlfwManager.Init();

		Glfw.WindowHint(GlfwWindowHint.ClientApi, Glfw.OPENGL_API);
		Glfw.WindowHint(GlfwWindowHint.OpenglProfile, Glfw.OPENGL_CORE_PROFILE);
		Glfw.WindowHint(GlfwWindowHint.OpenglForwardCompat, 1);
		Glfw.WindowHint(GlfwWindowHint.ContextVersionMajor, 3);
		Glfw.WindowHint(GlfwWindowHint.ContextVersionMinor, 3);
		Glfw.WindowHint(GlfwWindowHint.Resizable, options.Resizable ? 1 : 0);
		Glfw.WindowHint(GlfwWindowHint.Visible, options.Visible ? 1 : 0);

		glfwWindow = Glfw.CreateWindow(options.Size.Width, options.Size.Height, options.Title, 0, 0);

		framebufferSizeFun = (_, w, h) => { sizeChanged = true; };

		Glfw.SetFramebufferSizeCallback(glfwWindow, framebufferSizeFun);

		Glfw.MakeContextCurrent(glfwWindow);
		Glfw.SwapInterval(0);
		renderer = new GlRenderer(new DesktopGlApi(Glfw.GetProcAddress));
		Glfw.MakeContextCurrent(0);

		sizeChanged = true;

		thread = new(ThreadProc);
		thread.Start();
	}

	~RenderWindow() => Dispose(false);

	private void ThreadProc()
	{
		Glfw.MakeContextCurrent(glfwWindow);

		while (keepThreadAlive)
		{
			Glfw.MakeContextCurrent(glfwWindow);
			Glfw.PollEvents();

			if (Glfw.WindowShouldClose(glfwWindow))
			{
				Glfw.SetWindowShouldClose(glfwWindow, false);
				Close?.Invoke();
			}

			if (sizeChanged)
			{
				sizeChanged = false;
				Glfw.GetFramebufferSize(glfwWindow, out var w, out var h);
				renderer.SetSize((uint)w, (uint)h);
			}

			Render?.Invoke(renderer);
			renderer.Commit();
			Glfw.SwapBuffers(glfwWindow);
			Glfw.MakeContextCurrent(0);
		}

		Glfw.MakeContextCurrent(0);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (isDisposed)
			return;

		keepThreadAlive = false;
		SpinWait.SpinUntil(() => !thread.IsAlive);
		Glfw.MakeContextCurrent(glfwWindow);
		renderer.Dispose();
		Glfw.DestroyWindow(glfwWindow);

		isDisposed = true;
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		Dispose(true);
	}
}
