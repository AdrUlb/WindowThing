using RenderThing;
using System.Drawing;

namespace GuiThing;

public class GuiElement
{
	public readonly List<GuiElement> children = new();

	public GuiElement? Parent { get; private set; } = null;

	public Rectangle Bounds { get; set; }

	public Color BackgroundColor = Color.Transparent;

	protected virtual Rectangle AbsoluteBounds
	{
		get
		{
			if (Parent == null)
				return Rectangle.Empty;

			var b = Bounds;
			b.Offset(Parent.AbsoluteBounds.Location);
			return b;
		}
	}

	protected virtual Rectangle AbsoluteVisibleBounds
	{
		get
		{
			if (Parent == null)
				return Rectangle.Empty;

			var b = AbsoluteBounds;
			b.Intersect(Parent.AbsoluteVisibleBounds);
			return b;
		}
	}
	
	public void AddElement(GuiElement element)
	{
		if (element.Parent != null)
			throw new InvalidOperationException();

		children.Add(element);

		element.Parent = this;

		element.Layout();
	}

	public void RemoveElement(GuiElement element)
	{
		if (element.Parent != this)
			throw new InvalidOperationException();

		children.Remove(element);

		element.Parent = null;
	}

	protected virtual void OnDraw(Renderer renderer)
	{
		var b = AbsoluteVisibleBounds;
		renderer.FillRect(b.X, b.Y, b.Width, b.Height, BackgroundColor);
	}

	internal void Layout() { }

	internal void Draw(Renderer renderer)
	{
		OnDraw(renderer);

		foreach (var c in children)
			c.Draw(renderer);
	}
}
