using System;

namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter<LightingParametrs>
	{
		
		public override string ToString ()
		{
			return "Осветление/затемнение";
		}
		
		public override Pixel ProcessPixel(Pixel originalPixel, LightingParametrs parameters)
		{
			var result = originalPixel * parameters.Coefficient;
			return result;
		}

	}
}

