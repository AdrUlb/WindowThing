using System.Drawing;
using WindowThing.Bindings.Gl;

namespace WindowThing;

public sealed class Texture : IDisposable
{
	private readonly Gl _gl;
	internal readonly uint Id;

	public uint Width { get; private set; } = 0;
	public uint Height { get; private set; } = 0;

	private byte[] _pixels = [];

	private bool _dirty = true;

	public Texture()
	{
		_gl = Renderer.ThreadGl ?? throw new("No active GL context on this thread.");

		Id = _gl.GenTexture();

		_gl.BindTexture(TextureTarget.Texture2D, Id);
		_gl.TexParameteri(TextureTarget.Texture2D, TextureParameter.WrapS, (int)TextureWrap.Repeat);
		_gl.TexParameteri(TextureTarget.Texture2D, TextureParameter.WrapT, (int)TextureWrap.Repeat);
		_gl.TexParameteri(TextureTarget.Texture2D, TextureParameter.MinFilter, (int)TextureMinFilter.Nearest);
		_gl.TexParameteri(TextureTarget.Texture2D, TextureParameter.MagFilter, (int)TextureMagFilter.Nearest);
	}

	internal void CommitGlTexture()
	{
		if (!_dirty)
			return;

		_gl.BindTexture(TextureTarget.Texture2D, Id);
		_gl.TexImage2D<byte>(TextureTarget.Texture2D, 0, InternalFormat.Rgba, Width, Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, _pixels);

		_dirty = false;
	}

	public void SetSize(uint width, uint height, bool keepPixels = true)
	{
		var oldW = Width;
		var copyW = Math.Min(width, Width);
		var copyH = Math.Min(height, Height);

		Width = width;
		Height = height;
		var oldPixels = _pixels;
		_pixels = new byte[width * height * 4];

		if (keepPixels)
		{
			for (var y = 0; y < copyH; y++)
			{
				var start = y * (int)oldW * 4;
				var end = start + ((int)copyW * 4);
				oldPixels.AsSpan()[start..end].CopyTo(_pixels.AsSpan()[(y * (int)Width * 4)..]);
			}
		}
	}

	public Color this[int x, int y]
	{
		get
		{
			var i = (x + (y * Width)) * 4;
			var r = _pixels[i + 0];
			var g = _pixels[i + 1];
			var b = _pixels[i + 2];
			var a = _pixels[i + 3];
			return Color.FromArgb(a, r, g, b);
		}

		set
		{
			var i = (x + (y * Width)) * 4;
			_pixels[i + 0] = value.R;
			_pixels[i + 1] = value.G;
			_pixels[i + 2] = value.B;
			_pixels[i + 3] = value.A;
			_dirty = true;
		}
	}

	private void Dispose(bool disposing)
	{
		_gl.DeleteTexture(Id);
	}

	~Texture() => Dispose(false);

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		Dispose(true);
	}
}
