﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace HackyLambdas
{
	class Program
	{
		static void Main(string[] args)
		{
			string log = "";

			var initialTerms = "";
			using (var reader = new StreamReader(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Definitions.txt"))
			{
				initialTerms = reader.ReadToEnd();
			}

			foreach (var t in initialTerms.Split(new char[] { '\r', '\n'}))
			{
				LambdaParser.ParseDefinition(t);
			}

			while (true)
			{
				Console.Write(">: ");
				var input = Console.ReadLine();

				if (input.ToLower() == "end") break;
				else if (input.ToLower() == "log")
				{
					var logName = "lambdalog " + DateTime.Now + ".log";
					using (var writer = new StreamWriter(logName))
					{
						writer.Write(log);
					}

					Process.Start(logName);
				}
				if (input.ToLower() == "terms")
				{
					foreach (var t in RuntimeEnvironment.Terms)
					{
						Console.WriteLine(">> " + t.Key + " = " + t.Value);
					}
					Console.WriteLine();
				}
				if (input.ToLower() == "alpha")
				{
					Console.Write("1> ");
					var one = Console.ReadLine();
					Console.Write("2> ");
					var two = Console.ReadLine();
					Console.WriteLine(">> " + (RuntimeEnvironment.IsAlphaEquivalent(one, two) ?
						"These terms are alpha-equivalent." :
						"These terms are NOT alpha-equivalent.")
						);
				}
				else
				{
					log += ">: " + input;

					var inp = LambdaParser.ParseLine(input);
					inp.BetaReduce();

					Console.WriteLine("~> " + inp);
					log += "\r\n~> " + inp;
					Console.WriteLine();
					log += "\r\n";
				}
			}
		}
	}

	/// <summary>
	/// Gives us a nice environment for our interpreter. It's very clean and comfy. The interpreter likes it here.
	/// </summary>
	public static class RuntimeEnvironment
	{
		public static Dictionary<string, string> Terms = new Dictionary<string, string>();

		public static bool IsAlphaEquivalent(string first, string second)
		{
			var First = LambdaParser.ParseTerm(first).Root;
			var Second = LambdaParser.ParseTerm(second).Root;

			First.MakeAlphaEquivalent(Second);
			Debug.WriteLine(First.ToString());
			Debug.WriteLine(Second.ToString());

			return first.ToString() == second.ToString();
		}
	}
}