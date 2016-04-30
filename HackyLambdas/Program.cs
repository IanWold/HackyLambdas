using System;
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
				//initialTerms = reader.ReadToEnd();
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
				else if (input.ToLower() == "debruijn")
				{
					Console.Write("db>: ");
					var inp = LambdaParser.ParseLine(Console.ReadLine());

					Console.WriteLine("~db> " + inp.PrintDeBruijn());
					log += "\r\n~db> " + inp.PrintDeBruijn();
				}
				else if (input.ToLower() == "alpha")
				{
					Console.Write("α1>: ");
					var inp1 = LambdaParser.ParseLine(Console.ReadLine()).PrintDeBruijn();
					Console.Write("α2>: ");
					var inp2 = LambdaParser.ParseLine(Console.ReadLine()).PrintDeBruijn();

					Console.WriteLine("~α > " + (inp1 == inp2 ? "true" : "false"));
				}
				else if (input.ToLower() == "terms")
				{
					foreach (var t in RuntimeEnvironment.Terms)
					{
						Console.WriteLine(">> " + t.Key + " = " + t.Value);
					}
					Console.WriteLine();
				}
				else
				{
					log += ">: " + input;

					var inp = LambdaParser.ParseLine(input);
					inp.BetaReduce();
                    inp.GenConstraints();

					Console.WriteLine("~> " + inp);
					log += "\r\n~> " + inp;
                    Console.WriteLine("Type:");
                    log += "\r\nType: ";
                    Console.WriteLine(inp.TermType);
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

	}
}
