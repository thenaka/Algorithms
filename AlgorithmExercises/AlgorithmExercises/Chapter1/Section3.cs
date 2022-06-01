using System;

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
	}
}
