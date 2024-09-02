namespace WindowThing.Bindings.Gl.Abstractions;

public readonly struct ShaderObject : IDisposable
{
	private readonly Gl _gl;
	private readonly uint _id;

	public ShaderObject(Gl gl, ShaderType type, string source)
	{
		this._gl = gl;
		_id = gl.CreateShader(type);
		gl.ShaderSource(_id, source);
		gl.CompileShader(_id);
		if (gl.GetShaderiv(_id, ShaderParameterName.CompileStatus) == 0)
			throw new($"Failed to compile shader: {gl.GetShaderInfoLog(_id)}");
	}

	internal void Attach(uint programId) => _gl.AttachShader(programId, _id);

	internal void Detach(uint programId) => _gl.DetachShader(programId, _id);

	public void Dispose() => _gl.DeleteShader(_id);
}
