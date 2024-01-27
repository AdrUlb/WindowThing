using System.Numerics;

namespace RenderThing;

internal readonly struct FontChar(Vector2 size, Vector2 sectionOffset, Vector2 drawOffset, Vector2 advance)
{
	public readonly Vector2 Size = size;
	public readonly Vector2 SectionOffset = sectionOffset;
	public readonly Vector2 DrawOffset = drawOffset;
	public readonly Vector2 Advance = advance;
}
