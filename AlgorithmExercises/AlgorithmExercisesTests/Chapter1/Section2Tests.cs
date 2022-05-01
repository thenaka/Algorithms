using AlgorithmExercises.Chapter1;
using AlgorithmExercises.Common;
using Combinatorics.Collections;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace AlgorithmExercisesTests.Chapter1
{
	[TestFixture]
	public class Section2Tests
	{
		[TestCase(10, TestName = "Exercise1_RandomPoints_GetClosestDistance")]
		[TestCase(20, TestName = "Exercise1_RandomPoints_When20_GetClosestDistance")]
		[TestCase(30, TestName = "Exercise1_RandomPoints_When30_GetClosestDistance")]
		public void Exercise1_RandomPoints_GetClosestDistance(int n)
		{
			// Arrange
			var randomPoints = Section2.GetRandomPoints(n);
			var combinations = new Combinations<Point>(randomPoints, 2);

			// Act
			double shortestDistance = 0;
			for (int i = 0; i < combinations.Count; i++)
			{
				double tempDistance = combinations.ElementAt(i).ElementAt(0).DistanceTo(combinations.ElementAt(i).ElementAt(1));
				if (shortestDistance == 0)
				{
					shortestDistance = tempDistance;
					continue;
				}
				shortestDistance = tempDistance < shortestDistance ? tempDistance : shortestDistance;
			}

			// Assert
			Assert.Pass($"Shortest distance is {shortestDistance}");
		}

		[TestCase(10, TestName = "Exercise2_Interval1D_DoIntersect")]
		[TestCase(20, TestName = "Exercise2_Interval1D_When20_DoIntersect")]
		[TestCase(30, TestName = "Exercise2_Interval1D_When30_DoIntersect")]
		public void Exercise2_Interval1D_DoIntersect(int n)
		{
			// Arrange
			var randomInterval1D = Section2.GetRandomInterval1D(n);
			var combinations = new Combinations<Interval1D>(randomInterval1D, 2);

			// Act
			for (int i = 0; i < combinations.Count(); i++)
			{
				var firstInterval1D = combinations.ElementAt(i).ElementAt(0);
				var secondInterval1D = combinations.ElementAt(i).ElementAt(1);
				bool intersect = firstInterval1D.Intersects(secondInterval1D);
				if (intersect)
				{
					Console.WriteLine($"{firstInterval1D} intersects {secondInterval1D}");
				}
			}
			// Assert
			Assert.Pass();
		}

		[TestCase(10, TestName = "Exercise3_Interval2D_DoIntersect")]
		[TestCase(20, TestName = "Exercise3_Interval2D_When20_DoIntersect")]
		[TestCase(30, TestName = "Exercise3_Interval2D_When30_DoIntersect")]
		public void Exercise3_Interval2D_DoIntersect(int n)
		{
			// Arrange
			var randomInterval2D = Section2.GetRandomInterval2D(n);
			var combinations = new Combinations<Interval2D>(randomInterval2D, 2);

			// Act
			for (int i = 0; i < combinations.Count(); i++)
			{
				var firstInterval2D = combinations.ElementAt(i).ElementAt(0);
				var secondInterval2D = combinations.ElementAt(i).ElementAt(1);
				if (firstInterval2D.Intersects(secondInterval2D))
				{
					Console.WriteLine($"{firstInterval2D} intersects {secondInterval2D}");
				}
			}
			// Assert
			Assert.Pass();
		}

		[TestCase(10, TestName = "Exercise3_Interval2D_Contains")]
		[TestCase(20, TestName = "Exercise3_Interval2D_When20_Contains")]
		[TestCase(30, TestName = "Exercise3_Interval2D_When30_Contains")]
		public void Exercise3_Interval2D_Contains(int n)
		{
			// Arrange
			var randomInterval2D = Section2.GetRandomInterval2D(n);
			var combinations = new Combinations<Interval2D>(randomInterval2D, 2);

			// Act
			for (int i = 0; i < combinations.Count(); i++)
			{
				var firstInterval2D = combinations.ElementAt(i).ElementAt(0);
				var secondInterval2D = combinations.ElementAt(i).ElementAt(1);
				if (firstInterval2D.Contains(secondInterval2D))
				{
					Console.WriteLine($"{firstInterval2D} contains {secondInterval2D}");
				}
			}
			// Assert
			Assert.Pass();
		}

		[Test]
		public void Exercise4_ImmutableString()
		{
			// Arrange
			string string1 = "hello";
			string string2 = string1;

			// Act
			string1 = "world";

			// Assert
			Assert.That(string1, Is.EqualTo("world"));
			Assert.That(string2, Is.EqualTo("hello"));
		}

		[Test]
		public void Exercise5_ImmutableString()
		{
			// Arrange
			string s = "Hello World";

			// Act
			_ = s.ToUpper();
			_ = s.Substring(6, 5);

			// Assert
			Assert.That(s, Is.EqualTo("Hello World"));
		}

		[TestCase("abcdef", "cdefab", true, TestName = "Exercise6_CircularRotation_ReturnsExpected")]
		[TestCase("abcdef", "fedcba", false, TestName = "Exercise6_CircularRotation_WhenFalse_ReturnsExpected")]
		public void Exercise6_CircularRotation_ReturnsExpected(string s, string t, bool expected)
		{
			// Arrange

			// Act
			bool result = Section2.CircularShift(s, t);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase("test", TestName = "Exercise7_Reverse_ReturnsExpected")]
		[TestCase("tests", TestName = "Exercise7_Reverse_When5Chars_ReturnsExpected")]
		[TestCase("teststuff", TestName = "Exercise7_Reverse_When9Chars_ReturnsExpected")]
		[TestCase("", TestName = "Exercise7_Reverse_WhenEmptyString_ReturnsExpected")]
		public void Exercise7_Reverse_ReturnsExpected(string s)
		{
			// Arrange

			// Act
			string result = Section2.Reverse(s);

			// Assert
			Assert.That(result, Is.EqualTo(s.Reverse()));
		}

		[Test]
		public void Exercise8_SwapArrays()
		{
			// Arrange
			var a = Section2.GetRandomInts(1_000_000);
			var originalA = a;
			var b = Section2.GetRandomInts(1_000_000);
			var originalB = b;

			// Act
			var t = a;
			a = b;
			b = t;

			// Assert
			Assert.That(a, Is.EqualTo(originalB));
			Assert.That(b, Is.EqualTo(originalA));
		}

		[TestCase(5, new int[] { }, -1, "Keys Examined:0\r\n", TestName = "Exercise9_Rank_WhenValuesEmpty_ConsoleWritesZero")]
		[TestCase(5, new int[] { 2, 3, 5, 8, 9, 20, 31 }, 2, "Keys Examined:3\r\n", TestName = "Exercise9_Rank_ConsoleWritesKeysExamined")]
		[TestCase(10, new int[] { 2, 3, 5, 8, 14, 20, 31, 55, 63 }, -1, "Keys Examined:4\r\n", TestName = "Exercise9_Rank_ConsoleWritesFour")]
		public void Exercise9_Rank_ConsoleWritesKeysExamined(int key, int[] values, int expected, string expectedKeysExamined)
		{
			// Arrange

			// Act
			var consoleOut = Console.Out;
			using (StringWriter consoleOutput = new())
			{

				Console.SetOut(consoleOutput);
				var result = BinarySearch.Rank(key, values, false, true);

				// Assert
				Assert.That(result, Is.EqualTo(expected));
				Assert.That(consoleOutput.ToString(), Is.EqualTo(expectedKeysExamined));
			}
			Console.SetOut(consoleOut);
		}

		[TestCase(3, 3, 3, 3, TestName = "Exercise10_VisualCounter_IncrementsToMax")]
		[TestCase(3, 3, 4, 3, TestName = "Exercise10_VisualCounter_WhenOpertionsExceedMaxOp_OnlyIncrementsToMax")]
		[TestCase(10, 3, 10, 3, TestName = "Exercise10_VisualCounter_DoesNotExceedMaxValue")]
		public void Exercise10_VisualCounter_IncrementsToMax(int maxOp, int maxVal, int operations, int expected)
		{
			// Arrange
			var visualCounter = new VisualCounter(maxOp, maxVal);
			int currentVal = 0;

			// Act
			for (int i = 0; i < operations; i++)
			{
				currentVal = visualCounter.Increment();
			}

			// Assert
			Assert.That(currentVal, Is.EqualTo(expected));
		}

		[TestCase(3, 3, 3, -3, TestName = "Exercise10_VisualCounter_Decrements")]
		[TestCase(3, 3, 4, -3, TestName = "Exercise10_VisualCounter_WhenOpertionsExceedMaxOp_OnlyIncrementsToMaxOp")]
		public void Exercise10_VisualCounter_Decrements(int maxOp, int maxVal, int operations, int expected)
		{
			// Arrange
			var visualCounter = new VisualCounter(maxOp, maxVal);
			int currentVal = 0;

			// Act
			for (int i = 0; i < operations; i++)
			{
				currentVal = visualCounter.Decrement();
			}

			// Assert
			Assert.That(currentVal, Is.EqualTo(expected));
		}

		[TestCase(1, 15, 1999, TestName = "Exercise11_Date_AcceptsValidDate")]
		[TestCase(2, 29, 2004, TestName = "Exercise11_Date_WhenLeapDay_AcceptsValidDate")]
		[TestCase(6, 30, 1999, TestName = "Exercise11_Date_WhenLastDayOfMonth_AcceptsValidDate")]
		public void Exercise11_Date_AcceptsValidDates(int month, int day, int year)
		{
			// Arrange

			// Act
			Date result = new(month, day, year);

			// Assert
			Assert.That(result.ToString, Is.EqualTo($"{month}/{day}/{year}"));
		}

		[TestCase(0, 15, 1999, TestName = "Exercise11_Date_ThrowsArgumentException_WhenInvalidDate")]
		[TestCase(2, 29, 2003, TestName = "Exercise11_Date_ThrowsArgumentException_WhenLeapDay_ButNotLeapYear")]
		[TestCase(6, 31, 1999, TestName = "Exercise11_Date_ThrowsArgumentException_WhenDayOfMonthExceeds")]
		public void Exercise11_Date_ThrowsArgumentException_WhenInvalidDate(int month, int day, int year)
		{
			// Arrange

			// Act and Assert
			Assert.Throws<ArgumentException>(() => new Date(month, day, year));
		}
	}
}
