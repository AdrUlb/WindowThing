using System.Numerics;

namespace WindowThing.Bindings.Gl.Abstractions;

public readonly struct ProgramObject : IDisposable
{
	private readonly Gl _gl;
	private readonly uint _id;

	public ProgramObject(Gl gl, params ShaderObject[] shaders)
	{
		this._gl = gl;
		_id = gl.CreateProgram();
		foreach (var s in shaders)
			s.Attach(_id);
		
		gl.LinkProgram(_id);
		if (gl.GetProgramIv(_id, ProgramParameterName.LinkStatus) == 0)
			throw new($"Failed to link shader program: {gl.GetProgramInfoLog(_id)}");

		foreach (var s in shaders)
			s.Detach(_id);
	}

	public int GetUniformLocation(string name)
	{
		return _gl.GetUniformLocation(_id, name);
	}

	public void UniformMatrix4(int location, uint count, bool transpose, in Matrix4x4 value)
	{
		Use();
		_gl.UniformMatrix4Fv(location, count, transpose, value);
	}

	public void Uniform1Iv(int location, ReadOnlySpan<int> value)
	{
		Use();
		_gl.Uniform1Iv(location, value);
	}

	public void Use() => _gl.UseProgram(_id);

	public void Dispose() => _gl.DeleteProgram(_id);
}
