namespace WindowThing.Bindings.FreeType;

public readonly struct FtLibrary
{
	private readonly nint _handle;

	public FtLibrary(nint handle) => this._handle = handle;
	
	public static implicit operator FtLibrary(nint value) => new(value);
	public static implicit operator nint(FtLibrary value) => value._handle;
}
