using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter(new PixelFilter<LightingParametrs>(
					"����������/����������",
					(pixel, parametrs) => pixel * parametrs.Coefficient
				));
			window.AddFilter(new PixelFilter<LightingParametrs>(
					"������� ������",
					(original, parametrs) =>
					{
						var result = original;
						var pixel = (original.G + original.B + original.R) / 3;
						result.G = pixel;
						result.B = pixel;
						result.R = pixel;
						return result;
					}
				));
			window.AddFilter(new TransformFilter<RotationParametrs>(
					"��������� ��������",
					new RotateTransformer()
				)) ;
			window.AddFilter(new TransformFilter(
					"�������� �� �����������",
					size => size,
					(point, size) => new Point(size.Width - point.X - 1, point.Y)

				));
			window.AddFilter(new TransformFilter(
					"������� ������ ��",
					size => new Size(size.Height, size.Width),
					(point, size) => new Point(point.Y, point.X)

				));
			Application.Run (window);
		}
	}
}
