using RenderThing.Bindings.Gl;
using RenderThing.Bindings.Glfw;
using System.Drawing;

namespace RenderThing;

public abstract class Window : IDisposable
{
	private readonly GlfwWindowPtr _glfwWindow;
	private readonly Renderer renderer;

	private bool _running = false;

	private readonly Glfw.WindowCloseFun _closeFun;
	private readonly Glfw.FramebufferSizeFun _frameBufferSizeFun;

	private string _title;
	private bool _isVisible;

	public string Title
	{
		get => _title;
		set
		{
			_title = value;
			Glfw.SetWindowTitle(_glfwWindow, _title);
		}
	}

	public Size Size
	{
		get
		{
			Glfw.GetWindowSize(_glfwWindow, out var w, out var h);
			return new(w, h);
		}

		set => Glfw.SetWindowSize(_glfwWindow, value.Width, value.Height);
	}

	public bool IsVisible
	{
		get => _isVisible;
		set
		{
			_isVisible = value;
			if (value)
				Glfw.ShowWindow(_glfwWindow);
			else
				Glfw.HideWindow(_glfwWindow);
		}
	}

	public Window(bool resizable = true, bool visible = true)
	{
		Manager.Init();

		Glfw.WindowHint(GlfwWindowHint.ClientApi, Glfw.OPENGL_API);
		Glfw.WindowHint(GlfwWindowHint.OpenglProfile, Glfw.OPENGL_CORE_PROFILE);
		Glfw.WindowHint(GlfwWindowHint.OpenglForwardCompat, 1);
		Glfw.WindowHint(GlfwWindowHint.ContextVersionMajor, 3);
		Glfw.WindowHint(GlfwWindowHint.ContextVersionMinor, 3);
		Glfw.WindowHint(GlfwWindowHint.Resizable, resizable ? 1 : 0);
		Glfw.WindowHint(GlfwWindowHint.Visible, 0);

		_glfwWindow = Glfw.CreateWindow(400, 400, "", 0, 0);
		Glfw.MakeContextCurrent(_glfwWindow);
		Glfw.SwapInterval(0);

		Glfw.SetWindowCloseCallback(_glfwWindow, _closeFun = _ => OnCloseClicked());

		Title = _title = "RenderThing Window";
		Size = new(640, 480);

		renderer = new(new DesktopGl(Glfw.GetProcAddress));
		renderer.SetViewportSize((uint)Size.Width, (uint)Size.Height);

		Glfw.MakeContextCurrent(0);

		Glfw.SetFramebufferSizeCallback(_glfwWindow, _frameBufferSizeFun = (_, w, h) => HandleFramebufferResize(w, h));

		IsVisible = visible;
	}

	public void Run()
	{
		if (_running)
			return;

		_running = true;

		Glfw.MakeContextCurrent(_glfwWindow);
		Glfw.GetFramebufferSize(_glfwWindow, out var w, out var h);
		renderer.SetViewportSize((uint)w, (uint)h);
		OnRun();
		while (_running)
		{
			Glfw.PollEvents();
			OnRender(renderer);
			renderer.Commit();
			Glfw.SwapBuffers(_glfwWindow);
		}
		OnStop();
		Glfw.MakeContextCurrent(0);
	}

	public void Stop()
	{
		_running = false;
	}

	private void HandleFramebufferResize(int width, int height)
	{
		renderer.SetViewportSize((uint)width, (uint)height);
	}

	protected abstract void OnRun();

	protected abstract void OnStop();

	protected abstract void OnCloseClicked();

	protected abstract void OnRender(Renderer renderer);

	protected virtual void Dispose(bool disposing)
	{
		Glfw.MakeContextCurrent(_glfwWindow);
		renderer.Dispose();
		Glfw.MakeContextCurrent(0);
		Glfw.DestroyWindow(_glfwWindow);
	}

	~Window() => Dispose(false);

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		Dispose(true);
	}
}
