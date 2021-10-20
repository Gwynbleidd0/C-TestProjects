using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
	public class BlackAndWhiteFilter: PixelFilter<EmptyParametrs>
	{

		public override string ToString()
		{
			return "Черно-белый";
		}
	

		public override Pixel ProcessPixel(Pixel originalPixel, EmptyParametrs parameters)
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
