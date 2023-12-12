namespace RenderThing.Bindings.Gl.Abstractions;

public readonly struct BufferObject(Gl gl) : IDisposable
{
	public readonly uint Id = gl.GenBuffer();

	public static implicit operator uint(BufferObject obj) => obj.Id;

	public void Dispose() => gl.DeleteBuffer(Id);
}
