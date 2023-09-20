using ARenderer.Gl;

namespace ARenderer.GlAbstractions;

internal readonly struct ShaderObject : IDisposable
{
	private readonly IGlApi gl;
	private readonly uint id;

	public ShaderObject(IGlApi gl, ShaderType type, string source)
	{
		this.gl = gl;
		id = gl.CreateShader(type);
		gl.ShaderSource(id, source);
		gl.CompileShader(id);
		if (gl.GetShaderiv(id, ShaderParameterName.CompileStatus) == 0)
			throw new($"Failed to compile shader: {gl.GetShaderInfoLog(id)}");
	}

	internal void Attach(uint programId) => gl.AttachShader(programId, id);

	internal void Detach(uint programId) => gl.DetachShader(programId, id);

	public void Dispose() => gl.DeleteShader(id);
}
