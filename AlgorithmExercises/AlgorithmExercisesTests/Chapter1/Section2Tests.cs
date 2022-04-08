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
		[TestCase(20, TestName = "Exercise2_Interval1D_DoIntersect")]
		public void Exercise2_Interval1D_DoIntersect(int n)
		{
			var randomInterval1D = Section2.GetRandomInterval1D(n);
			var combinations = new Combinations<Interval1D>(randomInterval1D, 2);

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
			Assert.Pass();
		}
	}
}
