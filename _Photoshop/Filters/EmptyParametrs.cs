using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
	public class EmptyParametrs : IParametrs
	{
		public ParameterInfo[] GetDescription()
		{
			return new ParameterInfo[0];
		}

		public void Parse(double[] values)
		{
			
		}

		public void SetValues(double[] values)
		{
			
		}
	}
}
