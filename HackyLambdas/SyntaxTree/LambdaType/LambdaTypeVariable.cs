using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackyLambdas
{
	public class LambdaTypeVariable : LambdaType
	{
		public string Name { get; set; }

		public LambdaTypeVariable(string name)
		{
			Name = name;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
