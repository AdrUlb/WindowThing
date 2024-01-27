using RenderThing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics;
using System.Text;
using Color = System.Drawing.Color;

namespace Test;

internal sealed class MainWindow() : Window(resizable: false, visible: true)
{
	private Texture _tex1 = null!;
	private Texture _tex2 = null!;
	private Font _font = null!;

	string randStr;

	protected override void OnRun()
	{
		Size = new(1280, 720);
		using Image<Rgba32> image1 = Image.Load<Rgba32>(@"C:\Users\Adrian\Desktop\test1.png");
		using Image<Rgba32> image2 = Image.Load<Rgba32>(@"C:\Users\Adrian\Desktop\test2.png");

		_tex1 = new();
		_tex1.SetSize((uint)image1.Width, (uint)image1.Height);

		_tex2 = new();
		_tex2.SetSize((uint)image1.Width, (uint)image2.Width);

		image1.ProcessPixelRows(a =>
		{
			for (var y = 0; y < a.Height; y++)
			{
				var row = a.GetRowSpan(y);

				for (var x = 0; x < row.Length; x++)
					_tex1[x, y] = Color.FromArgb(row[x].A, row[x].R, row[x].G, row[x].B);
			}
		});

		image2.ProcessPixelRows(a =>
		{
			for (var y = 0; y < a.Height; y++)
			{
				var row = a.GetRowSpan(y);

				for (var x = 0; x < row.Length; x++)
					_tex2[x, y] = Color.FromArgb(row[x].A, row[x].R, row[x].G, row[x].B);
			}
		});

		_font = new(@"C:\Windows\Fonts\Consola.ttf", 20);

		var rand = new StringBuilder();

		for (var y = 0; y < 34; y++)
		{
			for (var x = 0; x < 85; x++)
			{
				rand.Append((char)Random.Shared.Next(33, 91));
			}

			rand.AppendLine();
		}

		randStr = rand.ToString();
	}

	protected override void OnStop()
	{
		_tex1.Dispose();
		_tex2.Dispose();
		_font.Dispose();
	}

	protected override void OnCloseClicked()
	{
		Stop();
	}

	private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
	private const int _maxFrames = 100;
	private int _frames = 0;
	private readonly double[] _frameTimes = new double[_maxFrames];
	private double _lastFrameTime = 0.0;

	protected override void OnRender(Renderer renderer)
	{
		renderer.Clear(Color.Black);

		renderer.DrawText(randStr, _font, new(0, 30), Color.White);

		renderer.DrawText($"FPS: {1000.0 / _lastFrameTime}", _font, new(0, 2), Color.Red);

		var elapsed = _stopwatch.Elapsed.TotalMilliseconds;
		_frameTimes[_frames++] = elapsed;
		if (_frames == _maxFrames)
		{
			_lastFrameTime = _frameTimes.Average();
			_frames = 0;
		}
		_stopwatch.Restart();
	}
}
