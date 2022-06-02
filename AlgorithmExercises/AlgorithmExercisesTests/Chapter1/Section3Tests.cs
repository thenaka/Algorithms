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

		[Test]
		public void Exercise6_Reverse_ReversesQueueOrder()
		{
			// Arrange
			int items = 10;
			Queue<string> queue = new();
			for (int i = 0; i < items; i++)
			{
				queue.Enqueue(Path.GetRandomFileName());
			}

			string[] originalItems = new string[items];
			int count = 0;
			foreach (string s in queue)
			{
				originalItems[count++] = s;
			}

			// Act
			Section3.Reverse(queue);

			// Assert
			foreach (string s in queue)
			{
				Assert.That(s, Is.EqualTo(originalItems[--count]));
			}
		}

		[TestCase(new string[] { "frog", "cat", "dog" }, "dog", 3, TestName = "Exercise7_Peek_DoesExpected")]
		[TestCase(new string[] { "frog" }, "frog", 1, TestName = "Exercise7_Peek_WhenOneItem_DoesExpected")]
		public void Exercise7_Peek_DoesExpected(string[] items, string expectedItem, int expectedCount)
		{
			// Arrange
			Stack<string> stack = new();
			foreach (string s in items)
			{
				stack.Push(s);
			}

			// Act
			string peekedItem = stack.Peek();

			// Assert
			Assert.That(peekedItem, Is.EqualTo(expectedItem));
			Assert.That(stack.Size, Is.EqualTo(expectedCount));
		}

		[Test]
		public void Exercise8_ResizingArrayStack_ReturnsExpected()
		{
			// Arrange
			ResizingArrayStack<string> stack = new();
			string testString = "it was-the best-of times---it was-the--";
			string expected = "s t s e m s e h (23 left on stack)\r\n";
			int expectedArrayLength = 32;

			// Act
			var consoleOut = Console.Out;
			using (StringWriter consoleOutput = new())
			{

				Console.SetOut(consoleOutput);
				Section3.TestResizingArrayStack(stack, testString);

				// Assert
				Assert.That(consoleOutput.ToString(), Is.EqualTo(expected));
				Assert.That(stack.ArraySize, Is.EqualTo(expectedArrayLength));
			}
			Console.SetOut(consoleOut);
		}

		[TestCase("1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )", "( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )", TestName = "Exercise9_InfixEquation_ReturnsExpected")]
		[TestCase("111 + 25 ) * 83 - 64 ) * 1235 - 60 ) ) )", "( ( 111 + 25 ) * ( ( 83 - 64 ) * ( 1235 - 60 ) ) )", TestName = "Exercise9_InfixEquation_WhenMultiDigitValues_ReturnsExpected")]
		[TestCase("1 + 2 )", "( 1 + 2 )", TestName = "Exercise9_InfixEquation_WhenOneExpression_ReturnsExpected")]
		[TestCase("1 + 2 ) * 3 - 4 ) )", "( ( 1 + 2 ) * ( 3 - 4 ) )", TestName = "Exercise9_InfixEquation_WhenTwoExpressions_ReturnsExpected")]
		public void Exercise9_InfixEquation_ReturnsExpected(string equation, string expected)
		{
			// Arrange

			// Act
			string result = Section3.InfixEquation(equation);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase("( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )", "1 2 + 3 4 - 5 6 - * *", TestName = "Exercise10_InfixToPostfixEquation_ReturnsExpected")]
		[TestCase("( ( 111 + 25 ) * ( ( 83 - 64 ) * ( 1235 - 60 ) ) )", "111 25 + 83 64 - 1235 60 - * *", TestName = "Exercise10_InfixEquation_WhenMultiDigitValues_ReturnsExpected")]
		[TestCase("( 1 + 2 )", "1 2 +", TestName = "Exercise10_InfixEquation_WhenOneExpression_ReturnsExpected")]
		[TestCase("( ( 1 + 2 ) * ( 3 - 4 ) )", "1 2 + 3 4 - *", TestName = "Exercise10_InfixEquation_WhenTwoExpressions_ReturnsExpected")]
		public void Exercise10_InfixToPostfixEquation_ReturnsExpected(string equation, string expected)
		{
			// Arrange

			// Act
			string result = Section3.InfixToPostfixEquation(equation);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase("1 2 + 3 4 - 5 6 - * *", 3, TestName = "Exercise11_EvaluatePostfix_ReturnsExpected")]
		[TestCase("111 25 + 83 64 - 1235 60 - * *", 3036200, TestName = "Exercise11_EvaluatePostfix_WhenMultiDigitValues_ReturnsExpected")]
		[TestCase("1 2 +", 3, TestName = "Exercise11_EvaluatePostfix_WhenOneExpression_ReturnsExpected")]
		[TestCase("1 2 + 3 4 - *", -3, TestName = "Exercise11_EvaluatePostfix_WhenTwoExpressions_ReturnsExpected")]
		public void Exercise11_EvaluatePostfix_ReturnsExpected(string equation, int expected)
		{
			// Arrange

			// Act
			int result = Section3.EvaluatePostfix(equation);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Exercise12_CopyStack_ReturnsExpected()
		{
			// Arrange
			Stack<string> originalStack = new();
			int capacity = 10;
			for (int i = 0; i < capacity; i++)
			{
				originalStack.Push(Path.GetRandomFileName());
			}

			// Act
			Stack<string> copy = Section3.Copy(originalStack);

			// Assert
			Assert.That(copy, Is.EqualTo(originalStack));
		}
	}
}
