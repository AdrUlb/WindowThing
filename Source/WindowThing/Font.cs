using System.Drawing;
using WindowThing.Bindings.FreeType;

namespace WindowThing;

public sealed class Font : IDisposable
{
	internal readonly Texture Texture = new();

	private readonly Dictionary<char, FontChar> _chars = new();
	private readonly FtFace _face;

	private uint _offX = 0;

	public readonly float Size;

	public Font(string filePath, float size)
	{
		Size = size;

		Ft.NewFace(Manager.FtLib, filePath, 0, out _face);
		Ft.SetCharSize(_face, size, 0, 100, 0);
	}

	internal unsafe FontChar GetChar(char c)
	{
		if (_chars.TryGetValue(c, out var ret))
			return ret;

		Ft.LoadChar(_face, c, FtLoadFlags.Render);
		var glyph = _face.Rec->Glyph.Rec;

		var w = glyph->Bitmap.Width;
		var h = glyph->Bitmap.Rows;
		var p = glyph->Bitmap.Pitch;

		if (w > Texture.Width - _offX || h > Texture.Height)
		{
			var newW = Math.Max(Texture.Width, Texture.Width + w);
			var newH = Math.Max(Texture.Height, h);

			Texture.SetSize(newW, newH);
		}

		var b = (byte*)glyph->Bitmap.Buffer;

		for (uint y = 0; y < h; y++)
			for (uint x = 0; x < w; x++)
				Texture[(int)(x + _offX), (int)y] = Color.FromArgb(b[x + (y * p)], 255, 255, 255);

		ret = new(new(w, h), new(_offX, 0), new(glyph->BitmapLeft, glyph->BitmapTop), new(glyph->Advance.X / 64.0f, glyph->Advance.Y / 64.0f));
		_chars.Add(c, ret);
		_offX += w;
		return ret;
	}

	private void Dispose(bool disposing)
	{
		Texture.Dispose();
		Ft.DoneFace(_face);
	}

	~Font() => Dispose(false);

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		Dispose(true);
	}
}
