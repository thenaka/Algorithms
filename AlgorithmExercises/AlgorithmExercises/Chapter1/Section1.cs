using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AlgorithmExercises.Chapter1
{
	public class Section1
	{
		/// <summary>
		/// Give the type and value of the expressions
		/// </summary>
		public static T GetFuncResultAndType<T>(Func<T> func, out Type type)
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
		/// Returns the Fibonacci sequence of <paramref name="count"/> plus one.
		/// </summary>
		/// <returns>The Fibonacci sequence of count plus one.</returns>
		public static IEnumerable<int> GetFibonacci(int count)
		{
			int f = 0;
			int g = 1;
			List<int> fibonacci = new List<int>();
			for (int i = 0; i <= count; i++)
			{
				fibonacci.Add(f);
				f = f + g;
				g = f - g;
			}
			return fibonacci;
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

		/// <summary>
		/// Returns the binary representation of <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The integer value to get the binary representation of.</param>
		/// <returns>The binary representation of the given value.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is negative.</exception>
		public static string IntToBin(int value)
		{
			if (value < 0)
			{
				throw new ArgumentException("Must be non-negative", nameof(value));
			}
			if (value == 0)
			{
				return "0";
			}
			string bin = string.Empty;
			for (int n = value; n > 0; n /= 2)
			{
				bin = (n % 2) + bin;
			}
			return bin;
		}

		/// <summary>
		/// Replaces true in <paramref name="bools"/> with '*' and false with ' '.
		/// </summary>
		/// <param name="bools">The two-dimensional array to replace booleans.</param>
		/// <returns>A new array with true replaced with '*' and false with ' '.</returns>
		public static char[,] BoolToStars(bool[,] bools)
		{
			if (bools is null)
			{
				throw new ArgumentNullException(nameof(bools));
			}
			char[,] stars = new char[bools.GetLength(0), bools.GetLength(1)];
			for (int i = 0; i < bools.GetLength(0); i++)
			{
				for (int j = 0; j < bools.GetLength(1); j++)
				{
					stars[i, j] = bools[i, j] ? '*' : ' ';
				}
			}
			return stars;
		}

		/// <summary>
		/// Transposes the x and y positions of the given <paramref name="toTranspose"/>.
		/// </summary>
		/// <typeparam name="T">Type of two-dimensional array.</typeparam>
		/// <param name="toTranspose">Two dimensional array to transpose.</param>
		/// <returns>Two-dimensional array with x and y positions transposed.</returns>
		public static T[,] Transpose<T>(T[,] toTranspose)
		{
			if (toTranspose is null)
			{
				throw new ArgumentNullException(nameof(toTranspose));
			}
			T[,] transposed = new T[toTranspose.GetLength(1), toTranspose.GetLength(0)];
			for (int i = 0; i < toTranspose.GetLength(0); i++)
			{
				for (int j = 0; j < toTranspose.GetLength(1); j++)
				{
					transposed[j, i] = toTranspose[i, j];
				}
			}
			return transposed;
		}

		/// <summary>
		/// Returns the largest value not larger than the base-2 logarithm of <paramref name="value"/>.
		/// </summary>
		/// <param name="value">Value to find the largest value less than the base-2 logarithm.</param>
		/// <returns>The largest value less than the base-2 algorithm of value.</returns>
		/// <remarks>Does not use <see cref="Math"/></remarks>
		/// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is less than 2.</exception>
		public static int LargestValueLessThanBaseTwoLog(int value)
		{
			if (value < 2)
			{
				throw new ArgumentException("Value must be two or greater", nameof(value));
			}

			int lastExp = 0;
			int exp = 1;
			while (exp < value)
			{
				lastExp = exp;
				exp *= 2;
			}
			return lastExp;
		}

		/// <summary>
		/// Returns an array of length <paramref name="histogramLength"/> with a count of each ith element.
		/// </summary>
		/// <param name="a">Array to count values.</param>
		/// <param name="histogramLength">The length of the histogram and the count of each ith element.</param>
		/// <returns>Returns an array of length <paramref name="histogramLength"/> with a count of each ith element.</returns>
		public static int[] Histogram(int[] a, int histogramLength)
		{
			if (a is null)
			{
				throw new ArgumentNullException(nameof(a));
			}
			if (histogramLength < 1)
			{
				throw new ArgumentException("Must be one or greater", nameof(histogramLength));
			}

			int[] histogramArray = new int[histogramLength];
			for (int i = 0; i < histogramLength; i++)
			{
				histogramArray[i] = a.Count(a => a == i);
			}
			return histogramArray;
		}

		/// <summary>
		/// Method for Exercise 16
		/// </summary>
		/// <param name="n">Value to stringify.</param>
		/// <returns>String representation of n.</returns>
		public static string ExR1(int n)
		{
			if (n <= 0) return "";
			return ExR1(n - 3) + n + ExR1(n - 2) + n;
		}

		/// <summary>
		/// Returns the multiple of <paramref name="a"/> and <paramref name="b"/>. <paramref name="b"/> must be positive.
		/// </summary>
		/// <param name="a">First value to multiply.</param>
		/// <param name="b">Second value to multiply.</param>
		/// <returns>Returns the multiple of <paramref name="a"/> and <paramref name="b"/>.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="b"/> is negative.</exception>
		public static int Multiply(int a, int b)
		{
			if (b < 0)
			{
				throw new ArgumentException("Must be positive", nameof(b));
			}

			if (b == 0) return 0;
			if (b % 2 == 0) return Multiply(a + a, b / 2);
			return Multiply(a + a, b / 2) + a;
		}

		/// <summary>
		/// Raises <paramref name="value"/> to <paramref name="power"/>.
		/// </summary>
		/// <param name="value">Value to raise to power.</param>
		/// <param name="power">Power to raise to.</param>
		/// <returns>Raises <paramref name="value"/> to <paramref name="power"/>.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="power"/> is negative.</exception>
		public static int Power(int value, int power)
		{
			if (power < 0)
			{
				throw new ArgumentException("Must be positive", nameof(power));
			}

			if (power == 0) return 1;
			if (power % 2 == 0) return Power(value * value, power / 2);
			return Power(value * value, power / 2) * value;
		}

		/// <summary>
		/// Returns the nth Fibonacci number.
		/// </summary>
		/// <param name="n">The nth Fibonacci.</param>
		/// <returns>Returns the nth Fibonacci number.</returns>
		/// <remarks>Uses recursion.</remarks>
		public static long RecursiveFibonacci(int n)
		{
			if (n == 0) return 0;
			if (n == 1) return 1;
			return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
		}

		/// <summary>
		/// Returns the nth Fibonacci number.
		/// </summary>
		/// <param name="n">The nth Fibonacci.</param>
		/// <returns>Returns the nth Fibonacci number.</returns>
		/// <remarks>Uses for loop.</remarks>
		public static long Fibonacci(int n)
		{
			long[] fibs = new long[n + 1];
			for (int i = 0; i <= n; i++)
			{
				if (i == 0 || i == 1) fibs[i] = i;
				else fibs[i] = fibs[i - 1] + fibs[i - 2];
			}
			return fibs[n];
		}

		/// <summary>
		/// Get the natural log of the factorial of <paramref name="n"/>.
		/// </summary>
		/// <param name="n">The number to calculate the log of its factorial.</param>
		/// <returns>The natural log of the factorial of <paramref name="n"/>.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="n"/> is less than zero.</exception>
		public static double LogFact(int n)
		{
			if (n < 1)
			{
				throw new ArgumentException("Must be 1 or greater", nameof(n));
			}
			if (n == 1)
			{
				return 0;
			}

			return LogFact(n - 1) + Math.Log(n);
		}

		/// <summary>
		/// Reads in lines from standard input with each line containing a name and two integers and then prints
		/// a table with a column of the names, the integers, and the result of dividing the first by the second,
		/// accurate to three decimal places
		/// </summary>
		public static void Exercise21()
		{
			Console.WriteLine();
			Console.WriteLine("1.1.21");
			while (true)
			{
				Console.Write("Enter a name and two integers (Q or q to quit): ");
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
				if (int.TryParse(entries[1], out int val1) && int.TryParse(entries[2], out int val2))
				{
					Console.WriteLine($"{entries[0]} | {val1} | {val2} | {(double)val1 / val2:n3}");
					continue;
				}
				Console.WriteLine("Error: One or more entry could not be parsed to an integer");
			}
		}

		/// <summary>
		/// Get the index of <paramref name="key"/> in <paramref name="values"/>.
		/// </summary>
		/// <param name="key">Value to search for in <paramref name="values"/>.</param>
		/// <param name="values">Sorted array of values.</param>
		/// <returns>The index of <paramref name="key"/> in <paramref name="values"/>. Returns -1 if not found.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="values"/> is null.</exception>
		public static int Rank(int key, int[] values)
		{
			return Rank(key, values, false);
		}

		/// <summary>
		/// Get the index of <paramref name="key"/> in <paramref name="values"/>.
		/// </summary>
		/// <param name="key">Value to search for in <paramref name="values"/>.</param>
		/// <param name="values">Sorted array of values.</param>
		/// <param name="shouldTrace">True if should write to Console the lo and hi values with each pass.</param>
		/// <returns>The index of <paramref name="key"/> in <paramref name="values"/>. Returns -1 if not found.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="values"/> is null.</exception>
		public static int Rank(int key, int[] values, bool shouldTrace)
		{
			if (values is null)
			{
				throw new ArgumentNullException(nameof(values));
			}
			if (values.Length == 0)
			{
				return -1;
			}
			return Rank(key, values, 0, values.Length - 1, 0, shouldTrace);
		}

		private static int Rank(int key, int[] values, int lo, int hi, int depth = 0, bool shouldTrace = false)
		{
			if (shouldTrace) Console.WriteLine($"{new string('\t', depth)}lo:{lo} hi{hi}");

			if (lo > hi) return -1;

			int mid = lo + (hi - lo) / 2;
			if (key < values[mid]) return Rank(key, values, lo, mid - 1, depth + 1, shouldTrace);
			else if (key > values[mid]) return Rank(key, values, mid + 1, hi, depth + 1, shouldTrace);
			else return mid;
		}

		/// <summary>
		/// Writes to Console numbers in the <paramref name="testFile"/> that do not appear in the <paramref name="whitelistFile"/>
		/// when <paramref name="shouldPrint"/> is '+'. When <paramref name="shouldPrint"/> is '-' writes to Console the numbers that
		/// are in the <paramref name="whitelistFile"/>.
		/// </summary>
		/// <param name="whitelistFile">A file with whitelisted integers separated by line breaks.</param>
		/// <param name="testFile">A file with test integers seperated by line breaks.</param>
		/// <param name="shouldPrint">Either '+' or '-'.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="whitelistFile"/> or <paramref name="testFile"/> is null.</exception>
		/// <exception cref="ArgumentException">The <paramref name="whitelistFile"/> or <paramref name="testFile"/> are not a paths to a valid file.-or-
		/// The third argument is not a '-' or '+'.</exception>
		/// <exception cref="FormatException">The values in <paramref name="whitelistFile"/> or <paramref name="testFile"/> cannot be parsed into an integer.</exception>
		/// <exception cref="IOException">An I/O error occurred while opening the <paramref name="whitelistFile"/> or the <paramref name="testFile"/>.</exception>
		/// <exception cref="System.Security.SecurityException">The caller does not have the required permission to open <paramref name="whitelistFile"/> or <paramref name="testFile"/>.</exception>
		/// <exception cref="UnauthorizedAccessException">Path to <paramref name="whitelistFile"/> or <paramref name="testFile"/> are read-only.-or-
		/// The caller does not have the required permission.</exception>
		public static void Exercise23(string whitelistFile, string testFile, char shouldPrint)
		{
			if (whitelistFile is null)
			{
				throw new ArgumentNullException(nameof(whitelistFile));
			}
			if (testFile is null)
			{
				throw new ArgumentNullException(nameof(testFile));
			}
			if (!File.Exists(whitelistFile))
			{
				throw new ArgumentException("The first argument must contain valid path to a whitelist file");
			}
			var whitelist = File.ReadAllLines(whitelistFile).Select(f => int.Parse(f)).OrderBy(i => i).ToArray();
			if (!File.Exists(testFile))
			{
				throw new ArgumentException("The second argument must contain valid path to a test file");
			}
			var testNumbers = File.ReadAllLines(testFile).Select(f => int.Parse(f)).ToArray();
			if (shouldPrint != '-' && shouldPrint != '+')
			{
				throw new ArgumentException("Must be a '+' or '-'", nameof(shouldPrint));
			}

			foreach (int testNumber in testNumbers)
			{
				if (Rank(testNumber, whitelist) == -1) // testNumber is not in the whitelist
				{
					if (shouldPrint == '+')
					{
						Console.WriteLine(testNumber);
					}
				}
				else // testNumber is in the whitelist
				{
					if (shouldPrint == '-')
					{
						Console.WriteLine(testNumber);
					}
				}
			}
		}

		/// <summary>
		/// Returns the greatest common denominator of <paramref name="high"/> and <paramref name="low"/>.
		/// </summary>
		/// <param name="high">The higher of the two numbers.</param>
		/// <param name="low">The lower of the two numbers.</param>
		/// <returns>The greatest common denominator</returns>
		/// <remarks>Uses Euclid's algorithm.</remarks>
		public static int GCD(int high, int low)
		{
			if (low == 0) return high;
			int candidate = high % low;
			return GCD(low, candidate);
		}
	}
}
