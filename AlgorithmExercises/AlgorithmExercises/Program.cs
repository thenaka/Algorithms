using AlgorithmExercises.Chapter1;
using System;

namespace AlgorithmExercises
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//Console.WriteLine();
			//Console.WriteLine("1.1.4");
			//Console.Write("a. if (a > b) then c = 0; ");
			//Console.Write("If-statements should not have 'then'");
			//Console.WriteLine();
			//Console.Write("b. if a > b { c = 0; } ");
			//Console.Write("Missing parentheses around a > b");
			//Console.WriteLine();
			//Console.Write("c. if (a > b) c = 0; ");
			//Console.Write("Nothing wrong");
			//Console.WriteLine();
			//Console.Write("d. if (a > b) c = 0 else b = 0; ");
			//Console.Write("Missing semicolon after c = 0");
			Section1.ValidateIfStatement("if (a > b) then c = 0;");
			Console.ReadKey();
		}

	}
}
