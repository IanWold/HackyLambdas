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

			while (true)
			{
				Console.Write(">: ");
				var input = Console.ReadLine();

				if (input.ToLower() == "end") break;
				else if (input.ToLower() == "log")
				{
					var logName = "lambdalog " + DateTime.Now + ".log";
					using (StreamWriter writer = new StreamWriter(logName))
					{
						writer.Write(log);
					}

					Process.Start(logName);
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
	}
}
