using System;

namespace MyPhotoshop
{
	public class Photo
	{
		private readonly int width;
		private readonly int height;
		private readonly Pixel[,] data;

		public Pixel this[int indexX, int indexY]
		{
			get
			{
				return data[indexX, indexY];
			}

			set
			{
				data[indexX, indexY] = value ;
			}
		}
		public int Width
		{
			get { return width; }
		}

		public int Height
		{
			get { return height; }
		}

		public Pixel[,] Data
		{
			get { return data; }
		}
		public Photo(int widthInput, int heightInput)
		{
			width = widthInput;
			height = heightInput;
			data = new Pixel[Width, Height];

		}
	}
}

