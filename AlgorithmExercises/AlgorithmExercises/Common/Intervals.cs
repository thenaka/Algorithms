using System;

namespace AlgorithmExercises.Common
{
	/// <summary>
	/// One dimensional interval
	/// </summary>
	public class Interval1D
	{
		/// <summary>
		/// The minimum point of the interval.
		/// </summary>
		public double Min { get; init; }

		/// <summary>
		/// The maximum point of the interval.
		/// </summary>
		public double Max { get; init; }
		
		/// <summary>
		/// One dimesional interval.
		/// </summary>
		/// <param name="min">The minimum point.</param>
		/// <param name="max">The maximum point.</param>
		/// <exception cref="ArgumentException"><paramref name="min"/> is greater than <paramref name="max"/>.</exception>
		public Interval1D(double min, double max)
		{
			if (min > max) throw new ArgumentException($"{nameof(min)} must be less than or equal to {nameof(max)}");

			Min = min;
			Max = max;
		}
		
		/// <summary>
		/// Determines if <paramref name="x"/> lies within <see cref="Min"/> and <see cref="Max"/> inclusive.
		/// </summary>
		/// <param name="x">Value to determine if it lies in the interval.</param>
		/// <returns>True if <paramref name="x"/> lies within the interval, otherwise false.</returns>
		public bool Contains(double x)
		{
			return x >= Min && x <= Max;
		}

		/// <summary>
		/// Determines if <paramref name="interval"/> is contained within this interval.
		/// </summary>
		/// <param name="interval">Interval to see if it is contained.</param>
		/// <returns>True if <paramref name="interval"/> is contained in this interval.</returns>
		public bool Contains(Interval1D interval)
		{
			return Contains(interval.Min) && Contains(interval.Max);
		}
		
		/// <summary>
		/// Determines if <paramref name="interval"/> intersects this one.
		/// </summary>
		/// <param name="interval">Interval to determine intersection.</param>
		/// <returns>True if <paramref name="interval"/> intersects this one.</returns>
		public bool Intersects(Interval1D interval)
		{
			return Contains(interval.Min) || Contains(interval.Max);
		}
		
		/// <summary>
		/// String representation of this.
		/// </summary>
		/// <returns>String representation of this.</returns>
		public override string ToString()
		{
			return $"Interval min:{Min:N2} max:{Max:N2}";
		}
	}

	public class Interval2D
	{
		private readonly Interval1D _xInterval;
		private readonly Interval1D _yInterval;

		/// <summary>
		/// Two-dimensional interval.
		/// </summary>
		/// <param name="x">The x-axis interval.</param>
		/// <param name="y">The y-axis interval.</param>
		/// <exception cref="ArgumentNullException">Thrown if either parameter is null.</exception>
		public Interval2D(Interval1D x, Interval1D y)
		{
			_xInterval = x ?? throw new ArgumentNullException(nameof(x));
			_yInterval = y ?? throw new ArgumentNullException(nameof(y));
		}

		/// <summary>
		/// Area of the interval.
		/// </summary>
		/// <returns>The total area of the interval.</returns>
		public double Area()
		{
			return (_xInterval.Max - _xInterval.Min) * (_yInterval.Max - _yInterval.Min);
		}
		
		/// <summary>
		/// Get if this two-dimensional interval contains the given <paramref name="point"/>.
		/// </summary>
		/// <param name="point">The point to determine if it is contained in this two-dimensional interval.</param>
		/// <returns>True if the point is contained in this two-dimensional interval, otherwise false.</returns>
		public bool Contains(Point point)
		{
			return _xInterval.Contains(point.X) && _yInterval.Contains(point.Y);
		}

		/// <summary>
		/// Determines if <paramref name="interval"/> is contained within this interval.
		/// </summary>
		/// <param name="interval">Interval to determine if it is contained in this one.</param>
		/// <returns>True if <paramref name="interval"/> is contained in this interval.</returns>
		public bool Contains(Interval2D interval)
		{
			return _xInterval.Contains(interval._xInterval) && _yInterval.Contains(interval._yInterval);
		}
		
		/// <summary>
		/// Get if this interval intersects the given <paramref name="interval"/>.
		/// </summary>
		/// <param name="interval">The interval to see if it intersects this interval.</param>
		/// <returns>True if the given two-dimensional interval intersects this two-dimensional interval, otherwise false.</returns>
		public bool Intersects(Interval2D interval)
		{
			return _xInterval.Intersects(interval._xInterval) && _yInterval.Intersects(interval._yInterval);
		}

		public override string ToString()
		{
			return $"X {_xInterval} Y {_yInterval}";
		}
	}
}
