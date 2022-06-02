using AlgorithmExercises.Common.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises.Chapter1
{
	public class Section3
	{
		private static string[] _validOperators = new[] { "+", "-", "*", "/" };

		/// <summary>
		/// Iterates each character in <paramref name="testString"/>. Each character is added to the stack except for '-'.
		/// When a '-' is encountered the last character pushed is popped and printed. At the end the number of characters
		/// remaining are printed.
		/// </summary>
		/// <param name="testString">String of characters to print.</param>
		public static void TestStack(string testString)
		{
			Common.Collections.Stack<string> stack = new();

			foreach (char testChar in testString)
			{
				if (!testChar.Equals('-'))
				{
					stack.Push(testChar.ToString());
				}
				else if (!stack.IsEmpty)
				{
					Console.Write($"{stack.Pop()} ");
				}
			}
			Console.WriteLine($"({stack.Size} left on stack)");
		}

		/// <summary>
		/// Iterates each character in <paramref name="testString"/>. Each character is added to the stack except for '-'.
		/// When a '-' is encountered the last character pushed is popped and printed. At the end the number of characters
		/// remaining are printed.
		/// </summary>
		/// <param name="stack">Stack to push and pop characters to.</param>
		/// <param name="testString">String of characters to print.</param>
		public static void TestResizingArrayStack(ResizingArrayStack<string> stack, string testString)
		{
			foreach (char testChar in testString)
			{
				if (!testChar.Equals('-'))
				{
					stack.Push(testChar.ToString());
				}
				else if (!stack.IsEmpty)
				{
					Console.Write($"{stack.Pop()} ");
				}
			}
			Console.WriteLine($"({stack.Size} left on stack)");
		}

		/// <summary>
		/// Suppose that a client performs an intermixed sequence of (stack) push and pop operations. The push operations put the 
		/// integers 0 through 9 in order onto the stack; the pop operations print out the return values. This method validates if
		/// the given <paramref name="outputToValidate"/> is valid.
		/// </summary>
		/// <param name="outputToValidate">Output to validate</param>
		/// <remarks>
		/// Solution from https://stackoverflow.com/questions/10445364/intermixed-sequence-of-push-and-pop-operations-why-is-this-sequence-not-possible
		/// For any decreasing sub-sequence in the output sequence, you can not have [a1, ..., an] such that, there exist k, where
		/// ak &gt; a1 and ak &lt; an and ak has not come before in the output and ak is not part of the sub-sequence [a1, ..., an].
		/// </remarks>
		public static bool ValidateStackOutput(int[] outputToValidate)
		{
			System.Collections.Generic.Stack<int> alreadySeen = new();
			foreach (int currentOutput in outputToValidate)
			{
				if (alreadySeen.TryPeek(out int lastSeen))
				{
					// For every decreasing sequence ...
					if (currentOutput < lastSeen)
					{
						// we must validate we have already seen the intervening numbers
						for (int i = currentOutput + 1; i < lastSeen; i++)
						{
							if (!alreadySeen.Contains(i)) return false;
						}
					}
				}

				alreadySeen.Push(currentOutput);
			}
			return true;
		}

		/// <summary>
		/// Determines if the parentheses in <paramref name="parentheses"/> are balanced.
		/// </summary>
		/// <param name="parentheses">Input to test for balanced parentheses.</param>
		/// <returns>True if the parentheses are balanced, otherwise false.</returns>
		public static bool AreParenthesesBalanced(string parentheses)
		{
			char[] leftParens = { '(', '[', '{' };
			char[] rightParens = { ')', ']', '}' };
			Common.Collections.Stack<char> stack = new();

			foreach (char paren in parentheses)
			{
				if (leftParens.Contains(paren))
				{
					stack.Push(paren);
					continue;
				}

				if (!rightParens.Contains(paren))
				{
					throw new ArgumentException($"Non-parentheses chracter {parentheses}");
				}

				if (stack.IsEmpty)
				{
					return false;
				}

				char leftParen = stack.Pop();
				switch (paren)
				{
					case ')':
						if (leftParen != '(') return false;
						break;
					case ']':
						if (leftParen != '[') return false;
						break;
					case '}':
						if (leftParen != '{') return false;
						break;
					default: // should never hit this case
						return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Prints the binary representation of <paramref name="n"/>.
		/// </summary>
		/// <param name="n">Number to print in binary.</param>
		public static void PrintBinary(int n)
		{
			Common.Collections.Stack<int> stack = new();
			while (n > 0)
			{
				stack.Push(n % 2);
				n /= 2;
			}
			foreach (int value in stack) Console.Write(value);
			Console.WriteLine();
		}

		/// <summary>
		/// Reverses the order of items in <paramref name="q"/>.
		/// </summary>
		/// <param name="q"><see cref="Common.Collections.Queue{T}"/> to reverse.</param>
		public static void Reverse(Common.Collections.Queue<string> q)
		{
			Common.Collections.Stack<string> stack = new();
			while (!q.IsEmpty)
			{
				stack.Push(q.Dequeue());
			}
			while (!stack.IsEmpty)
			{
				q.Enqueue(stack.Pop());
			}
		}

		/// <summary>
		/// Given an <paramref name="equation"/> with right parens this method returns the equation with left parens added.
		/// </summary>
		/// <param name="equation">Equation with right parens that needs left parens added.</param>
		/// <returns>Equation with left parens added.</returns>
		/// <remarks>Each part of the equation must be separated by spaces. For example: 1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )</remarks>
		public static string InfixEquation(string equation)
		{
			Common.Collections.Stack<string> operators = new();
			Common.Collections.Stack<string> operands = new();

			foreach (string equationPart in equation.Split(' ', StringSplitOptions.RemoveEmptyEntries))
			{
				if (_validOperators.Contains(equationPart))
				{
					operators.Push(equationPart);
					continue;
				}
				if (equationPart.Equals(")"))
				{
					string rightOperand = operands.Pop();
					string operation = operators.Pop();
					string leftOperand = operands.Pop();
					operands.Push($"( {leftOperand} {operation} {rightOperand} )");
					continue;
				}
				operands.Push(equationPart.ToString());
			}
			return operands.Pop();
		}

		/// <summary>
		/// Given an infix <paramref name="equation"/> this method converts it to postfix notation.
		/// </summary>
		/// <param name="equation">Infix equation to convert to postfix notation.</param>
		/// <returns>Postfix notation equation.</returns>
		/// <remarks>Each part of the equation must be separated by spaces. For example: ( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )</remarks>
		public static string InfixToPostfixEquation(string equation)
		{
			Common.Collections.Stack<string> operators = new();
			Common.Collections.Stack<string> operands = new();

			foreach (string equationPart in equation.Split(' ', StringSplitOptions.RemoveEmptyEntries))
			{
				if (_validOperators.Contains(equationPart))
				{
					operators.Push(equationPart);
					continue;
				}
				if (equationPart.Equals("("))
				{
					continue; // skip left parens
				}
				if (equationPart.Equals(")"))
				{
					string rightOperand = operands.Pop();
					string operation = operators.Pop();
					string leftOperand = operands.Pop();
					operands.Push($"{leftOperand} {rightOperand} {operation}");
					continue;
				}
				operands.Push(equationPart.ToString());
			}
			return operands.Pop();
		}
	}
}
