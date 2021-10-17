using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public interface ITransformer<TParameters> 
        where TParameters : IParametrs, new()
    {
        void Prepare(Size size, TParameters parameters);
        Size ResualtSize { get; }
        Point? MapPoint(Point newPoint);
    }
}