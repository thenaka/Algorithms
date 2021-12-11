using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExercises.Chapter1
{
	public static class Section1
	{
		/// <summary>
		/// Give the value of each of the expressions
		/// </summary>
		public static void Exercise1()
		{
			Console.WriteLine();
			Console.WriteLine("1.1.1");
			Console.WriteLine($"a. (0 + 15) / 2 = {(0 + 15) / 2}");
			Console.WriteLine($"b. 2.0e-6 * 100000000.1 = {2.0e-6 * 100000000.1}");
			Console.WriteLine($"c. true && false || true && true = {true && false || true && true}");
		}

		/// <summary>
		/// Give the type and value of the expressions
		/// </summary>
		public static void Exercise2()
		{
			Console.WriteLine();
			Console.WriteLine("1.1.2");
			var a = (1 + 2.236) / 2;
			Console.WriteLine($"a. (1 + 2.236) / 2 = {a} {a.GetType()}");
			var b = 1 + 2 + 3 + 4.0;
			Console.WriteLine($"b. 1 + 2 + 3 + 4.0 = {b} {b.GetType()}");
			var c = 4.1 >= 4;
			Console.WriteLine($"c. 4.1 >= 4 = {c} {c.GetType()}");
			var d = 1 + 2 + "3";
			Console.WriteLine($"d. 1 + 2 + \"3\" = {d} {d.GetType()}");
		}

		/// <summary>
		/// Takes three integer command-line arguments and prints equal if all three are equal, and not equal otherwise
		/// </summary>
		public static void Exercise3()
		{
			Console.WriteLine();
			Console.WriteLine("1.1.3");
			while (true)
			{
				Console.Write("Enter three integers (Q or q to quit): ");
				string rawEntry = Console.ReadLine();
				if (rawEntry.Equals("q", StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				var entries = rawEntry.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				var entriesCount = entries.Length;
				if (entriesCount != 3)
				{
					Console.WriteLine($"You entered {entriesCount} when three entries required");
					continue;
				}
				if (int.TryParse(entries[0], out int entry1) && int.TryParse(entries[1], out int entry2) && int.TryParse(entries[2], out int entry3))
				{
					Console.WriteLine($"All three equal: {entry1 == entry2 && entry2 == entry3}");
					continue;
				}
				Console.WriteLine("Error: One or more entry could not be parsed to an integer");
			}
		}

		/// <summary>
		/// What (if anything) is wrong with each of the following statements?
		/// </summary>
		public static void Exercise4()
		{
			Console.WriteLine();
			Console.WriteLine("1.1.4");
			Console.Write("a. if (a > b) then c = 0; ");
			Console.Write("If-statements should not have 'then'");
			Console.WriteLine();
			Console.Write("b. if a > b { c = 0; } ");
			Console.Write("Missing parentheses around a > b");
			Console.WriteLine();
			Console.Write("c. if (a > b) c = 0; ");
			Console.Write("Nothing wrong");
			Console.WriteLine();
			Console.Write("d. if (a > b) c = 0 else b = 0; ");
			Console.Write("Missing semicolon after c = 0");
		}
	}
}
