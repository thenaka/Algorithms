using AlgorithmExercises.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
			Regex ifRegex = new(@"^if \([a-z] > [a-z]\) {* *[a-z] = 0; *}*");
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
			List<int> fibonacci = new();
			for (int i = 0; i <= count; i++)
			{
				fibonacci.Add(f);
				f += g;
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
		/// Get the number of values less than <paramref name="key"/> in <paramref name="values"/>.
		/// </summary>
		/// <param name="key">The number to find lesser values in <paramref name="values"/>.</param>
		/// <param name="values">Sorted array of values.</param>
		/// <returns>The number of values less than of <paramref name="key"/> in <paramref name="values"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="values"/> is null.</exception>
		public static int RankLess(int key, int[] values)
		{
			int index = Rank(key, values.Distinct().ToArray(), false);
			return index == -1 ? 0 : index;
		}

		/// <summary>
		/// Get the count of <paramref name="key"/> in <paramref name="values"/>.
		/// </summary>
		/// <param name="key">Value to search for in <paramref name="values"/>.</param>
		/// <param name="values">Sorted array of values.</param>
		/// <returns>The count of <paramref name="key"/> in <paramref name="values"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="values"/> is null.</exception>
		public static int RankCount(int key, int[] values)
		{
			int index = RankLess(key, values);
			int count = values[index] == key ? 1 : 0;
			for (int i = index + 1; i < values.Length; i++)
			{
				if (key == values[i]) count++;
				else break;
			}
			return count;
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
		public static void BinarySearch(string whitelistFile, string testFile, char shouldPrint)
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
			// Added Distinct() for Exercise 28
			var whitelist = File.ReadAllLines(whitelistFile).Select(f => int.Parse(f)).Distinct().OrderBy(i => i).ToArray();
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
		/// Returns the greatest common denominator of <paramref name="p"/> and <paramref name="q"/>.
		/// </summary>
		/// <param name="p">First value.</param>
		/// <param name="q">Second value.</param>
		/// <returns>The greatest common denominator</returns>
		/// <remarks>Uses Euclid's algorithm.</remarks>
		public static int Euclid(int p, int q)
		{
			return Euclid(p, q, false);
		}

		/// <summary>
		/// Returns the greatest common denominator of <paramref name="p"/> and <paramref name="q"/>.
		/// </summary>
		/// <param name="p">First value.</param>
		/// <param name="q">Second value.</param>
		/// <param name="shouldPrint">True if should write to Console <paramref name="p"/>, <paramref name="q"/>, and remainder values.</param>
		/// <returns>The greatest common denominator</returns>
		/// <remarks>Uses Euclid's algorithm.</remarks>
		public static int Euclid(int p, int q, bool shouldPrint)
		{
			if (q == 0) return p;
			int candidate = p % q;
			if (shouldPrint) Console.WriteLine($"High {p} Low {q} Remainder {candidate}");
			return Euclid(q, candidate, shouldPrint);
		}

		/// <summary>
		/// Sorts the three given integers in ascending order.
		/// </summary>
		/// <param name="a">First value to sort.</param>
		/// <param name="b">Second value to sort.</param>
		/// <param name="c">Third value to sort.</param>
		/// <returns>Values sorted in ascending order.</returns>
		public static IEnumerable<int> Sort(int a, int b, int c)
		{
			int t;
			if (a > b) { t = a; a = b; b = t; }
			if (a > c) { t = a; a = c; c = t; }
			if (b > c) { t = b; b = c; c = t; }
			return new[] { a, b, c };
		}

		/// <summary>
		/// The probability of successfully getting a certain number of occurences out of a total number of trials
		/// </summary>
		/// <param name="trials">Number of trials</param>
		/// <param name="successes">Number of successes</param>
		/// <param name="probability">Probability of success</param>
		/// <returns>The likelihood of the number of successes</returns>
		public static double RecursiveBinomial(int trials, int successes, double probability)
		{
			if ((trials == 0) && (successes == 0)) return 1.0;
			if ((trials < 0) || (successes < 0)) return 0.0;
			return (1 - probability) * RecursiveBinomial(trials - 1, successes, probability) + probability * RecursiveBinomial(trials - 1, successes - 1, probability);
		}

		/// <summary>
		/// The probability of successfully getting a certain number of occurences out of a total number of trials
		/// </summary>
		/// <param name="trials">Number of trials</param>
		/// <param name="successes">Number of successes</param>
		/// <param name="probability">Probability of success</param>
		/// <returns>The likelihood of the number of successes</returns>
		public static double Binomial(int trials, int successes, double probability)
		{
			return BinomialFactorial(trials, successes) * Math.Pow(probability, successes) * Math.Pow(1 - probability, trials - successes);
		}

		/// <summary>
		/// Returns the factorial of <paramref name="n"/>.
		/// </summary>
		/// <param name="n">Number to get the factorial.</param>
		/// <returns>The factorial of <paramref name="n"/>.</returns>
		public static BigInteger Factorial(int n)
		{
			BigInteger factorial = new(1);
			for (int i = n; i > 0; i--)
			{
				factorial *= i;
			}
			return factorial;
		}

		private static double BinomialFactorial(int trials, int successes)
		{
			return (double)(Factorial(trials) / (Factorial(trials - successes) * Factorial(successes)));
		}

		/// <summary>
		/// Returns a two dimensional boolean array where each i,j is true if the only common factor is one for the i and j positions.
		/// </summary>
		/// <param name="dimension">The dimensions of the array.</param>
		/// <returns>A two dimensional boolean array where each i,j is true if the only common factor is one for the i and j positions.</returns>
		public static bool[,] RelativelyPrime(int dimension)
		{
			bool[,] areRelativelyPrime = new bool[dimension, dimension];
			for (int i = 0; i < dimension; i++)
			{
				for (int j = 0; j < dimension; j++)
				{
					if (Euclid(i, j) == 1)
					{
						areRelativelyPrime[i, j] = true;
					}
				}
			}
			return areRelativelyPrime;
		}

		/// <summary>
		/// Creates <paramref name="n"/> equally spaced points on a unit circle. Every pair of points may be connected
		/// based on <paramref name="probability"/>.
		/// </summary>
		/// <param name="n">The number of points to create on a unit circle.</param>
		/// <param name="probability">The probability any two points are connected. Must be from 0 to 1.</param>
		public static IEnumerable<PointPair> RandomConnections(int n, double probability)
		{
			if (n < 2) throw new ArgumentException("Must be at lease two points", nameof(n));
			if (probability < 0 || probability > 1.0) throw new ArgumentException("Must be from 0 to 1", nameof(probability));

			double pointAngle = 360.0 / n;
			List<Point> points = new();
			for (int i = 0; i < n; i++)
			{
				double angleInRadians = pointAngle * i * Math.PI / 180;
				points.Add(new Point(Math.Cos(angleInRadians), Math.Sin(angleInRadians)));
			}

			List<PointPair> pointPairs = new();
			Random random = new();
			for (int j = 0; j < n; j++)
			{
				PointPair pointPair;
				if (j + 1 == n)
				{
					pointPair = new(points[j], points[0]);
					pointPair.Connected = random.NextDouble() <= probability;
					pointPairs.Add(pointPair);
					break;
				}
				pointPair = new(points[j], points[j + 1]);
				pointPair.Connected = random.NextDouble() <= probability;
				pointPairs.Add(pointPair);
			}
			return pointPairs;
		}

		/// <summary>
		/// Given a <paramref name="sequence"/> this method console writes a histogram of the values that fall into
		/// intervals given by (<paramref name="right"/> - <paramref name="left"/>) / <paramref name="intervals"/>. 
		/// </summary>
		/// <param name="sequence">Sequence of numbers to create a histogram.</param>
		/// <param name="intervals">Number of intervals.</param>
		/// <param name="left">Bottom of the interval.</param>
		/// <param name="right">Top of the interval.</param>
		public static int[] Histogram(double[] sequence, int intervals, double left, double right)
		{
			int[] histogram = new int[intervals];
			double average = (right - left) / intervals;
			for (int i = 0; i < sequence.Length; i++) // iterate through all numbers in sequence
			{
				for (int j = 0; j < intervals; j++) // iterate through each interval
				{
					if (sequence[i] >= average * j && sequence[i] < average * (j + 1)) // does sequence number fall in this interval?
					{
						histogram[j] += 1;
					}
				}
			}

			for (int i = 0; i < histogram.Length; i++)
			{
				for (int j = 0; j < histogram[i]; j++)
				{
					Console.Write("x");
				}
				Console.WriteLine();
			}
			return histogram;
		}

		/// <summary>
		/// Returns the vector dot product of vector <paramref name="a"/> and vector <paramref name="b"/>.
		/// </summary>
		/// <param name="a">The first vector to calculate. Must be the same length as <paramref name="b"/>.</param>
		/// <param name="b">The second vector to calculat. Must be the same length as <paramref name="a"/>.</param>
		/// <returns>The vector dot product of <paramref name="a"/> and <paramref name="b"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if any parameter is null.</exception>
		/// <exception cref="ArgumentException">Throw if the lengths of each parameter are not equal.</exception>
		public static double VectorDot(double[] a, double[] b)
		{
			if (a is null) throw new ArgumentNullException(nameof(a));
			if (b is null) throw new ArgumentNullException(nameof(b));
			if (a.Length != b.Length) throw new ArgumentException($"Length of {nameof(a)} must equal the length {nameof(b)}");

			double dotProduct = 0;
			for (int i = 0; i < a.Length; i++)
			{
				dotProduct += a[i] * b[i];
			}

			return dotProduct;
		}

		/// <summary>
		/// Returns the dot product of matrix <paramref name="a"/> and matrix <paramref name="b"/>.
		/// </summary>
		/// <param name="a">The first matrix to calculate the dot product.</param>
		/// <param name="b">The second matrix to calculate the dot product.</param>
		/// <returns>The product of matrix <paramref name="a"/> and matrix <paramref name="b"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if any parameter is null.</exception>
		/// <exception cref="ArgumentException">Thrown if the number of rows of <paramref name="a"/> is not equal to the columns of <paramref name="b"/> or
		/// the numbers of columns of <paramref name="a"/> is not equal to the rows of <paramref name="b"/>.</exception>
		public static double[,] MatrixProduct(double[,] a, double[,] b)
		{
			if (a is null) throw new ArgumentNullException(nameof(a));
			if (b is null) throw new ArgumentNullException(nameof(b));

			int aRows = a.GetLength(0);
			int aCols = a.GetLength(1);
			int bRows = b.GetLength(0);
			int bCols = b.GetLength(1);
			if (aRows != bCols && aCols != bRows) throw new ArgumentException(
				$"The number rows of {nameof(a)} must equal the columns of {nameof(b)} or the columns of {nameof(a)} must equal the rows of {nameof(b)}");

			List<double[]> aVectors = new();
			for (int i = 0; i < aRows; i++)
			{
				double[] aVector = new double[aCols];
				for (int j = 0; j < aCols; j++)
				{
					aVector[j] = a[i, j];
				}
				aVectors.Add(aVector);
			}
			List<double[]> bVectors = new();
			for (int i = 0; i < bCols; i++)
			{
				double[] bVector = new double[bRows];
				for (int j = 0; j < bRows; j++)
				{
					bVector[j] = b[j, i];
				}
				bVectors.Add(bVector);
			}

			double[,] result = new double[aRows, bCols];
			for (int i = 0; i < aRows; i++)
			{
				for (int j = 0; j < bCols; j++)
				{
					result[i, j] = VectorDot(aVectors[i], bVectors[j]);
				}
			}
			return result;
		}

		/// <summary>
		/// Returns matrix <paramref name="a"/> transposed.
		/// </summary>
		/// <param name="a">Matrix to transpose.</param>
		/// <returns>Matrix transposed.</returns>
		public static double[,] MatrixTranspose(double[,] a)
		{
			double[,] transposed = new double[a.GetLength(1), a.GetLength(0)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					transposed[j, i] = a[i, j];
				}
			}

			return transposed;
		}

		/// <summary>
		/// Returns the product of matrix <paramref name="a"/> by vector <paramref name="x"/>.
		/// </summary>
		/// <param name="a">Matrix to multiply.</param>
		/// <param name="x">Vector to multiply.</param>
		/// <returns>The product of the matrix by the vector.</returns>
		public static double[] MatrixVectorProduct(double[,] a, double[] x)
		{
			double[,] b = new double[x.Length, 1];
			for (int i = 0; i < x.Length; i++)
			{
				b[i, 0] = x[i];
			}

			var matrixProduct = MatrixProduct(a, b);

			int aRows = a.GetLength(0);
			double[] product = new double[aRows];
			for (int i = 0; i < aRows; i++)
			{
				product[i] = matrixProduct[i, 0];
			}

			return product;
		}

		/// <summary>
		/// Returns the product of vector <paramref name="y"/> by matrix <paramref name="a"/>.
		/// </summary>
		/// <param name="y">Vector to multiply.</param>
		/// <param name="a">Matrix to multiply.</param>
		/// <returns>The product of the vector by matrix.</returns>
		public static double[] VectorMatrixProduct(double[] y, double[,] a)
		{
			double[,] b = new double[y.Length, 1];
			for (int i = 0; i < y.Length; i++)
			{
				b[i, 0] = y[i];
			}

			var matrixProduct = MatrixProduct(a, b);

			int aRows = a.GetLength(0);
			double[] product = new double[aRows];
			for (int i = 0; i < aRows; i++)
			{
				product[i] = matrixProduct[i, 0];
			}

			return product;
		}

		private double _min = double.MaxValue;
		private double _max = double.MinValue;

		/// <summary>
		/// Returns the minimum and maximum values for a series of calls.
		/// </summary>
		/// <param name="value">The current value to evaluate against the current minimum and maximum.</param>
		/// <returns>The current minimum and maximum values.</returns>
		/// <remarks>This method tracks the minimum and maximum via filtering without having to save every value in an array.</remarks>
		public (double min, double max) MinMax(double value)
		{
			if (value < _min) _min = value;
			if (value > _max) _max = value;

			return (_min, _max);
		}

		private readonly List<double> _median = new();

		/// <summary>
		/// Returns the median value for all given values.
		/// </summary>
		/// <param name="value">Value to add to list of median values.</param>
		/// <returns>The median is the midpoint of all sorted values. For an odd length list it is the exact midpoint,
		/// for an even length list then the average of the two middle numbers. This method does require saving all 
		/// given values.</returns>
		public double Median(double value)
		{
			_median.SortedInsert(value);

			bool isEventLength = _median.Count % 2 == 0;
			int midPoint = _median.Count / 2;

			return isEventLength ? (_median[midPoint] + _median[midPoint - 1]) / 2.0 : _median[midPoint];
		}

		private readonly List<double> _smallest = new();

		/// <summary>
		/// Gets the index of teh smalles value given over multiple calls.
		/// </summary>
		/// <param name="value">Value to add to the list.</param>
		/// <param name="index">The index of the smallest element.</param>
		/// <returns>The smallest element given.</returns>
		/// <remarks>The smallest element is in the 0th position. The given values are stored in ascending order.</remarks>
		public double Smallest(double value, int index)
		{
			_smallest.SortedInsert(value);

			return _smallest.Count > index ? _smallest[index] : double.NaN;
		}

		private double _sumOfSquares = 0;

		/// <summary>
		/// Returns the sum of squares of all given values.
		/// </summary>
		/// <param name="value">Value to square then add to all previous values.</param>
		/// <returns>The sum of the squares of all given values.</returns>
		public double SumOfSquares(double value)
		{
			_sumOfSquares += Math.Pow(value, 2);
			return _sumOfSquares;
		}

		private double _averageSum = 0;
		private double _averageCount = 0;

		/// <summary>
		/// Gets the average of all given values.
		/// </summary>
		/// <param name="value">Value to average.</param>
		/// <returns>The average of all given values.</returns>
		public double Average(double value)
		{
			_averageCount++;
			_averageSum += value;
			return _averageSum / _averageCount;
		}

		private readonly List<double> _percentGreater = new();

		/// <summary>
		/// Returns the percent of all given numbers that are greater than the average.
		/// </summary>
		/// <param name="value">Value to add to collection.</param>
		/// <returns>The percent of all given numbers that are greater than the average.</returns>
		public double PercentGreater(double value)
		{
			_percentGreater.SortedInsert(value);

			double average = _percentGreater.Average();
			int count = _percentGreater.Count;

			int index = _percentGreater.GetIndex(average);
			while (index < count && _percentGreater[index] <= average)
			{
				index++;
			}

			return (count - index) * 1.0 / count;
		}

		private readonly List<double> _inOrder = new();

		/// <summary>
		/// Prints all given numbers in order.
		/// </summary>
		/// <param name="value">Number to print in order.</param>
		public void PrintInOrder(double value)
		{
			_inOrder.SortedInsert(value);
			_inOrder.ForEach(v => Console.Write($"{v} "));
			Console.WriteLine();
		}

		private readonly List<double> _randomOrder = new();
		private readonly Random _random = new();

		/// <summary>
		/// Prints the given numbers in random order.
		/// </summary>
		/// <param name="value">Value to print in random order.</param>
		public void PrintRandom(double value)
		{
			_randomOrder.Add(value);

			var randomCopy = new List<double>(_randomOrder);

			for (int i = 0; i < _randomOrder.Count; i++)
			{
				int index = _random.Next(randomCopy.Count);
				Console.Write($"{randomCopy[index]} ");
				randomCopy.RemoveAt(index);
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Returns the standard distribution for two dice with <paramref name="sides"/>.
		/// </summary>
		/// <param name="sides">The number of side fo the two dice.</param>
		/// <returns>The standard distribution for two dice with <paramref name="sides"/>.</returns>
		public static IEnumerable<double> DiceDistribution(int sides)
		{
			double[] dist = new double[2 * sides + 1];
			for (int i = 1; i <= sides; i++)
			{
				for (int j = 1; j <= sides; j++)
				{
					dist[i + j] += 1.0;
				}
			}

			for (int k = 2; k <= 2 * sides; k++)
			{
				dist[k] /= 36.0;
			}
			return dist;
		}

		/// <summary>
		/// Simulates rolling two dice with <paramref name="sides"/> for <paramref name="rolls"/>.
		/// </summary>
		/// <param name="sides">Number of sides of the two dice.</param>
		/// <param name="rolls">Number of times to roll the two dice.</param>
		/// <returns>The distribution of rolls.</returns>
		public static IEnumerable<double> DiceSimulation(int sides, int rolls)
		{
			Random random = new();
			double[] dist = new double[2 * sides + 1];
			int roll1;
			int roll2;
			for (int i = 0; i < rolls; i++)
			{
				roll1 = random.Next(1, sides + 1);
				roll2 = random.Next(1, sides + 1);
				dist[roll1 + roll2] += 1;
			}

			for (int k = 2; k <= 2 * sides; k++)
			{
				dist[k] /= rolls;
			}

			return dist;
		}

		/// <summary>
		/// Randomly shuffles <paramref name="values"/>. The given array is unchanged.
		/// </summary>
		/// <param name="values">Values to shuffle.</param>
		/// <returns><paramref name="values"/> randomly shuffled.</returns>
		public static IEnumerable<double> Shuffle(double[] values)
		{
			var valuesCopy = new double[values.Length];
			Array.Copy(values, valuesCopy, values.Length);

			int valuesLength = valuesCopy.Length;
			Random random = new();
			for (int i = 0; i < valuesLength; i++)
			{
				int r = i + random.Next(0, valuesLength - i);
				double temp = valuesCopy[i];
				valuesCopy[i] = valuesCopy[r];
				valuesCopy[r] = temp;
			}

			return valuesCopy;
		}

		/// <summary>
		/// Badly shuffles <paramref name="values"/>. The given array is unchanged.
		/// </summary>
		/// <param name="values">Values to shuffle.</param>
		/// <returns><paramref name="values"/> badly shuffled.</returns>
		public static IEnumerable<double> BadShuffle(double[] values)
		{
			var valuesCopy = new double[values.Length];
			Array.Copy(values, valuesCopy, values.Length);

			int valuesLength = valuesCopy.Length;
			Random random = new();
			for (int i = 0; i < valuesLength; i++)
			{
				int r = random.Next(0, valuesLength - i);
				double temp = valuesCopy[i];
				valuesCopy[i] = valuesCopy[r];
				valuesCopy[r] = temp;
			}

			return valuesCopy;
		}

		/// <summary>
		/// Tests <see cref="Shuffle(double[])"/> with <paramref name="values"/>, where value[i] = i, with <paramref name="shuffles"/>.
		/// </summary>
		/// <param name="values">Array where values[i] = i.</param>
		/// <param name="shuffles">Number of times to shuffle <paramref name="values"/>.</param>
		/// <returns>Distribution of the number of times each value appeared in each position.</returns>
		public static double[,] ShuffleTest(double[] values, int shuffles)
		{
			int length = values.Length;
			double[,] dist = new double[length, length];
			for (int i = 0; i < shuffles; i++)
			{
				var shuffled = Shuffle(values);
				for (int j = 0; j < length; j++)
				{
					int value = (int)shuffled.ElementAt(j);
					dist[value, j] += 1;
				}
			}
			return dist;
		}

		/// <summary>
		/// Searches an array for the given value returning the index of the value or -1 if not found.
		/// </summary>
		/// <param name="value">Value to search for.</param>
		/// <param name="a">Array to search.</param>
		/// <returns>The index of the value or -1 if not found.</returns>
		public static int BruteForceSearch(int value, int[] a)
		{
			for (int i = 0; i < a.Length; i++)
				if (a[i] == value) return i;
			return -1;
		}

		/// <summary>
		/// Generates a collection of <paramref name="n"/> random values.
		/// </summary>
		/// <param name="n">Number of random values to generate.</param>
		/// <param name="min">Minimum value to generate. Default is 100,000.</param>
		/// <param name="max">Maximum value to generate. Defualt is 100,000.</param>
		/// <returns>Random collection of values within the <paramref name="min"/> and <paramref name="max"/>.</returns>
		public static IEnumerable<int> GenerateRandomCollection(int n, int min = 100_000, int max = 100_000 )
		{
			Random random = new();
			List<int> values = new(n);
			for (int i = 0; i < n; i++)
			{
				values.Add(random.Next(0, max + 1));
			}
			return values;
		}
	}
}
