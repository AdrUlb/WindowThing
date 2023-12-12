namespace RenderThing.Bindings.FreeType;

public readonly struct FtLibrary
{
	private readonly nint handle;

	public FtLibrary(nint handle) => this.handle = handle;
	
	public static implicit operator FtLibrary(nint value) => new(value);
	public static implicit operator nint(FtLibrary value) => value.handle;
}
