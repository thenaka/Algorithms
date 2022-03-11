using AlgorithmExercises.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExercises.Chapter1
{
	public class Section2
	{
		private static readonly Random _random = new();

		/// <summary>
		/// Get <paramref name="n"/> number of random points all within a unit square.
		/// </summary>
		/// <param name="n">Number of points to randomly generate.</param>
		/// <returns><paramref name="n"/> number of random points within a unit square.</returns>
		public static IEnumerable<Point> GetRandomPoints(int n)
		{
			List<Point> points = new();

			for (int i = 0; i < n; i++)
			{
				double x = _random.NextDouble();
				double y = _random.NextDouble();
				points.Add(new Point(x, y));
			}
			return points;
		}
	}
}
