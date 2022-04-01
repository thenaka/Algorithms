using AlgorithmExercises.Common;
using NUnit.Framework;
using System.Linq;

namespace AlgorithmExercisesTests.Common
{
	[TestFixture]
	public class CommonTests
	{
		[TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2, 2, 3 }, TestName = "SortedInsert_ReturnsExpected")]
		[TestCase(new int[] { }, 2, new int[] { 2 }, TestName = "SortedInsert_WhenOneValue_ReturnsExpected")]
		public void SortedInsert(int[] values, int value, int[] expected)
		{
			// Arrange
			var list = values.ToList();

			// Act
			list.SortedInsert(value);

			// Assert
			Assert.That(list, Is.EqualTo(expected));
		}

		[TestCase(new int[] { 1, 2, 3 }, 2, 1, TestName = "GetIndex_ReturnsExpected")]
		[TestCase(new int[] { 1, 2, 3 }, 4, 3, TestName = "GetIndex_WhenValueExceedsAllValues_ReturnsExpected")]
		[TestCase(new int[] { 1, 2, 3, 5, 6, 7, 8 }, 4, 3, TestName = "GetIndex_WhenValueNotInValues_ReturnsExpected")]
		[TestCase(new int[] { 1, 2, 2, 3 }, 2, 1, TestName = "GetIndex_WhenTwoDuplicates_ReturnsExpected")]
		[TestCase(new int[] { 1, 2, 2, 2, 3 }, 2, 2, TestName = "GetIndex_WhenThreeDuplicates_ReturnsExpected")]
		public void GetIndex(int[] values, int value, int expected)
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
	}
}
