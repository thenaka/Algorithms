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
		[TestCase(new int[] {1, 2, 3, 5, 6, 7, 8}, 4, 3, TestName ="GetIndex_WhenValueNotInValues_ReturnsExpected")]
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
	}
}
