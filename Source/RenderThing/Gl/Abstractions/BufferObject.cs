namespace RenderThing.Gl.Abstractions;

internal readonly struct BufferObject : IDisposable
{
	private readonly IGlApi gl;
	public readonly uint Id;
    
	public BufferObject(IGlApi gl)
	{
		this.gl = gl;
		Id = gl.GenBuffer();
	}

	public void Dispose() => gl.DeleteBuffer(Id);
}
