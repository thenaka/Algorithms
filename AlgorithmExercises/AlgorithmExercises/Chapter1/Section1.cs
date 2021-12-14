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
		/// Validates if-statements
		/// </summary>
		/// <param name="ifStatement">if-statement to validate.</param>
		/// <returns>True if valid, otherwise false.</returns>
		/// <remarks>This method was written with test driven development so it validates if-statements up to the complexity of what is given.</remarks>
		public static bool ValidateIfStatement(string ifStatement)
		{
			Regex ifRegex = new Regex(@"^if \([a-z] > [a-z]\) {* *[a-z] = 0; *}*");
			return ifRegex.Match(ifStatement).Success;
		}

		/// <summary>
		/// Returns if both <paramref name="x"/> and <paramref name="y"/> and strictly within the range of 0 to 1.
		/// </summary>
		/// <param name="x">X value to check.</param>
		/// <param name="y">Y value to check.</param>
		/// <returns>True if both in the range of 0 to 1, otherwise false.</returns>
		public static bool BothInRange(double x, double y)
		{
			return InRange(x, 0, 1) && InRange(y, 0, 1);
		}

		/// <summary>
		/// Returns if <paramref name="value"/> is strictly within the given <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">Value to check if in range.</param>
		/// <param name="min">Minimum value.</param>
		/// <param name="max">Maximum value.</param>
		/// <returns>True if the value is strictly within the given range.</returns>
		private static bool InRange(double value, double min, double max)
		{
			return min < value && value < max;
		}
	}
}
