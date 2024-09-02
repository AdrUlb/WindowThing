namespace WindowThing.Bindings.Glfw;

public readonly struct GlfwWindowPtr
{
	private readonly nint _handle;

	public GlfwWindowPtr(nint handle) => this._handle = handle;
	
	public static implicit operator GlfwWindowPtr(nint value) => new(value);
	public static implicit operator nint(GlfwWindowPtr value) => value._handle;
}
