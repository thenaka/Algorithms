using AlgorithmExercises.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises.Chapter1
{
	public class Section2
	{
		private static readonly Random _random = new();

		/// <summary>
		/// Get <paramref name="n"/> number of random <see cref="Point"/> all within a unit square.
		/// </summary>
		/// <param name="n">Number of <see cref="Point"/> to randomly generate.</param>
		/// <returns><paramref name="n"/> number of random <see cref="Point"/> within a unit square.</returns>
		public static IEnumerable<Point> GetRandomPoints(int n)
		{
			for (int i = 0; i < n; i++)
			{
				double x = _random.NextDouble();
				double y = _random.NextDouble();
				Point point = new Point(x, y);
				yield return point;
			}
		}

		/// <summary>
		/// Get <paramref name="n"/> random <see cref="Interval1D"/>.
		/// </summary>
		/// <param name="n">Number of <see cref="Interval1D"/> to randomly generate.</param>
		/// <returns><paramref name="n"/> number of random <see cref="Interval1D"/>.</returns>
		public static IEnumerable<Interval1D> GetRandomInterval1D(int n)
		{
			for (int i = 0; i < n; i++)
			{
				double val1 = _random.NextDouble();
				double val2 = _random.NextDouble();
				yield return new Interval1D(Math.Min(val1, val2), Math.Max(val1, val2));
			}
		}

		/// <summary>
		/// Gets <paramref name="n"/> random <see cref="Interval2D"/>.
		/// </summary>
		/// <param name="n">Number of <see cref="Interval2D"/> to randomly generate.</param>
		/// <returns><paramref name="n"/> number of random <see cref="Interval2D"/>.</returns>
		public static IEnumerable<Interval2D> GetRandomInterval2D(int n)
		{
			IEnumerable<Interval1D> intervals = GetRandomInterval1D(n * 2);
			for (int i = 0; i < n * 2; i += 2)
			{
				yield return new Interval2D(intervals.ElementAt(i), intervals.ElementAt(i + 1));
			}
		}

		/// <summary>
		/// Determines if <paramref name="s"/> and <paramref name="t"/> are circular rotations of each other.
		/// </summary>
		/// <param name="s">First string to check.</param>
		/// <param name="t">Second string to check.</param>
		/// <returns>True if <paramref name="s"/> and <paramref name="t"/> are circular rotations of each other.</returns>
		public static bool CircularShift(string s, string t)
		{
			return $"{s}{s}".Contains(t);
		}

		/// <summary>
		/// Reverses <paramref name="s"/>.
		/// </summary>
		/// <param name="s">String to reverse.</param>
		/// <returns><paramref name="s"/> reversed.</returns>
		public static string Reverse(string s)
		{
			int n = s.Length;
			if (n <= 1) return s;

			int halfN = n / 2;
			string a = s.Substring(0, halfN);
			string b = s.Substring(halfN, n - halfN);
			return Reverse(b) + Reverse(a);
		}

		/// <summary>
		/// Returns a collection of length <paramref name="n"/> filled with random integers.
		/// </summary>
		/// <param name="n">The number of integers to return.</param>
		/// <returns>A collection of length <paramref name="n"/> filled with random integers.</returns>
		public static IEnumerable<int> GetRandomInts(int n)
		{
			for (int i = 0; i < n; i++)
			{
				yield return _random.Next(int.MinValue, int.MaxValue);
			}
		}
	}
}
