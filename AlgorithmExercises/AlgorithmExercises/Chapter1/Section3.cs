﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises.Chapter1
{
	public class Section3
	{
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
			Stack<int> alreadySeen = new();
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

			foreach(char paren in parentheses)
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
	}
}
