using AlgorithmExercises.Common;
using NUnit.Framework;
using System;
using System.Linq;

namespace AlgorithmExercisesTests.Common
{
	[TestFixture]
	public class CommonTests
	{
		[TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2, 2, 3 }, TestName = "List_SortedInsert_ReturnsExpected")]
		[TestCase(new int[] { }, 2, new int[] { 2 }, TestName = "List_SortedInsert_WhenOneValue_ReturnsExpected")]
		public void List_SortedInsert_ReturnsExpected(int[] values, int value, int[] expected)
		{
			// Arrange
			var list = values.ToList();

			// Act
			list.SortedInsert(value);

			// Assert
			Assert.That(list, Is.EqualTo(expected));
		}

		[TestCase(new int[] { 1, 2, 3 }, 2, 1, TestName = "List_GetIndex_ReturnsExpected")]
		[TestCase(new int[] { 1, 2, 3 }, 4, 3, TestName = "List_GetIndex_WhenValueExceedsAllValues_ReturnsExpected")]
		[TestCase(new int[] { 1, 2, 3, 5, 6, 7, 8 }, 4, 3, TestName = "List_GetIndex_WhenValueNotInValues_ReturnsExpected")]
		[TestCase(new int[] { 1, 2, 2, 3 }, 2, 1, TestName = "List_GetIndex_WhenTwoDuplicates_ReturnsExpected")]
		[TestCase(new int[] { 1, 2, 2, 2, 3 }, 2, 2, TestName = "List_GetIndex_WhenThreeDuplicates_ReturnsExpected")]
		public void List_GetIndex_ReturnsExpected(int[] values, int value, int expected)
		{
			// Arrange
			var list = values.ToList();

			// Act
			var result = list.GetIndex(value);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(2, 2, 45, TestName = "Point_Theta_ReturnsCorrectAngle")]
		[TestCase(0.86602540378, 0.5, 30, TestName = "Point_Theta_Returns30DegreeAngle")]
		[TestCase(0.5, 0.86602540378, 60, TestName = "Point_Theta_Returns60DegreeAngle")]
		public void Point_Theta_ReturnsCorrectAngle(double x, double y, double expected)
		{
			// Arrange
			var point = new Point(x, y);

			// Act
			var result = point.Theta;

			// Assert
			Assert.That(result, Is.EqualTo(expected).Within(0.000001));
		}

		[TestCase(1, 1, 1, 1, 0, TestName = "Point_Distance_ReturnsCorrectValue")]
		[TestCase(1, 1, 5, 4, 5, TestName = "Point_Distance_WhenDistance5_ReturnsCorrectValue")]
		public void Point_Distance_ReturnsCorrectValue(double x1, double y1, double x2, double y2, double expected)
		{
			// Arrange
			var point1 = new Point(x1, y1);
			var point2 = new Point(x2, y2);

			// Act
			var distance = point1.DistanceTo(point2);

			// Assert
			Assert.That(distance, Is.EqualTo(expected));
		}

		[Test]
		public void Interval1D_Constructor_WhenMinExceedsMax_ThrowsArgumentException()
		{
			Assert.Throws<ArgumentException>(() => new Interval1D(min: 3, max: 1));
		}

		[TestCase(1, 3, 2, true, TestName = "Interval1D_Contains_ReturnsExpected")]
		[TestCase(1, 3, 4, false, TestName = "Interval1D_Contains_WhenOutsideInterval_ReturnsExpected")]
		[TestCase(1, 3, 1, true, TestName = "Interval1D_Contains_WhenOnMinEdgeOfInterval_ReturnsExpected")]
		[TestCase(1, 3, 3, true, TestName = "Interval1D_Contains_WhenOnMaxEdgeOfInterval_ReturnsExpected")]
		public void Interval1D_Contains_ReturnsExpected(double min, double max, double contains, bool expected)
		{
			// Arrange
			Interval1D interval = new(min, max);

			// Act
			bool result = interval.Contains(contains);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(1, 3, 2, 4, true, TestName = "Interval1D_Intersects_ReturnsExpected")]
		[TestCase(1, 3, 4, 6, false, TestName = "Interval1D_Intersects_WhenNoOverlap_ReturnsExpected")]
		[TestCase(1, 3, 0, 1, true, TestName = "Interval1D_Intersects_WhenMinEdgeOverlap_ReturnsExpected")]
		[TestCase(1, 3, 3, 6, true, TestName = "Interval1D_Intersects_WhenMaxEdgeOverlap_ReturnsExpected")]
		public void Interval1D_Intersects_ReturnsExpected(double min1, double max1, double min2, double max2, bool expected)
		{
			// Arrange
			Interval1D interval1 = new(min1, max1);
			Interval1D interval2 = new(min2, max2);

			// Act
			bool intersects1 = interval1.Intersects(interval2);
			bool intersects2 = interval2.Intersects(interval1);

			// Assert
			Assert.That(intersects1, Is.EqualTo(expected));
			Assert.That(intersects2, Is.EqualTo(expected));
		}

		[TestCase(1, 3, 2, 4, 2, 3, true, TestName = "Interval2D_Contains_ReturnsExpected")]
		[TestCase(1, 3, 2, 4, 1, 3, true, TestName = "Interval2D_Contains_WhenPointOnXMin_ReturnsExpected")]
		[TestCase(1, 3, 2, 4, 3, 3, true, TestName = "Interval2D_Contains_WhenPointOnXMax_ReturnsExpected")]
		[TestCase(1, 3, 2, 4, 2, 2, true, TestName = "Interval2D_Contains_WhenPointOnYMin_ReturnsExpected")]
		[TestCase(1, 3, 2, 4, 2, 4, true, TestName = "Interval2D_Contains_WhenPointOnYMax_ReturnsExpected")]
		[TestCase(1, 3, 2, 4, 4, 3, false, TestName = "Interval2D_Contains_WhenPointXOutsideInterval_ReturnsExpected")]
		[TestCase(1, 3, 2, 4, 2, 5, false, TestName = "Interval2D_Contains_WhenPointYOutsideInterval_ReturnsExpected")]
		public void Interval2D_Contains_ReturnsExpected(double xIntervalMin, double xIntervalMax, double yIntervalMin, double yIntervalMax,
			double xPoint, double yPoint, bool expected)
		{
			// Assert
			Interval1D xInterval = new(xIntervalMin, xIntervalMax);
			Interval1D yInterval = new(yIntervalMin, yIntervalMax);
			Interval2D interval2D = new(xInterval, yInterval);
			Point point = new(xPoint, yPoint);

			// Act
			bool result = interval2D.Contains(point);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(1, 3, 2, 4, 2, 3, 3, 5, true, TestName = "Interval2D_Intersects_ReturnsExpected")]
		[TestCase(1, 3, 2, 4, 4, 6, 3, 5, false, TestName = "Interval2D_Intersects_WhenXIntervalOutside_ReturnsExpected")]
		[TestCase(1, 3, 2, 4, 2, 3, 5, 7, false, TestName = "Interval2D_Intersects_WhenYIntervalOutside_ReturnsExpected")]
		[TestCase(1, 3, 2, 4, 3, 4, 3, 5, true, TestName = "Interval2D_Intersects_WhenXIntervalOnEdge_ReturnsExpected")]
		[TestCase(1, 3, 2, 4, 2, 4, 4, 5, true, TestName = "Interval2D_Intersects_WhenXIntervalOnEdge_ReturnsExpected")]
		public void Interval2D_Intersects_ReturnsExpected(
			double xInterval1Min, double xInterval1Max, double yInterval1Min, double yInterval1Max,
			double xInterval2Min, double xInterval2Max, double yInterval2Min, double yInterval2Max,
			bool expected)
		{
			// Assert
			Interval1D xInterval1 = new(xInterval1Min, xInterval1Max);
			Interval1D yInterval1 = new(yInterval1Min, yInterval1Max);
			Interval2D firstInterval2D = new(xInterval1, yInterval1);
			Interval1D xInterval2 = new(xInterval2Min, xInterval2Max);
			Interval1D yInterval2 = new(yInterval2Min, yInterval2Max);
			Interval2D secondInterval2D = new(xInterval2, yInterval2);

			// Act
			bool result = firstInterval2D.Intersects(secondInterval2D);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Interval2D_Constructor_WhenParameterNull_ThrowsException()
		{
			Assert.Multiple(() =>
			{
				Assert.Throws<ArgumentNullException>(() => new Interval2D(null, new Interval1D(1, 2)));
				Assert.Throws<ArgumentNullException>(() => new Interval2D(new Interval1D(1, 2), null));
			});
		}

		[TestCase(5, 7, 35, TestName ="LeastCommonMultiple_ReturnsExpected")]
		[TestCase(5, 10, 10, TestName ="LeastCommonMultiple_WhenSecondNumber_ReturnsExpected")]
		[TestCase(4, 6, 12, TestName ="LeastCommonMultiple_WhenMutipleOfBoth_ReturnsExpected")]
		public void LeastCommonMultiple_ReturnsExpected(long p, long q, long expected)
		{
			// Arrange, Act
			long actual = Algorithms.LeastCommonMultiple(p, q);

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
