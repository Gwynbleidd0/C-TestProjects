using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
	public class PixelFilter<TParametrs> : ParametrizedFilter<TParametrs>
		where TParametrs: IParametrs, new()
	{
		string name;
		Func<Pixel, TParametrs, Pixel> processor;
		public PixelFilter(string name, Func<Pixel, TParametrs, Pixel> processor) {
			this.name = name;
			this.processor = processor;
		}
		public override Photo Process(Photo original, TParametrs parameters)
		{
			var result = new Photo(original.Width, original.Height);


			for (int x = 0; x < result.Width; x++)
				for (int y = 0; y < result.Height; y++)
				{
					result[x, y] = processor(original[x, y], parameters);


					/*				result[x, y] = original[x, y] * parameters[0]; *//*new Pixel(Pixel.Trim(original[x, y].R * parameters[0]), Pixel.Trim(original[x, y].G * parameters[0]), Pixel.Trim(original[x, y].B * parameters[0]));*/
				}
			/*					for (int z=0;z<3;z++)*/

			return result;
		}
		public override string ToString()
		{
			return name;
		}



	}
}
