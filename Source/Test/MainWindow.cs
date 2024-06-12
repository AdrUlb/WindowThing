using RenderThing;
using SixLabors.ImageSharp;

namespace Test;

internal sealed class MainWindow() : Window(resizable: false, visible: true)
{
	protected override void OnRun()
	{

	}

	protected override void OnStop()
	{

	}

	protected override void OnCloseClicked()
	{
		Stop();
	}

	protected override void OnRender(Renderer renderer)
	{
		renderer.Clear(System.Drawing.Color.CornflowerBlue);
	}

	protected override void OnKeyDown(KeyboardKey key, ModifierKeys modifiers)
	{
		Console.WriteLine($"down: {key}");
	}

	protected override void OnKeyUp(KeyboardKey key, ModifierKeys modifiers)
	{
		Console.WriteLine($"up: {key}");
	}
}
