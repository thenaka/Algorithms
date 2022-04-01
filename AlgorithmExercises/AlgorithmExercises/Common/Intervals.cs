using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExercises.Common
{
	/// <summary>
	/// One dimensional interval
	/// </summary>
	public class Interval1D
	{
		/// <summary>
		/// The leftmost point of the interval.
		/// </summary>
		public double Left { get; init; }
		/// <summary>
		/// The rightmost point of the interval.
		/// </summary>
		public double Right { get; init; }
		/// <summary>
		/// One dimesional interval.
		/// </summary>
		/// <param name="left">The leftmost point.</param>
		/// <param name="right">The rightmost point.</param>
		/// <exception cref="ArgumentException"><paramref name="left"/> is greater than <paramref name="right"/>.</exception>
		public Interval1D(double left, double right)
		{
			if (left > right) throw new ArgumentException($"{nameof(left)} must be less than or equal to {nameof(right)}");

			Left = left;
			Right = right;
		}
		/// <summary>
		/// Determines if <paramref name="x"/> lies within <see cref="Left"/> and <see cref="Right"/> inclusive.
		/// </summary>
		/// <param name="x">Value to determine if it lies in the interval.</param>
		/// <returns>True if <paramref name="x"/> lies within the interval, otherwise false.</returns>
		public bool Contains(double x)
		{
			return x >= Left && x <= Right;
		}

		/// <summary>
		/// Determines if <paramref name="interval"/> intersects this interval.
		/// </summary>
		/// <param name="interval">Interval to determine intersection.</param>
		/// <returns>True if <paramref name="interval"/> intersects this interval.</returns>
		public bool Intersect(Interval1D interval)
		{
			return Contains(interval.Left) || Contains(interval.Right);
		}
	}

	public class Interval2D
	{

	}
}
