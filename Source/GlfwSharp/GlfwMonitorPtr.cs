namespace GlfwSharp;

public readonly struct GlfwMonitorPtr
{
	private readonly nint handle;

	public GlfwMonitorPtr(nint handle) => this.handle = handle;
	
	public static implicit operator GlfwMonitorPtr(nint value) => new(value);
	public static implicit operator nint(GlfwMonitorPtr value) => value.handle;
}
