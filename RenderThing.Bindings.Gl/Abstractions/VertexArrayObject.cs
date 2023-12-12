namespace RenderThing.Bindings.Gl.Abstractions;

public readonly struct VertexArrayObject(Gl gl) : IDisposable
{
	public readonly uint Id = gl.GenVertexArray();

	public static implicit operator uint(VertexArrayObject obj) => obj.Id;

	public void Dispose() => gl.DeleteVertexArray(Id);
}
