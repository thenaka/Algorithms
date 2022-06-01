﻿using AlgorithmExercises.Chapter1;
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

		[TestCase(new int[] { 4, 3, 2, 1, 0, 9, 8, 7, 6, 5 }, true, TestName = "Exercise3_ValidateStackOutput_ReturnsExpected")]
		[TestCase(new int[] { 4, 6, 8, 7, 5, 3, 2, 9, 0, 1 }, false, TestName = "Exercise3_ValidateStackOutput1_ReturnsExpected")]
		[TestCase(new int[] { 2, 5, 6, 7, 4, 8, 9, 3, 1, 0 }, true, TestName = "Exercise3_ValidateStackOutput2_ReturnsExpected")]
		[TestCase(new int[] { 4, 3, 2, 1, 0, 5, 6, 7, 8, 9 }, true, TestName = "Exercise3_ValidateStackOutput3_ReturnsExpected")]
		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 9, 8, 7, 0 }, true, TestName = "Exercise3_ValidateStackOutput4_ReturnsExpected")]
		[TestCase(new int[] { 0, 4, 6, 5, 3, 8, 1, 7, 2, 9 }, false, TestName = "Exercise3_ValidateStackOutput5_ReturnsExpected")]
		[TestCase(new int[] { 1, 4, 7, 9, 8, 6, 5, 3, 0, 2 }, false, TestName = "Exercise3_ValidateStackOutput6_ReturnsExpected")]
		[TestCase(new int[] { 2, 1, 4, 3, 6, 5, 8, 7, 9, 0 }, true, TestName = "Exercise3_ValidateStackOutput7_ReturnsExpected")]
		public void Exercise3_ValidateStackOutput_ReturnsExpected(int[] validate, bool expected)
		{
			// Arrange

			// Act
			bool actual = Section3.ValidateStackOutput(validate);

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[TestCase("[()]{}{[()()]()}", true, TestName = "Exercise4_AreParenthesesBalanaced_ReturnsExpected")]
		[TestCase("[(])", false, TestName = "Exercise4_AreParenthesesBalanaced_ReturnsExpected")]
		public void Exercise4_AreParenthesesBalanaced_ReturnsExpected(string parentheses, bool expected)
		{
			// Arrange

			// Act
			bool result = Section3.AreParenthesesBalanced(parentheses);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(50, "110010\r\n", TestName = "Exercise5_PrintBinary_ReturnsExpected")]
		[TestCase(1234, "10011010010\r\n", TestName = "Exercise5_PrintBinary_ReturnsExpected")]
		[TestCase(255, "11111111\r\n", TestName = "Exercise5_PrintBinary_ReturnsExpected")]
		public void Exercise5_PrintBinary_ReturnsExpected(int n, string expected)
		{
			// Act
			var consoleOut = Console.Out;
			using (StringWriter consoleOutput = new())
			{

				Console.SetOut(consoleOutput);
				Section3.PrintBinary(n);

				// Assert
				Assert.That(consoleOutput.ToString(), Is.EqualTo(expected));
			}
			Console.SetOut(consoleOut);
		}
	}
}