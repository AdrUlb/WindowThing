using System.Numerics;

namespace RenderThing;

internal readonly struct FontChar
{
	public readonly Vector2 Size;
	public readonly Vector2 TextureSection;
	public readonly Vector2 BitmapOffset;
	public readonly Vector2 Advance;
    
	public FontChar(Vector2 size, Vector2 textureSection, Vector2 bitmapOffset, Vector2 advance)
	{
		Size = size;
		TextureSection = textureSection;
		BitmapOffset = bitmapOffset;
		Advance = advance;
	}
}
