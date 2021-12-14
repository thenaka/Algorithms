using AlgorithmExercises.Chapter1;
using NUnit.Framework;
using System;

namespace AlgorithmExercisesTests.Chapter1
{
	[TestFixture]
	public class Section1Tests
	{
		[Test]
		public void Exercise1A_ShouldReturnExpected()
		{
			// Arrange
			
			// Act
			var result = Section1.Exercises1and2(() => (0 + 15) / 2, out Type type);

			// Assert
			Assert.That(result, Is.EqualTo(7));
			Assert.That(type, Is.EqualTo(typeof(int)));
		}

		[Test]
		public void Exercise1B_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.Exercises1and2(() => 2.0e-6 * 100000000.1, out Type type);

			// Assert
			Assert.That(result, Is.EqualTo(200.0000002));
			Assert.That(type, Is.EqualTo(typeof(double)));
		}

		[Test]
		public void Exercise1C_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.Exercises1and2(() => true && false || true && true, out Type type);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(type, Is.EqualTo(typeof(Boolean)));
		}

		[Test]
		public void Exercise2A_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.Exercises1and2(() => (1 + 2.236) / 2, out Type type);

			// Assert
			Assert.That(result, Is.EqualTo(1.618));
			Assert.That(type, Is.EqualTo(typeof(double)));
		}

		[Test]
		public void Exercise2B_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.Exercises1and2(() => 1 + 2 + 3 + 4.0, out Type type);

			// Assert
			Assert.That(result, Is.EqualTo(10));
			Assert.That(type, Is.EqualTo(typeof(double)));
		}

		[Test]
		public void Exercise2C_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.Exercises1and2(() => 4.1 >= 4, out Type type);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(type, Is.EqualTo(typeof(Boolean)));
		}

		[Test]
		public void Exercise2D_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.Exercises1and2(() => 1 + 2 + "3", out Type type);

			// Assert
			Assert.That(result, Is.EqualTo("33"));
			Assert.That(type, Is.EqualTo(typeof(string)));
		}

		[TestCase(new int[] { }, false, TestName = "Exercise3_AllEqual_EmptyArray_ReturnsFalse")]
		[TestCase(new int[] { 1 }, true, TestName = "Exercise3_AllEqual_OneElementArray_ReturnsTrue")]
		[TestCase(new int[] { 33, 33, 33 }, true, TestName = "Exercise3_AllEqual_WhenAllEqual_ReturnsTrue")]
		[TestCase(new int[] { 33, 22, 11 }, false, TestName = "Exercise3_AllEqual_WhenAllNotEqual_ReturnsFalse")]
		public void Exercise3_AllEqual_ShouldValidateIfAllEqual(int[] values, bool expected)
		{
			// Arrange

			// Act
			bool allEqual = Section1.AllEqual(values);

			// Assert
			Assert.That(allEqual, Is.EqualTo(expected));
		}

		[TestCase("if (a > b) then c = 0;", false, TestName = "Excercise4A_ValidateIfStatement_WhenIncorrectThen_ReturnsFalse")]
		[TestCase("if a > b { c = 0; }", false, TestName = "Excercise4B_ValidateIfStatement_WhenMissingParentheses_ReturnsFalse")]
		[TestCase("if (a > b) c = 0;", true, TestName = "Excercise4C_ValidateIfStatement_WhenValid_ReturnsTrue")]
		[TestCase("if (a > b) c = 0 else b = 0;", false, TestName = "Excercise4C_ValidateIfStatement_WhenMissingSemiColon_ReturnsFalse")]
		public void Exercise4_ValidateIfStatement_ShouldValidateIfStatement(string ifStatement, bool expected)
		{
			// Arrange

			// Act
			bool result = Section1.ValidateIfStatement(ifStatement);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(0.3, 0.4, true, TestName ="Exercise5_BothInRange_WhenInRange_ReturnsTrue")]
		[TestCase(-1, 0.4, false, TestName ="Exercise5_BothInRange_WhenXOutOfRange_ReturnsFalse")]
		[TestCase(0.3, 2, false, TestName ="Exercise5_BothInRange_WhenYOutOfRange_ReturnsFalse")]
		[TestCase(0.00000001, 0.9999999999, true, TestName ="Exercise5_BothInRange_WhenBothInRangeEdgeCases_ReturnsTrue")]
		[TestCase(-0.00000001, 0.5, false, TestName ="Exercise5_BothInRange_WhenXOutOfRangeEdgeCase_ReturnsFalse")]
		[TestCase(0.5, 1.00000001, false, TestName ="Exercise5_BothInRange_WhenYOutOfRangeEdgeCase_ReturnsFalse")]
		public void Exercise5_BothInRange_ShouldValidateInRange(double x, double y, bool expected)
		{
			// Arrange

			// Act
			bool result = Section1.BothInRange(x, y);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}
	}
}
