using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
	public class TransformFilter<TParametrs> : ParametrizedFilter<TParametrs>
	{
		Func<Size, TParametrs, Size> sizeTransform;
		Func<Point, Size, TParametrs, Point?> pointTransform;
		string name;
		public override string ToString()
		{
			return name;
		}

        public TransformFilter(string name, Func<Size, TParametrs, Size> sizeTransform, Func<Point, Size, TParametrs, Point?> pointTransform)
		{
            this.name = name;
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
		}
        public override Photo Process(Photo original, TParametrs parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            var newSize = sizeTransform(oldSize, parameters);
            var result = new Photo(newSize.Width, newSize.Height);
            for (int x = 0; x < newSize.Width; x++)
                for (int y = 0; y < newSize.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = pointTransform(point, oldSize, parameters);
                    if (oldPoint !=null)
                    result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }
            return result;
        }
    }
}
