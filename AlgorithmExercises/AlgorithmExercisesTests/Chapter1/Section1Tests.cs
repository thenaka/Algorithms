using AlgorithmExercises.Chapter1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExercisesTests.Chapter1
{
	[TestFixture]
	public class Section1Tests
	{
		[Test]
		public void Exercise1A_ShouldReturnExpected()
		{
			// Arrange
			var section1 = new Section1();

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
			var section1 = new Section1();

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
			var section1 = new Section1();

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
			var section1 = new Section1();

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
			var section1 = new Section1();

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
			var section1 = new Section1();

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
			var section1 = new Section1();

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
			var section1 = new Section1();

			// Act
			bool allEqual = Section1.AllEqual(values);

			// Assert
			Assert.That(allEqual, Is.EqualTo(expected));
		}
	}
}
