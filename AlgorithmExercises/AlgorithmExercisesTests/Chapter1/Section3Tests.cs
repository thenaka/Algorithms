using AlgorithmExercises.Chapter1;
using AlgorithmExercises.Common.Collections;
using NUnit.Framework;
using System;
using System.IO;

namespace AlgorithmExercisesTests.Chapter1
{
	[TestFixture]
	public class Section3Tests
	{
		[Test]
		public void Exercise1_FixedCapacityStackOfStrings_IsFull_ReturnsExpected()
		{
			// Arrange
			int capacity = 10;
			FixedCapacityStackOfStrings stack = new(capacity);

			// Act and Assert
			Assert.That(stack.IsFull, Is.False);
			for (int i = 0; i < capacity; i++)
			{
				stack.Push(Path.GetRandomFileName());
			}
			Assert.That(stack.IsFull, Is.True);
		}

		[Test]
		public void Exercise2_TestStack_ReturnsExpected()
		{
			// Arrange
			string testString = "it was-the best-of times---it was-the--";
			string expectedOutput = "s t s e m s e h (23 left on stack)\r\n";

			// Act
			var consoleOut = Console.Out;
			using (StringWriter consoleOutput = new())
			{

				Console.SetOut(consoleOutput);
				Section3.TestStack(testString);

				// Assert
				Assert.That(consoleOutput.ToString(), Is.EqualTo(expectedOutput));
			}
			Console.SetOut(consoleOut);
		}
	}
}
