namespace RenderThing.Bindings.Glfw;

public readonly struct GlfwWindowPtr
{
	private readonly nint handle;

	public GlfwWindowPtr(nint handle) => this.handle = handle;
	
	public static implicit operator GlfwWindowPtr(nint value) => new(value);
	public static implicit operator nint(GlfwWindowPtr value) => value.handle;
}
