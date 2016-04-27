namespace HackyLambdas
{
	/// <summary>
	/// This object represents the declaration part (left-side part) of a lambda function, used by the parser.
	/// Kind of hackey.
	/// </summary>
	public class LambdaDeclaration : LambdaTerm
	{
		public LambdaVariable Variable;

		public LambdaDeclaration(LambdaVariable lVar, LambdaType termType)
		{
			Variable = lVar;
			TermType = termType;
		}

		public override string ToString()
		{
			return "\\" + Variable;
		}
	}
}
