namespace HackyLambdas
{
	public class LambdaFunction : LambdaTerm
	{
		//The "argument," if you will
		public LambdaVariable Input;

		//The output of this function
		public LambdaTerm Output;

		public LambdaFunction(LambdaVariable input, LambdaTerm output)
		{
			input.Parent = this;
			output.Parent = this;

			Input = input;
			Output = output;
		}

		/// <summary>
		/// If the function gets a call to perform a beta-reduce, just pass it on
		/// </summary>
		/// <returns></returns>
		public override bool BetaReduce()
		{
			try
			{
				return Output.BetaReduce();
			}
			catch
			{
				return true;
			}
		}

		/// <summary>
		/// Checks to see if a variable is bound
		/// </summary>
		/// <param name="variable">The name of the variable</param>
		/// <returns>True if this functions binds the variable, otherwise it passes the check to its parent</returns>
		public override bool IsBound(string variable)
		{
			if (Input.Name == variable) return true;
			else
			{
				return Parent == null ? false : Parent.IsBound(variable);
			}
		}

		public override void MakeAlphaEquivalent(LambdaTerm term)
		{
			if (term.GetType() == typeof(LambdaFunction))
			{
				//var next = new LambdaExpression((term as LambdaFunction).Output).Root;
				//next.Replace((term as LambdaFunction).Input, this.Input);
				(term as LambdaFunction).Input = this.Input;
				//(term as LambdaFunction).Output = next;

				Output.MakeAlphaEquivalent((term as LambdaFunction).Output);
			}
			else return;
		}

		/// <summary>
		/// Passes it on
		/// </summary>
		/// <param name="what"></param>
		/// <param name="with"></param>
		internal override void Replace(LambdaVariable what, LambdaTerm with)
		{
			Output.Replace(what, with);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>A nice string representation of the object</returns>
		public override string ToString()
		{
			return "\\" + Input.ToString() + "." + Output.ToString();
		}
	}
}
