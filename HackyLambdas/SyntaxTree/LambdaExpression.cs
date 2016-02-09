namespace HackyLambdas
{
	/// <summary>
	/// Provides a parent for the Root term
	/// </summary>
	public class LambdaExpression : LambdaTerm
	{
		public LambdaTerm Root;

		public LambdaExpression(LambdaTerm root)
		{
			root.Parent = this;
			Root = root;
		}

		public override bool BetaReduce()
		{
			var toEnd = true;

			//Loop until we can b-reduce no more
			while (toEnd)
			{
				toEnd = Root.BetaReduce();
			}

			return false;
		}

		internal override void Replace(LambdaVariable what, LambdaTerm with)
		{
			Root.Replace(what, with);
		}

		public override string ToString()
		{
			return Root.ToString();
		}
	}
}
