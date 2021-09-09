using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{

	/*	public struct Pixel
		{
			public double R;
			public double G;
			public double B;

			public Pixel(double r, double g, double b)
			{
				R = r;
				G = g;
				B = b;
			}
		}
	*/

	public class Pixel
	{


		private double r;
		private double g;
		private double b;

		private double Check(double value)
		{
			if (value < 0 || value > 1) throw new ArgumentException();
			return value;
		}

		public Pixel(double r, double g, double b)
		{
			R = r;
			G = g;
			B = b;
		}
		public static Pixel operator *(Pixel a, double p)
		{
			return new Pixel(Pixel.Trim(a.R * p), Pixel.Trim(a.G * p), Pixel.Trim(a.B * p));
		}


		public static double Trim(double value)
		{
			if (value < 0) return 0;
			if (value > 1) return 1;
			return value;
		}
		public double R
		{
			get { return r; }
			set { r = Check(value); }
		}
		public double G
		{
			get { return g; }
			set { g = Check(value); }
		}
		public double B
		{
			get { return b; }
			set { b = Check(value); }
		}
	}
}
