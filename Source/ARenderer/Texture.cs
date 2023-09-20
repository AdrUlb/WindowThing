using System.Drawing;

namespace ARenderer;

public sealed class Texture : IDisposable
{
	public readonly uint Width;
	public readonly uint Height;
	
	internal readonly byte[] pixels;

	internal event EventHandler? Disposing;
	internal event EventHandler? Changed;
	
	public Texture(uint width, uint height)
	{
		Width = width;
		Height = height;
		pixels = new byte[width * height * 4];
	}

	public void SetColor(int x, int y, byte r, byte g, byte b, byte a)
	{
		if (x < 0 || y < 0 || x >= Width || y >= Height)
			throw new IndexOutOfRangeException();

		var offset = (x + y * Width) * 4;

		pixels[offset] = r;
		pixels[offset + 1] = g;
		pixels[offset + 2] = b;
		pixels[offset + 3] = a;

		Changed?.Invoke(this, EventArgs.Empty);
	}

	public void SetColor(int x, int y, Color color) => SetColor(x, y, color.R, color.G, color.B, color.A);
	
	public Color this[int x, int y]
	{
		get
		{
			if (x < 0 || y < 0 || x >= Width || y >= Height)
				throw new IndexOutOfRangeException();

			var offset = (x + y * Width) * 4;

			return Color.FromArgb(pixels[offset + 3], pixels[offset], pixels[offset + 1], pixels[offset + 2]);
		}

		set => SetColor(x, y, value);
	}
	
	public void Dispose()
	{
		Disposing?.Invoke(this, EventArgs.Empty);
	}
}
