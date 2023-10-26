using AppThing;
using RenderThing;
using System.Drawing;

using var win = new RenderWindow(new()
{
	Resizable = true
});

using var font = new Font("/usr/share/fonts/TTF/arial.ttf", 60.0f);

var open = true;

win.Close += () => open = false;

win.Render += r =>
{
	r.Clear(Color.Black);

	r.FillRect(new(100, 100), new(100, 100), Color.Red);
	r.FillRect(new(120, 120), new(100, 100), Color.Green);
	r.FillRect(new(140, 140), new(100, 100), Color.Blue);
	r.DrawText("Hello, World!", font, new(150, 150));
};

SpinWait.SpinUntil(() => !open);
