using AppThing;
using GuiThing;
using RenderThing;
using System.Drawing;

using var win = new RenderWindow(new()
{
	Size = new(800, 600),
	Resizable = true
});

using var font = new Font("/usr/share/fonts/TTF/arial.ttf", 60.0f);

var open = true;

win.Close += () => open = false;

var gui = new GuiRootElement()
{
	BackgroundColor = Color.White
};

var e1 = new GuiElement
{
	Bounds = new(40, 40, 400, 400),
	BackgroundColor = Color.Red
};

var e2 = new GuiElement
{
	Bounds = new(50, 50, 400, 400),
	BackgroundColor = Color.Green
};

var e3 = new GuiElement
{
	Bounds = new(50, 50, 400, 400),
	BackgroundColor = Color.Blue
};

var e4 = new GuiElement
{
	Bounds = new(50, 50, 400, 400),
	BackgroundColor = Color.Orange
};

gui.AddElement(e1);
e1.AddElement(e2);
e2.AddElement(e3);
e3.AddElement(e4);

win.Render += r =>
{
	r.Clear(Color.Black);

	gui.Draw(r, new(new(0, 0), win.Size));
};

SpinWait.SpinUntil(() => !open);
