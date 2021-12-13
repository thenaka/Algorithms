using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlgorithmExercises.Chapter1
{
	public class Section1
	{
		/// <summary>
		/// Give the type and value of the expressions
		/// </summary>
		public static T Exercises1and2<T>(Func<T> func, out Type type)
		{
			var result = func();
			type = result.GetType();
			return result;
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
					Console.WriteLine($"All three equal: {AllEqual(entry1, entry2, entry3)}");
					continue;
				}
				Console.WriteLine("Error: One or more entry could not be parsed to an integer");
			}
		}

		/// <summary>
		/// Returns if all given <paramref name="values"/> are equal.
		/// </summary>
		/// <param name="values">The values to test for equality.</param>
		/// <returns>True if all equal, otherwise false. An empty array returns false. A single value returns true.</returns>
		public static bool AllEqual(params int[] values)
		{
			if (values is null)
			{
				throw new ArgumentNullException(nameof(values));
			}
			if (values.Length == 0)
			{
				return false;
			}
			if (values.Length == 1)
			{
				return true;
			}
			var first = values.First();
			return values.All(v => v == first);
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

		public bool ValidateIfStatement(string ifStatement)
		{
			Regex ifRegex = new Regex(@"^if\s+\(\s*(""\w""|\d+)\s+(>|>=|<|<=|==)\s+(""\w""|\d+)\s*)\s+{?.+}?;$");
			return ifRegex.Match(ifStatement).Success;
			
		}
	}
}
