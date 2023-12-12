using RenderThing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics;
using Color = System.Drawing.Color;

namespace Test;

internal sealed class MainWindow : Window
{
	private Texture tex1 = null!;
	private Texture tex2 = null!;
	private Font font = null!;
	private Font font2 = null!;

	protected override void OnRun()
	{
		using Image<Rgba32> image1 = Image.Load<Rgba32>(@"C:\Users\Adrian\Desktop\test1.png");

		tex1 = new();
		tex1.SetSize((uint)image1.Width, (uint)image1.Height);

		tex2 = new();
		tex2.SetSize(200, 200);


		image1.ProcessPixelRows(a =>
		{
			for (var y = 0; y < a.Height; y++)
			{
				var row = a.GetRowSpan(y);

				for (var x = 0; x < row.Length; x++)
					tex1[x, y] = Color.FromArgb(row[x].A, row[x].R, row[x].G, row[x].B);
			}
		});

		for (var y = 0; y < 200; y++)
			for (var x = 0; x < 200; x++)
				tex2[x, y] = Color.Orange;

		font = new(@"C:\Windows\Fonts\Comic.ttf", 20);
		font2 = new(@"C:\Windows\Fonts\Consola.ttf", 20);
	}

	protected override void OnStop()
	{
		tex1.Dispose();
		tex2.Dispose();
		font.Dispose();
		font2.Dispose();
	}

	protected override void OnCloseClicked()
	{
		Stop();
	}

	private readonly Stopwatch stopwatch = Stopwatch.StartNew();
	private const int maxFrames = 100;
	private int frames = 0;
	private readonly double[] frameTimes = new double[maxFrames];
	private double lastFrameTime = 0.0;
	protected override void OnRender(Renderer renderer)
	{
		renderer.Clear(Color.CornflowerBlue);
		renderer.DrawTextureSection(tex1, new(0, 0), new(tex1.Width, tex1.Height), new(20, 20), new(200, 200), Color.White);
		renderer.DrawTextureSection(tex2, new(0, 0), new(200, 200), new(250, 20), new(200, 200), Color.White);

		renderer.DrawText("Hello, World!", font, new(20, 20), Color.Red);
		renderer.DrawText($"FPS: {1000.0 / lastFrameTime}", font2, new(20, 60), Color.Red);

		var elapsed = stopwatch.Elapsed.TotalMilliseconds;
		frameTimes[frames++] = elapsed;
		if (frames == maxFrames)
		{
			lastFrameTime = frameTimes.Average();
			frames = 0;
		}
		stopwatch.Restart();
	}
}
