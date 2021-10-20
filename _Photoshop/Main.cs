using System;
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
					"Осветление/затемнение",
					(pixel, parametrs) => pixel * parametrs.Coefficient
				));
			window.AddFilter(new PixelFilter<LightingParametrs>(
					"Оттенки серого",
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
			Application.Run (window);
		}
	}
}
