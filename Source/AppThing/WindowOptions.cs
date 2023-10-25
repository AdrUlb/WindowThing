using System.Drawing;

namespace AppThing;

public struct WindowOptions
{
	public string Title = "AppThing Window";
	public Size Size = new(640, 480);
	public bool Visible = true;
	public bool Resizable = false;

	public WindowOptions()
	{
		
	}
}
