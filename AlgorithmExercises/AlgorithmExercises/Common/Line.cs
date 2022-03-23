using System;

namespace AlgorithmExercises.Common
{
	public class Line
	{
		public Point Point1 { get; }
		public Point Point2 { get; }
		public Line(Point point1, Point point2)
		{
			Point1 = point1 ?? throw new ArgumentNullException(nameof(point1));
			Point2 = point2 ?? throw new ArgumentNullException(nameof(point2));
		}
		public override string ToString()
		{
			return $"Line {Point1} to {Point2}";
		}
	}

	public class Line2D
	{
		public Line Line1 { get; }
		public Line Line2 { get; }
		public Line2D(Line line1, Line line2)
		{
			Line1 = line1 ?? throw new ArgumentNullException(nameof(line1));
			Line2 = line2 ?? throw new ArgumentNullException(nameof(line2));
		}
	}
}
