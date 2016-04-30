﻿using System.Collections.Generic;
using System;

namespace HackyLambdas
{
	public class LambdaVariable : LambdaTerm
	{
		//The name of the variable, believe it or not
		public string Name;

		public LambdaVariable(string name)
		{
			Name = name;
		}

		public LambdaVariable(string name, LambdaType termType)
		{
			Name = name;
			TermType = termType;
		}

        public override void SetType(LambdaVariable varName)
        {
            if (Name == varName.Name)
            {
                TermType = varName.TermType;
            }
        }

        public override void SetFreeType(List<string> typesUsed, List<LambdaVariable> freeTypesUsed)
        {
            if (TermType != null)
            {
                return;
            }

            // generate new variable type name
            int i;
            for (i = 0; typesUsed.Contains("T" + i); i++) ;
            TermType = new LambdaTypeVariable("T" + i);
            typesUsed.Add(TermType.ToString());

            freeTypesUsed.Add(this);
        }

        public override List<string> GetTypesUsed()
        {
            List<string> typesUsed = new List<string>();
            if (TermType != null)
            {
                typesUsed.Add(TermType.ToString());
            }
            return typesUsed;
        }

        public bool IsBound()
		{
			return Parent == null ? false : Parent.IsBound(Name);
		}

		/// <summary>
		/// If this is a variable with ought be replaced with another expression in a b-reduction, do so
		/// </summary>
		/// <param name="what">The variable which must be replaced</param>
		/// <param name="with">That with which we must replace what</param>
		internal override void Replace(LambdaVariable what, LambdaTerm with)
		{
			if (Name == what.Name && !IsBound())
			{
				if (Parent.GetType() == typeof(LambdaFunction))
				{
					(Parent as LambdaFunction).Output = with;
					with.Parent = (Parent as LambdaFunction);
				}
				else if (Parent.GetType() == typeof(LambdaApplication))
				{
					if ((Parent as LambdaApplication).First == this)
					{
						(Parent as LambdaApplication).First = with;
						with.Parent = (Parent as LambdaApplication);
					}
					else
					{
						(Parent as LambdaApplication).Second = with;
						with.Parent = (Parent as LambdaApplication);
					}
				}
				else if (Parent.GetType() == typeof(LambdaExpression))
				{
					(Parent as LambdaExpression).Root = with;
					with.Parent = (Parent as LambdaExpression);
				}
			}
		}

        public override LambdaType GetTermType()
        {
            return TermType;
        }

        public override Tuple<List<string>, List<string>> GenConstraints()
        {
            List<string> constraints = new List<string>();
            List<string> typesUsed = new List<string>();
            typesUsed.Add(TermType.ToString());

            return new Tuple<List<string>, List<string>>(constraints, typesUsed);
        }

        /*
		public override int GetDeBruijnIndex(string name = "")
		{
			return Parent.GetDeBruijnIndex(Name);
		}
        */

        public override string ToString()
		{
			return Name + ":" + TermType?.ToString() ?? "?";
		}

		public override string PrintDeBruijn()
		{
			return GetDeBruijnIndex().ToString();
		}
	}
}
