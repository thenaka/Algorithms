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
	}
}
