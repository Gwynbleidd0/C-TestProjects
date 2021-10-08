using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
	public class BlackAndWhiteFilter: PixelFilter, IFilter
	{
		public override ParameterInfo[] GetParameters()
		{
			return new ParameterInfo[0];
		}

		public override string ToString()
		{
			return "Черно-белый";
		}

		public override Pixel ProcessPixel(Pixel originalPixel, double[] parameters)
		{
			var result = originalPixel;
			var pixel = (originalPixel.G + originalPixel.B + originalPixel.R) / 3;
			result.G = pixel;
			result.B = pixel;
			result.R = pixel;
			return result;
		}

	}
}
