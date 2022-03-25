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

		/// <summary>
		/// Returns <paramref name="n"/> lines that start and end within a unit square.
		/// </summary>
		/// <param name="n">Number of random lines to return.</param>
		/// <returns><paramref name="n"/> lines that start and end within a unit square.</returns>
		public static IEnumerable<Line> GetRandomLLines(int n)
		{
			List<Line> lines = new();
			IEnumerable<Point> points = GetRandomPoints(n * 2);
			for (int i = 0; i < n; i++)
			{
				lines.Add(new Line(points.ElementAt(i), points.ElementAt(i + 1)));
			}
			return lines;
		}

		/// <summary>
		/// Returns <paramref name="n"/> line pairs that start and end within a unit square.
		/// </summary>
		/// <param name="n">Number of line pairs to return.</param>
		/// <returns><paramref name="n"/> line pairs that start and end within a unit square.</returns>
		public static IEnumerable<LinePair> GetRandomLinePairs(int n)
		{
			List<LinePair> pairs = new();
			IEnumerable<Line> lines = GetRandomLLines(n * 2);
			for (int i = 0; i < n; i++)
			{
				pairs.Add(new LinePair(lines.ElementAt(i), lines.ElementAt(i + 1)));
			}
			return pairs;
		}

		/// <summary>
		/// Determines if either line in <paramref name="linePair1"/> intersects either line in <paramref name="linePair2"/>.
		/// </summary>
		/// <param name="linePair1">First pair of lines to check.</param>
		/// <param name="linePair2">Second pair of lines to check.</param>
		/// <returns>True if either line in <paramref name="linePair1"/> intersects either line in <paramref name="linePair2"/>.</returns>
		public static bool DoIntersect(LinePair linePair1, LinePair linePair2)
		{
			if (linePair1 is null) throw new ArgumentNullException(nameof(linePair1));
			if (linePair2 is null) throw new ArgumentNullException(nameof(linePair2));

			if (DoIntersect(linePair1.Line1, linePair2.Line1)) return true;
			if (DoIntersect(linePair1.Line1, linePair2.Line2)) return true;
			if (DoIntersect(linePair1.Line2, linePair2.Line1)) return true;
			if (DoIntersect(linePair1.Line2, linePair2.Line2)) return true;
			return false;
		}

		/// <summary>
		/// Determines if <paramref name="line1"/> intersects <paramref name="line2"/>.
		/// </summary>
		/// <param name="line1">First line to check.</param>
		/// <param name="line2">Second line to check.</param>
		/// <returns>True if <paramref name="line1"/> intersects <paramref name="line2"/>, otherwise false.</returns>
		public static bool DoIntersect(Line line1, Line line2)
		{
			if (line1 is null) throw new ArgumentNullException(nameof(line1));
			if (line2 is null) throw new ArgumentNullException(nameof(line2));

			return DoIntersect(line1.Point1, line1.Point2, line2.Point1, line2.Point2);
		}

		/// <summary>
		/// Determines if line segment p1q1 and p2q2 intersect.
		/// </summary>
		/// <param name="p1">Start of first line segment.</param>
		/// <param name="q1">End of first line segment.</param>
		/// <param name="p2">Start of second line segment.</param>
		/// <param name="q2">End of second line segment.</param>
		/// <returns>True if line segment p1q1 and p2q2 intersect, otherwise false.</returns>
		/// <remarks>Code sour</remarks>
		public static bool DoIntersect(Point p1, Point q1, Point p2, Point q2)
		{
			if (p1 is null) throw new ArgumentNullException(nameof(p1));
			if (q1 is null) throw new ArgumentNullException(nameof(q1));
			if (p2 is null) throw new ArgumentNullException(nameof(p2));
			if (q2 is null) throw new ArgumentNullException(nameof(q2));

			// Find the four orientations needed for general and special cases
			Rotation o1 = Orientation(p1, q1, p2);
			Rotation o2 = Orientation(p1, q1, q2);
			Rotation o3 = Orientation(p2, q2, p1);
			Rotation o4 = Orientation(p2, q2, q1);

			// General case
			if (o1 != o2 && o3 != o4) return true;

			// Special Cases:

			// p1, q1 and p2 are collinear and p2 lies on segment p1q1
			if (o1 == Rotation.Collinear && OnSegment(p1, p2, q1)) return true;

			// p1, q1 and q2 are collinear and q2 lies on segment p1q1
			if (o2 == Rotation.Collinear && OnSegment(p1, q2, q1)) return true;

			// p2, q2 and p1 are collinear and p1 lies on segment p2q2
			if (o3 == Rotation.Collinear && OnSegment(p2, p1, q2)) return true;

			// p2, q2 and q1 are collinear and q1 lies on segment p2q2
			if (o4 == Rotation.Collinear && OnSegment(p2, q1, q2)) return true;

			return false; // Doesn't fall in any of the above cases
		}

		/// <summary>
		/// Given three collinear points p, q, r, the function checks if point q lies on line segment 'pr'
		/// </summary>
		/// <param name="p">Start point in line segment.</param>
		/// <param name="q">Point to check if lies on pr.</param>
		/// <param name="r">End point in line segment.</param>
		/// <returns>True if q lies on segment pr, otherwise false.</returns>
		private static bool OnSegment(Point p, Point q, Point r)
		{
			return q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
				   q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y);
		}

		/// <summary>
		/// Rotation direction.
		/// </summary>
		private enum Rotation
		{
			Collinear,
			Clockwise,
			Counterclockwise
		}

		/// <summary>
		/// Find orientation of ordered triplet (p, q, r).
		/// </summary>
		/// <param name="p">Start point of a line segment.</param>
		/// <param name="q">End point of a line segment.</param>
		/// <param name="r">Rotation point.</param>
		/// <returns><see cref="Rotation"/>.</returns>
		private static Rotation Orientation(Point p, Point q, Point r)
		{
			// See https://www.geeksforgeeks.org/orientation-3-ordered-points/
			// for details of below formula.
			double val = (q.Y - p.Y) * (r.X - q.X) -
					(q.X - p.X) * (r.Y - q.Y);

			if (val == 0) return Rotation.Collinear; // collinear

			return (val > 0) ? Rotation.Clockwise : Rotation.Counterclockwise;
		}

		//https://github.com/morrxy/algs4/blob/master/exercise/1.2.03/Interval2D_client.java
		//https://stackoverflow.com/questions/17639548/algorithms-by-sedgewick-wayne-exercise-1-2-3
		// public static bool IsBounded(LinePair boundingPair, LinePair linePair)
	}
}
