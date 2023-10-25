using RenderThing.FreeType;
using System.Drawing;
using System.Numerics;
using Ft = RenderThing.FreeType.Ft;

namespace RenderThing;

public sealed class Font : IDisposable
{
	public readonly float Size;
	
	private bool isDisposed = false;
	private readonly FtFace face;

	internal Texture Texture { get; private set; }
	private readonly Dictionary<char, FontChar> charCache = new();

	private uint offX = 0;
	
	public Font(string filePath, float size)
	{
		Size = size;
		FtManager.Init();
		Ft.NewFace(FtManager.Lib, filePath, 0, out face);
		Ft.SetCharSize(face, size, 0, 100, 0);
		Texture = new((uint)(size * 2.0), (uint)(size * 2.0));
	}

	internal unsafe FontChar LoadChar(char c)
	{
		if (charCache.TryGetValue(c, out var ret))
			return ret;
		
		Ft.LoadChar(face, c, FtLoadFlags.Render);

		var glyph = face.Rec->glyph.Rec;

		var w = glyph->bitmap.width;
		var h = glyph->bitmap.rows;
		var p = glyph->bitmap.pitch;
		var ox = offX;

		offX += w;

		if (ox + w > Texture.Width || h > Texture.Height)
		{
			var newW = Math.Max(Texture.Width + offX + w, Texture.Width);
			var newH = Math.Max(Texture.Height + h, Texture.Height);
            
			var oldTexture = Texture;
			Texture = new(newW, newH);

			for (var y = 0; y < oldTexture.Height; y++)
				for (var x = 0; x < oldTexture.Width; x++)
					Texture[x, y] = oldTexture[x, y];
			
			oldTexture.Dispose();
		}
		
		//var pixels = new byte[w * h];

		var b = (byte*)glyph->bitmap.buffer;

		for (uint y = 0; y < h; y++)
			for (uint x = 0; x < w; x++)
				Texture[(int)(x + ox), (int)y] = Color.FromArgb(b[x + y * p], 255, 255, 255);
				//pixels[x + y * w] = b[x + y * p];

		//return new(w, h, pixels);
		var offset = new Vector2(glyph->bitmap_left, glyph->bitmap_top);
		var advance = new Vector2(glyph->advance.x / 64.0f, glyph->advance.y / 64.0f);
		ret = new(new(w, h), new(ox, 0), offset, advance);
		charCache.Add(c, ret);
		return ret;
	}

	~Font() => Dispose(false);

	private void Dispose(bool disposing)
	{
		if (isDisposed)
			return;

		Texture.Dispose();
		Ft.DoneFace(face);

		isDisposed = true;
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		Dispose(true);
	}
}
