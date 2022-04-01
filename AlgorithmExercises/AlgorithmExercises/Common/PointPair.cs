using System;

namespace AlgorithmExercises.Common
{
	public class PointPair
	{
		public bool Connected { get; set; }
		public Point Point1 { get; init; }
		public Point Point2 { get; init; }
		public PointPair(Point p1, Point p2)
		{
			Point1 = p1 ?? throw new ArgumentNullException(nameof(p1));
			Point2 = p2 ?? throw new ArgumentNullException(nameof(p2));
		}
	}

	/// <summary>
	/// Represents a point in in an x, y coordinate system.
	/// </summary>
	public class Point
	{
		/// <summary>
		/// The x-coordinate of the point.
		/// </summary>
		public double X { get; init; }
		/// <summary>
		/// The y-coordinate of the point.
		/// </summary>
		public double Y { get; init; }
		/// <summary>
		/// The polar radius of the point.
		/// </summary>
		/// <remarks>The radius of the point from the origin (0,0).</remarks>
		public double Radius
		{
			get
			{
				return Math.Sqrt(X * X + Y * Y);
			}
		}
		/// <summary>
		/// The polar angle of the point in degrees.
		/// </summary>
		/// <remarks>The angle formed from the origin (0,0) to the point.</remarks>
		public double Theta
		{
			get
			{
				return Math.Atan(Y / X) * 180 / Math.PI;
			}
		}
		/// <summary>
		/// Get the distance to <paramref name="point"/>.
		/// </summary>
		/// <param name="point">Point to calculate distance to.</param>
		/// <returns>Distance to <paramref name="point"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="point"/> is null.</exception>
		public double DistanceTo(Point point)
		{
			if (point is null) throw new ArgumentNullException(nameof(point));
			double deltaX = point.X - X;
			double deltaY = point.Y - Y;
			return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
		}
		/// <summary>
		/// Point in the x, y coordinate system.
		/// </summary>
		/// <param name="x">The x position.</param>
		/// <param name="y">The y position.</param>
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}
		/// <summary>
		/// String representation of the point.
		/// </summary>
		/// <returns>The x and y position of the point.</returns>
		public override string ToString()
		{
			return $"x:{X:N2},y:{Y:N2}";
		}
	}
}
