using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
	public abstract class ParametrizedFilter<TParametrs> : IFilter
		where TParametrs: IParametrs, new()
	{
		public ParameterInfo[] GetParameters()
		{
			return new TParametrs().GetDescription();
		}

		public Photo Process(Photo original, double[] values)
		{
			var parameters = new TParametrs();
			parameters.Parse(values);
			return Process(original, parameters);
		}

		public abstract Photo Process(Photo original, TParametrs parameters);
	}
}
