using RenderThing.Bindings.FreeType;
using System.Drawing;

namespace RenderThing;

public sealed class Font : IDisposable
{
	internal readonly Texture Texture = new();

	private readonly Dictionary<char, FontChar> chars = new();
	private readonly FtFace face;

	private uint offX = 0;

	public readonly float Size;

	public Font(string filePath, float size)
	{
		Size = size;

		Ft.NewFace(Manager.FtLib, filePath, 0, out face);
		Ft.SetCharSize(face, size, 0, 100, 0);
	}

	internal unsafe FontChar GetChar(char c)
	{
		if (chars.TryGetValue(c, out var ret))
			return ret;

		Ft.LoadChar(face, c, FtLoadFlags.Render);
		var glyph = face.Rec->glyph.Rec;

		var w = glyph->bitmap.width;
		var h = glyph->bitmap.rows;
		var p = glyph->bitmap.pitch;

		if (w > Texture.Width - offX || h > Texture.Height)
		{
			var newW = Math.Max(Texture.Width, Texture.Width + w);
			var newH = Math.Max(Texture.Height, h);

			Texture.SetSize(newW, newH);
		}

		var b = (byte*)glyph->bitmap.buffer;

		for (uint y = 0; y < h; y++)
			for (uint x = 0; x < w; x++)
				Texture[(int)(x + offX), (int)y] = Color.FromArgb(b[x + (y * p)], 255, 255, 255);

		ret = new(new(w, h), new(offX, 0), new(glyph->bitmap_left, glyph->bitmap_top), new(glyph->advance.x / 64.0f, glyph->advance.y / 64.0f));
		chars.Add(c, ret);
		offX += w;
		return ret;
	}

	private void Dispose(bool disposing)
	{
		Texture.Dispose();
		Ft.DoneFace(face);
	}

	~Font() => Dispose(false);

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		Dispose(true);
	}
}
