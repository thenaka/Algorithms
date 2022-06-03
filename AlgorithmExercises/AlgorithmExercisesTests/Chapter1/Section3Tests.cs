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
		[TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, true, TestName = "Exercise13_ValidateQueueOutput_ReturnsExpected")]
		[TestCase(new int[] { 4, 6, 8, 7, 5, 3, 2, 9, 0, 1 }, false, TestName = "Exercise13_ValidateQueueOutput1_ReturnsExpected")]
		[TestCase(new int[] { 2, 5, 6, 7, 4, 8, 9, 3, 1, 0 }, false, TestName = "Exercise13_ValidateQueueOutput2_ReturnsExpected")]
		[TestCase(new int[] { 4, 3, 2, 1, 0, 5, 6, 7, 8, 9 }, true, TestName = "Exercise13_ValidateQueueOutput3_ReturnsExpected")]
		public void Exercise13_ValidateQueueOutput_ReturnsExpected(int[] validation, bool expected)
		{
			// Arrange

			// Act
			bool result = Section3.ValidateQueueOutput(validation);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Exercise14_ResizingArrayQueue_Resizes()
		{
			// Arrange
			ResizingArrayQueue<int> queue = new();
			int initalCapacity = 32;
			Assert.That(initalCapacity, Is.EqualTo(queue.ArraySize));

			// Act
			for (int i = 0; i < initalCapacity + 1; i++)
			{
				queue.Enqueue(i);
			}

			// Assert
			Assert.That(initalCapacity * 2, Is.EqualTo(queue.ArraySize));
		}

		[Test]
		public void Exercise14_ResizingArrayQueue_QueuesAndDequeues()
		{
			// Arrange
			ResizingArrayQueue<int> queue = new();
			int count = 32;

			// Act
			for (int i = 0; i < count; i++)
			{
				queue.Enqueue(i);
			}

			// Assert
			for (int i = 0; i < count; i++)
			{
				Assert.That(queue.Dequeue(), Is.EqualTo(i));
			}
		}

		[TestCase(new string[] { "a", "b", "c", "d", "e", "f", "g" }, 3, "c", TestName = "Exercise15_Queue_KthElement_ReturnsExpected")]
		[TestCase(new string[] { "a", "b", "c", "d", "e", "f", "g" }, 1, "a", TestName = "Exercise15_Queue_KthElement_When1_ReturnsExpected")]
		[TestCase(new string[] { "a", "b", "c", "d", "e", "f", "g" }, 7, "g", TestName = "Exercise15_Queue_KthElement_When7_ReturnsExpected")]
		public void Exercise15_Queue_KthElement_ReturnsExpected(string[] values, int k, string expected)
		{
			// Arrange
			Queue<string> queue = new();
			for (int i = values.Length - 1; i >= 0; i--)
			{ // iterate backwards to queue these correctly
				queue.Enqueue(values[i]);
			}

			// Act
			string result = Section3.KthElement(queue, k);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Exercise16_ReadAllDates_ReturnsExpected()
		{
			// Arrange
			string date1 = "11/1/1911";
			string date2 = "2/22/2022";
			string date3 = "3/3/1933";
			string[] dates = { date1, date2, date3 };

			// Act
			AlgorithmExercises.Common.Date[] convertedDates = Section3.ReadAllDates(dates);

			// Assert
			Assert.That(convertedDates[0].Equals(new AlgorithmExercises.Common.Date(date1)));
			Assert.That(convertedDates[1].Equals(new AlgorithmExercises.Common.Date(date2)));
			Assert.That(convertedDates[2].Equals(new AlgorithmExercises.Common.Date(date3)));
		}

		[Test]
		public void Exercise17_ReadAllTransactions_ReturnsExpected()
		{
			// Arrange
			string transaction1 = "John Smith 11/1/1911 1.11";
			string transaction2 = "Jane Doe 2/22/2022 222.22";
			string transaction3 = "Fred Rogers 3/3/1933 3033.33";
			string[] transactions = { transaction1, transaction2, transaction3 };

			// Act
			AlgorithmExercises.Common.Transaction[] convertedTransactions = Section3.ReadAllTransactions(transactions);

			// Assert
			Assert.That(convertedTransactions[0].Equals(new AlgorithmExercises.Common.Transaction(transaction1)));
			Assert.That(convertedTransactions[1].Equals(new AlgorithmExercises.Common.Transaction(transaction2)));
			Assert.That(convertedTransactions[2].Equals(new AlgorithmExercises.Common.Transaction(transaction3)));
		}

		[Test]
		public void Exercise18_LinkedListNode_Dereference()
		{
			// Arrange
			Node<string> nodeX = new Node<string> { Item = "x" };
			Node<string> nodeY = new Node<string> { Item = "y" };
			Node<string> nodeZ = new Node<string> { Item = "z" };

			nodeX.Next = nodeY; // setup linked list
			nodeY.Next = nodeZ; // so each node references the next

			// Act
			nodeX.Next = nodeX.Next.Next; // this dereferences nodeY so nothing points to it

			// Assert
			Assert.That(nodeX.Next, Is.Not.EqualTo(nodeY));
			Assert.That(nodeY.Next, Is.Not.EqualTo(nodeY));
			Assert.That(nodeZ.Next, Is.Not.EqualTo(nodeY));
		}

		[Test]
		public void Exercise19_LinkedList_Remove_DeletesLastNode()
		{
			// Arrange
			LinkedList<int> linkedList = new();
			int capacity = 10;
			for (int i = 0; i < capacity; i++)
			{
				linkedList.Add(i);
			}

			// Act
			linkedList.Remove();

			// Assert
			Assert.That(linkedList.Size, Is.EqualTo(capacity - 1));
			Assert.That(linkedList.LastItem, Is.EqualTo(8));
		}

		[TestCase(1, 0, TestName = "Exercise20And24_LinkedList_RemoveAtN_DeletesThatNode")]
		[TestCase(3, 2, TestName = "Exercise20And24_LinkedList_RemoveAt3_DeletesThatNode")]
		[TestCase(5, 4, TestName = "Exercise20And24_LinkedList_RemoveAt5_DeletesThatNode")]
		[TestCase(7, 6, TestName = "Exercise20And24_LinkedList_RemoveAt7_DeletesThatNode")]
		[TestCase(9, 8, TestName = "Exercise20And24_LinkedList_RemoveAt9_DeletesThatNode")]
		public void Exercise20And24_LinkedList_RemoveAtN_DeletesThatNode(int nodeToDelete, int shouldBeDeleted)
		{
			// Arrange
			LinkedList<int> linkedList = new();
			int capacity = 10;
			for (int i = 0; i < capacity; i++)
			{
				linkedList.Add(i);
			}

			// Act
			linkedList.Remove(nodeToDelete);

			// Assert
			foreach (int item in linkedList)
			{
				Assert.That(item, Is.Not.EqualTo(shouldBeDeleted));
			}
		}

		[TestCase(0, 1, TestName = "Exercise21_LinkedList_FindAtN_ReturnsFoundIndex")]
		[TestCase(2, 3, TestName = "Exercise21_LinkedList_FindAt3_ReturnsFoundIndex")]
		[TestCase(4, 5, TestName = "Exercise21_LinkedList_FindAt5_ReturnsFoundIndex")]
		[TestCase(6, 7, TestName = "Exercise21_LinkedList_FindAt7_ReturnsFoundIndex")]
		[TestCase(8, 9, TestName = "Exercise21_LinkedList_FindAt9_ReturnsFoundIndex")]
		public void Exercise21_LinkedList_FindAtN_ReturnsFoundIndex(int searchTerm, int expectedIndex)
		{
			// Arrange
			LinkedList<int> linkedList = new();
			int capacity = 10;
			for (int i = 0; i < capacity; i++)
			{
				linkedList.Add(i);
			}

			// Act
			int foundIndex = linkedList.Find(searchTerm);

			// Assert
			Assert.That(foundIndex, Is.EqualTo(expectedIndex));
		}

		[Test]
		public void Exercise22_LinkedList_Insert_Validate()
		{
			// Arrange
			Node<char> t = new() { Item = 't' };
			Node<char> x = new() { Item = 'x' };
			Node<char> z = new() { Item = 'z' };

			t.Next = x;
			x.Next = z;
			z.Next = null;

			// Act
			t.Next = x.Next;
			x.Next = t;

			// Assert
			Assert.That(x.Next.Item, Is.EqualTo(t.Item));
			Assert.That(t.Next.Item, Is.EqualTo(z.Item));
		}

		[Test]
		public void Exercise23_LinkedList_Insert_Validate()
		{
			// Arrange
			Node<char> t = new() { Item = 't' };
			Node<char> x = new() { Item = 'x' };
			Node<char> z = new() { Item = 'z' };

			t.Next = x;
			x.Next = z;
			z.Next = null;

			// Act
			x.Next = t;
			t.Next = x.Next;

			// Assert
			Assert.That(x.Next.Item, Is.EqualTo(t.Item));
			Assert.That(t.Next.Item, Is.Not.EqualTo(z.Item));
		}
	}
}
