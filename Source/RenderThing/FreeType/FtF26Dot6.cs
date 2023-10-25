namespace RenderThing.FreeType;

internal struct FtF26Dot6
{
	public long Value;

	public static implicit operator FtF26Dot6(float value) => new() { Value = (long)(value * 64.0f) };
	public static implicit operator float(FtF26Dot6 value) => value.Value / 64.0f;
	
	public static implicit operator FtF26Dot6(double value) => new() { Value = (long)(value * 64.0) };
	public static implicit operator double(FtF26Dot6 value) => value.Value / 64.0;
}
