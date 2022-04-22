using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmExercises.Common
{
	/// <summary>
	/// Implementation of binary search algorithm
	/// </summary>
	public class BinarySearch
	{
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
		/// <param name="shouldWriteKeysExamined">True if should write to Console the number of keys examined. Default is false.</param>
		/// <returns>The index of <paramref name="key"/> in <paramref name="values"/>. Returns -1 if not found.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="values"/> is null.</exception>
		public static int Rank(int key, int[] values, bool shouldTrace, bool shouldWriteKeysExamined = false)
		{
			if (values is null) throw new ArgumentNullException(nameof(values));

			int depth = 0;
			int keysExamined = 0;
			int lo = 0;
			int hi = values.Length - 1;
			while (lo <= hi)
			{
				keysExamined++;
				if (shouldTrace) Console.WriteLine($"{new string('\t', depth)}lo:{lo} hi:{hi}");
				int mid = lo + (hi - lo) / 2;
				if (key < values[mid])
				{
					hi = mid - 1;
				}
				else if (key > values[mid])
				{
					lo = mid + 1;
				}
				else
				{
					if (shouldWriteKeysExamined) Console.WriteLine($"Keys Examined:{keysExamined}");
					return mid;
				}
				depth++;
			}
			if (shouldWriteKeysExamined) Console.WriteLine($"Keys Examined:{keysExamined}");
			return -1;
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
		public static void FileSearch(string whitelistFile, string testFile, char shouldPrint)
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
		/// Returns a collection of all vales from <paramref name="candidate"/> that are int <paramref name="list"/>.
		/// </summary>
		/// <param name="candidate">Sorted collection of numbers to check if they are in<paramref name="list"/>.</param>
		/// <param name="list">Sorted list of number to check.</param>
		/// <returns>Sorted collection of values from <paramref name="candidate"/> that are in <paramref name="list"/>.</returns>
		public static IEnumerable<int> InCollection(int[] candidate, int[] list)
		{
			List<int> inList = new();
			for (int i = 0; i < candidate.Length; i++)
			{
				if (Rank(candidate[i], list) != -1)
					inList.Add(candidate[i]);
			}
			return inList;
		}
	}
}
