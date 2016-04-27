namespace HackyLambdas
{
	/// <summary>
	/// A base type for everything the parser constructs
	/// A bit hackey
	/// </summary>
	public class LambdaTerm
	{
		public LambdaTerm Parent = null;

		public virtual bool BetaReduce() { return false; }

		public virtual bool IsBound(string variable) { return false; }

		public virtual void MakeAlphaEquivalent(LambdaTerm term) { }

		internal virtual void Replace(LambdaVariable what, LambdaTerm with) { }
	}
}
