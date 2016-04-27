using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackyLambdas
{
	public class LambdaTypeArrow : LambdaType
	{
		public LambdaType First { get; set; }
		public LambdaType Second { get; set; }

		public LambdaTypeArrow(LambdaType first, LambdaType second)
		{
			First = first;
			Second = second;
		}
	}
}
