namespace RenderThing.FreeType;

internal struct FtFixed
{
	public long Value;

	public static implicit operator FtFixed(float value) => new() { Value = (long)(value * 65536.0f) };
	public static implicit operator float(FtFixed value) => value.Value / 65536.0f;
	
	public static implicit operator FtFixed(double value) => new() { Value = (long)(value * 65536.0) };
	public static implicit operator double(FtFixed value) => value.Value / 65536.0;
}
