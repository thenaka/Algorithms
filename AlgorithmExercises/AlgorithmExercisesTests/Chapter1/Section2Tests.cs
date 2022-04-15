using AlgorithmExercises.Chapter1;
using AlgorithmExercises.Common;
using Combinatorics.Collections;
using NUnit.Framework;
using System;
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
	}
}
