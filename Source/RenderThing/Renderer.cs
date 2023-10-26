using System.Drawing;
using System.Numerics;

namespace RenderThing;

public abstract class Renderer : IDisposable
{
	public abstract void SetSize(uint width, uint height);

	public abstract void FillRect(Vector2 position, Vector2 size, Color color);

	public abstract void DrawTextureSection(Texture texture, Vector2 position, Vector2 size, Vector2 sectionPos, Vector2 sectionSize);

	public abstract void Clear(Color color);

	public abstract void Commit();
	
	public void FillRect(float x, float y, float width, float height, Color color) => FillRect(new(x, y), new(width, height), color);

	public void DrawTexture(Texture texture, Vector2 position, Vector2 size) =>
		DrawTextureSection(texture, position, size, new(0f, 0f), new(texture.Width, texture.Height));

	public void DrawText(string text, Font font, Vector2 position)
	{
		var pos = position;
        
		foreach (var c in text)
		{
			var f = font.LoadChar(c);
			var adjustedPos = pos + f.BitmapOffset with { Y = font.Size - f.BitmapOffset.Y };
			DrawTextureSection(font.Texture, adjustedPos, f.Size, f.TextureSection, f.Size);
			pos += f.Advance;
		}
	}
	
	protected virtual void Dispose(bool disposing)
	{
		
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		Dispose(true);
	}
	
	~Renderer() => Dispose(false);
}
