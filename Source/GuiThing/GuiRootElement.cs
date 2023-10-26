using RenderThing;
using System.Drawing;

namespace GuiThing;

public class GuiRootElement : GuiElement
{
	protected override Rectangle AbsoluteBounds => Bounds;

	protected override Rectangle AbsoluteVisibleBounds => AbsoluteBounds;
	
	public void Draw(Renderer renderer, Rectangle rect)
	{
		if (Bounds != rect)
		{
			Bounds = rect;
			Layout();
		}
		
		base.Draw(renderer);
	}
}
