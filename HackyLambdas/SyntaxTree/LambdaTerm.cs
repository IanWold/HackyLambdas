using System.Collections.Generic;
using System;

namespace HackyLambdas
{
	/// <summary>
	/// A base type for everything the parser constructs
	/// A bit hackey
	/// </summary>
	public class LambdaTerm
	{
		public LambdaTerm Parent = null;

		public LambdaType TermType = null;

		public virtual bool BetaReduce() { return false; }

		public virtual bool IsBound(string variable) { return false; }

		public virtual int GetDeBruijnIndex(string name = "") { return -1; }

		public virtual string PrintDeBruijn() { return null; }

		internal virtual void Replace(LambdaVariable what, LambdaTerm with) { }

        public virtual LambdaType GetTermType() { return TermType; }

        public virtual Tuple<List<string>, List<string>> GenConstraints() { return null; }
    }
}
