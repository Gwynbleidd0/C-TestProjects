using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
	public interface IParametrs
	{
		ParameterInfo[] GetDescription();
		void SetValues(double[] values);
		void Parse(double[] values);
	}
}
