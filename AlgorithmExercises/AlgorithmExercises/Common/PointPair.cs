namespace AlgorithmExercises.Common
{
	public class PointPair
	{
		public bool Connected { get; set; }
		public Point Point1 { get; init; }
		public Point Point2 { get; init; }
		public PointPair(Point p1, Point p2)
		{
			Point1 = p1;
			Point2 = p2;
		}
	}

	public class Point
	{
		public double X { get; init; }
		public double Y { get; init; }
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}
	}
}
