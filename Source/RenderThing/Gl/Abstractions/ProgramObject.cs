using System.Numerics;

namespace RenderThing.Gl.Abstractions;

internal readonly struct ProgramObject : IDisposable
{
	private readonly IGlApi gl;
	private readonly uint id;

	public ProgramObject(IGlApi gl, params ShaderObject[] shaders)
	{
		this.gl = gl;
		id = gl.CreateProgram();
		foreach (var s in shaders)
			s.Attach(id);
		
		gl.LinkProgram(id);
		if (gl.GetProgramiv(id, ProgramParameterName.LinkStatus) == 0)
			throw new($"Failed to link shader program: {gl.GetProgramInfoLog(id)}");

		foreach (var s in shaders)
			s.Detach(id);
	}

	public int GetUniformLocation(string name)
	{
		return gl.GetUniformLocation(id, name);
	}

	public void UniformMatrix4(int location, uint count, bool transpose, in Matrix4x4 value)
	{
		Use();
		gl.UniformMatrix4fv(location, count, transpose, value);
	}

	public void Uniform1iv(int location, ReadOnlySpan<int> value)
	{
		Use();
		gl.Uniform1iv(location, value);
	}

	public void Use() => gl.UseProgram(id);

	public void Dispose() => gl.DeleteProgram(id);
}
