namespace WindowThing.Bindings.Glfw;

public readonly struct GlfwMonitorPtr
{
	private readonly nint _handle;

	public GlfwMonitorPtr(nint handle) => this._handle = handle;
	
	public static implicit operator GlfwMonitorPtr(nint value) => new(value);
	public static implicit operator nint(GlfwMonitorPtr value) => value._handle;
}
