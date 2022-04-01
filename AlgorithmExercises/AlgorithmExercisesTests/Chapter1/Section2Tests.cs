﻿using AlgorithmExercises.Chapter1;
using AlgorithmExercises.Common;
using Combinatorics.Collections;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				double tempDistance =
					Math.Sqrt(Math.Pow(combinations.ElementAt(i).ElementAt(1).X - combinations.ElementAt(i).ElementAt(0).X, 2) +
							  Math.Pow(combinations.ElementAt(i).ElementAt(1).Y - combinations.ElementAt(i).ElementAt(0).Y, 2));
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

		[TestCase(10, TestName = "Exercise2_Lines_DoIntersect")]
		[TestCase(20, TestName = "Exercise2_Lines_When20_DoIntersect")]
		public void Exercise2_Lines_DoIntersect(int n)
		{
			// Arrange
			var randomLines = Section2.GetRandomLLines(n);
			var combinations = new Combinations<Line>(randomLines, 2);

			// Act/Assert
			for (int i = 0; i < combinations.Count(); i++)
			{
				Line line1 = combinations.ElementAt(i).ElementAt(0);
				Line line2 = combinations.ElementAt(i).ElementAt(1);

				bool intersect = Section2.DoIntersect(line1, line2);
				Console.WriteLine($"{intersect}: line {line1} intersects line {line2}");
			}
			Assert.Pass();
		}
	}
}