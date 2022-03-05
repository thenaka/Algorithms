using AlgorithmExercises.Chapter1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AlgorithmExercisesTests.Chapter1
{
	[TestFixture]
	public class Section1Tests
	{
		[Test]
		public void Exercise1A_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.GetFuncResultAndType(() => (0 + 15) / 2, out Type type);

			// Assert
			Assert.That(result, Is.EqualTo(7));
			Assert.That(type, Is.EqualTo(typeof(int)));
		}

		[Test]
		public void Exercise1B_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.GetFuncResultAndType(() => 2.0e-6 * 100000000.1, out Type type);

			// Assert
			Assert.That(result, Is.EqualTo(200.0000002));
			Assert.That(type, Is.EqualTo(typeof(double)));
		}

		[Test]
		public void Exercise1C_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.GetFuncResultAndType(() => true && false || true && true, out Type type);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(type, Is.EqualTo(typeof(Boolean)));
		}

		[Test]
		public void Exercise2A_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.GetFuncResultAndType(() => (1 + 2.236) / 2, out Type type);

			// Assert
			Assert.That(result, Is.EqualTo(1.618));
			Assert.That(type, Is.EqualTo(typeof(double)));
		}

		[Test]
		public void Exercise2B_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.GetFuncResultAndType(() => 1 + 2 + 3 + 4.0, out Type type);

			// Assert
			Assert.That(result, Is.EqualTo(10));
			Assert.That(type, Is.EqualTo(typeof(double)));
		}

		[Test]
		public void Exercise2C_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.GetFuncResultAndType(() => 4.1 >= 4, out Type type);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(type, Is.EqualTo(typeof(Boolean)));
		}

		[Test]
		public void Exercise2D_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = Section1.GetFuncResultAndType(() => 1 + 2 + "3", out Type type);

			// Assert
			Assert.That(result, Is.EqualTo("33"));
			Assert.That(type, Is.EqualTo(typeof(string)));
		}

		[TestCase(new int[] { }, false, TestName = "Exercise3_AllEqual_EmptyArray_ReturnsFalse")]
		[TestCase(new int[] { 1 }, true, TestName = "Exercise3_AllEqual_OneElementArray_ReturnsTrue")]
		[TestCase(new int[] { 33, 33, 33 }, true, TestName = "Exercise3_AllEqual_WhenAllEqual_ReturnsTrue")]
		[TestCase(new int[] { 33, 22, 11 }, false, TestName = "Exercise3_AllEqual_WhenAllNotEqual_ReturnsFalse")]
		public void Exercise3_AllEqual_ShouldValidateIfAllEqual(int[] values, bool expected)
		{
			// Arrange

			// Act
			bool allEqual = Section1.AllEqual(values);

			// Assert
			Assert.That(allEqual, Is.EqualTo(expected));
		}

		[TestCase("if (a > b) then c = 0;", false, TestName = "Exercise4A_ValidateIfStatement_WhenIncorrectThen_ReturnsFalse")]
		[TestCase("if a > b { c = 0; }", false, TestName = "Exercise4B_ValidateIfStatement_WhenMissingParentheses_ReturnsFalse")]
		[TestCase("if (a > b) c = 0;", true, TestName = "Exercise4C_ValidateIfStatement_WhenValid_ReturnsTrue")]
		[TestCase("if (a > b) c = 0 else b = 0;", false, TestName = "Exercise4C_ValidateIfStatement_WhenMissingSemiColon_ReturnsFalse")]
		public void Exercise4_ValidateIfStatement_ShouldValidateIfStatement(string ifStatement, bool expected)
		{
			// Arrange

			// Act
			bool result = Section1.ValidateIfStatement(ifStatement);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(0.3, 0.4, true, TestName = "Exercise5_BothInRange_WhenInRange_ReturnsTrue")]
		[TestCase(-1, 0.4, false, TestName = "Exercise5_BothInRange_WhenXOutOfRange_ReturnsFalse")]
		[TestCase(0.3, 2, false, TestName = "Exercise5_BothInRange_WhenYOutOfRange_ReturnsFalse")]
		[TestCase(0.00000001, 0.9999999999, true, TestName = "Exercise5_BothInRange_WhenBothInRangeEdgeCases_ReturnsTrue")]
		[TestCase(-0.00000001, 0.5, false, TestName = "Exercise5_BothInRange_WhenXOutOfRangeEdgeCase_ReturnsFalse")]
		[TestCase(0.5, 1.00000001, false, TestName = "Exercise5_BothInRange_WhenYOutOfRangeEdgeCase_ReturnsFalse")]
		public void Exercise5_BothInRange_ShouldValidateInRange(double x, double y, bool expected)
		{
			// Arrange

			// Act
			bool result = Section1.BothInRange(x, y);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(5, new int[] { 0, 1, 1, 2, 3, 5 }, TestName = "Exercise6_GetFibonacci_UpTo5_ShouldReturnFibonacci")]
		[TestCase(10, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 }, TestName = "Exercise6_GetFibonacci_UpTo10_ShouldReturnFibonacci")]
		[TestCase(15, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610 }, TestName = "Exercise6_GetFibonacci_Upto15_ShouldReturnFibonacci")]
		public void Exercise6_GetFibonacci_ShouldReturnFibonacci(int count, int[] expected)
		{
			// Arrange

			// Act
			var result = Section1.GetFibonacci(count);

			// Assert
			Assert.AreEqual(result, expected);
		}

		[Test]
		public void Exercise7A_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = new Func<double>(() =>
			{
				double t = 9.0;
				while (Math.Abs(t - 9.0 / t) > 0.001)
				{
					t = (9.0 / t + t) / 2.0;
				}
				return t;

			}).Invoke();

			// Assert
			Assert.That(result, Is.EqualTo(3.0000915541313802));
		}

		[Test]
		public void Exercise7B_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = new Func<int>(() =>
			{
				int sum = 0;
				for (int i = 1; i < 1000; i++)
				{
					for (int j = 0; j < 1; j++)
					{
						sum++;
					}
				}
				return sum;

			}).Invoke();

			// Assert
			Assert.That(result, Is.EqualTo(999));
		}

		[Test]
		public void Exercise7C_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = new Func<int>(() =>
			{
				int sum = 0;
				for (int i = 1; i < 1000; i *= 2)
				{
					for (int j = 0; j < 1000; j++)
					{
						sum++;
					}
				}
				return sum;

			}).Invoke();

			// Assert
			Assert.That(result, Is.EqualTo(10000));
		}

		[Test]
		public void Exercise8A_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = 'b';

			// Assert
			Assert.That(result, Is.EqualTo('b'));
		}

		[Test]
		public void Exercise8B_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = 'b' + 'c';

			// Assert
			Assert.That(result, Is.EqualTo(197));
		}

		[Test]
		public void Exercise8C_ShouldReturnExpected()
		{
			// Arrange

			// Act
			var result = (char)('a' + 4);

			// Assert
			Assert.That(result, Is.EqualTo('e'));
		}

		[TestCase(0, "0", TestName = "Exercise9_IntToBin_When0_ShouldGetBin")]
		[TestCase(1, "1", TestName = "Exercise9_IntToBin_When1_ShouldGetBin")]
		[TestCase(2, "10", TestName = "Exercise9_IntToBin_When2_ShouldGetBin")]
		[TestCase(1234, "10011010010", TestName = "Exercise9_IntToBin_When1234_ShouldGetBin")]
		public void Exercise9_IntToBin_ShouldGetBin(int value, string expected)
		{
			// Arrange

			// Act
			var result = Section1.IntToBin(value);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Exercise9_IntToBin_WhenNegative_ShouldThrowArgumentException()
		{
			// Arrange

			// Act and Assert
			Assert.Throws<ArgumentException>(() => Section1.IntToBin(-1));
		}

		[Test]
		public void Exercise10_WhatsWrongWithStatement()
		{
			/* What's wrong with the following
			 * int[] a;
			 * for (int i = 0; i < 10; i++)
			 *    a[i] = i * i;
			 */
			Assert.Pass("a is never initialized");
		}

		[TestCaseSource("TwoDimensionalBools")]
		public void Exercise11_BoolToStars_ReturnsExpected(bool[,] bools, char[,] expected)
		{
			// Arrange

			// Act
			var result = Section1.BoolToStars(bools);

			// Assert
			Assert.AreEqual(result, expected);
		}

		public static IEnumerable<TestCaseData> TwoDimensionalBools()
		{
			TestCaseData testCaseData = new(new bool[,] { }, new char[,] { });
			testCaseData.SetName("Exercise11_BoolToStars_WhenEmpty_ReturnsEmpty");
			yield return testCaseData;
			testCaseData = new TestCaseData(new bool[,] { { true, false }, { false, true } }, new char[,] { { '*', ' ' }, { ' ', '*' } });
			testCaseData.SetName("Exercise11_BoolToStars_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new bool[,] { { true, false, true }, { false, true, false } }, new char[,] { { '*', ' ', '*' }, { ' ', '*', ' ' } });
			testCaseData.SetName("Exercise11_BoolToStars_When3x3_ReturnsExpected");
			yield return testCaseData;
		}

		[Test]
		public void Exercise11_BoolToStars_WhenBoolsNull_ThrowsArgumentNullException()
		{
			// Arrange

			// Act and Assert
			Assert.Throws<ArgumentNullException>(() => Section1.BoolToStars(null));
		}

		[Test]
		public void Exercise12_ReturnsExpected()
		{
			// Arrange

			// Act
			int[] a = new int[10];
			for (int i = 0; i < 10; i++)
				a[i] = 9 - i;
			for (int i = 0; i < 10; i++)
				a[i] = a[a[i]];

			// Assert
			Assert.AreEqual(a, new int[] { 0, 1, 2, 3, 4, 4, 3, 2, 1, 0 });
		}

		[TestCaseSource("TwoDimensionalInts")]
		public void Exercise13_Transpose_ReturnsExpected(int[,] toTranspose, int[,] expected)
		{
			// Arrange

			// Act
			var result = Section1.Transpose(toTranspose);

			// Assert
			Assert.AreEqual(result, expected);
		}

		public static IEnumerable<TestCaseData> TwoDimensionalInts()
		{
			TestCaseData testCaseData = new(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } }, new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } });
			testCaseData.SetName("Exercise13_Transpose_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, new int[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } });
			testCaseData.SetName("Exercise13_Transpose_When3x3_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new int[,] { { 1, 2, 3, 4, 5, 6 } }, new int[,] { { 1 }, { 2 }, { 3 }, { 4 }, { 5 }, { 6 } });
			testCaseData.SetName("Exercise13_Transpose_When1x6_ReturnsExpected");
			yield return testCaseData;
		}

		[TestCase(2, 0, TestName = "Exercise14_LargestValueLessThanBaseTwoLog_When2_Returns0")]
		[TestCase(3, 1, TestName = "Exercise14_LargestValueLessThanBaseTwoLog_When3_Returns1")]
		[TestCase(4, 1, TestName = "Exercise14_LargestValueLessThanBaseTwoLog_When4_Returns1")]
		[TestCase(5, 2, TestName = "Exercise14_LargestValueLessThanBaseTwoLog_When5_Returns2")]
		[TestCase(6, 2, TestName = "Exercise14_LargestValueLessThanBaseTwoLog_When6_Returns2")]
		[TestCase(7, 2, TestName = "Exercise14_LargestValueLessThanBaseTwoLog_When7_Returns2")]
		[TestCase(8, 2, TestName = "Exercise14_LargestValueLessThanBaseTwoLog_When8_Returns2")]
		[TestCase(9, 3, TestName = "Exercise14_LargestValueLessThanBaseTwoLog_When9_Returns3")]
		public void Exercise14_LargestValueLessThanBaseTwoLog_ReturnsExpected(int value, int expected)
		{
			// Arrange

			// Act
			var result = Section1.LargestValueLessThanBaseTwoLog(value);

			// Assert
			Assert.That(result, Is.EqualTo(result));
		}

		[Test]
		public void Exercise14_LargestValueLessThanBaseTwoLog_WhenLessThan2_ThrowsArgumentException()
		{
			// Arrange

			// Act and Assert
			Assert.Throws<ArgumentException>(() => Section1.LargestValueLessThanBaseTwoLog(1));

		}

		[TestCase(new int[] { 0, 1, 3, 2, 2, 3, 3, 4, 5, 4, 4, 1, 1, 1 }, 6, new int[] { 1, 4, 2, 3, 3, 1 }, TestName = "Exercise15_Histogram_ReturnsExpected")]
		[TestCase(new int[] { }, 3, new int[] { 0, 0, 0 }, TestName = "Exercise15_Histogram_WhenEmpty_ReturnsExpected")]
		public void Exercise15_Histogram_ReturnsExpected(int[] values, int histogramLength, int[] expected)
		{
			// Arrange

			// Act
			var result = Section1.Histogram(values, histogramLength);

			// Assert
			Assert.AreEqual(result, expected);
		}

		[TestCase(6, "311361142246")]
		[TestCase(10, "114224722531135710225311358311361142246810")]
		public void Exercise16_ExR1_ReturnsExpected(int value, string expected)
		{
			// Arrange

			// Act
			var result = Section1.ExR1(value);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Exercise17_CriticizeTheRecursiveFunction()
		{
			/*public static String exR2(int n)
			 *{
			 *   String s = exR2(n-3) + n + exR2(n-2) + n;
			 *   if (n <= 0) return "";
			 *   return s;
			 *}
			 */
			Assert.Pass("The base case is never reached. The result is a StackOverflowException");
		}

		[TestCase(0, 0, 0, TestName = "Exercise18_Multiply_WhenAllZero_ReturnsExpected")]
		[TestCase(1, 0, 0, TestName = "Exercise18_Multiply_WhenAZero_ReturnsExpected")]
		[TestCase(0, 1, 0, TestName = "Exercise18_Multiply_WhenBZero_ReturnsExpected")]
		[TestCase(2, 25, 50, TestName = "Exercise18_Multiply_WhenGiven2And25_ReturnsExpected")]
		[TestCase(3, 11, 33, TestName = "Exercise18_Multiply_WhenGiven3And11_ReturnsExpected")]
		public void Exercise18_Multiply_ReturnsExpected(int a, int b, int expected)
		{
			// Arrange

			// Act
			var result = Section1.Multiply(a, b);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Exercise18_Multiply_WhenBNegative_ThrowsArgumentException()
		{
			// Arrange

			// Act and Assert
			Assert.Throws<ArgumentException>(() => Section1.Multiply(1, -1));
		}

		[TestCase(0, 0, 1, TestName = "Exercise18_Power_WhenAllZero_ReturnsExpected")]
		[TestCase(1, 0, 1, TestName = "Exercise18_Power_WhenRaiseToZero_ReturnsExpected")]
		[TestCase(1, 1, 1, TestName = "Exercise18_Power_WhenRaiseOneToOne_ReturnsExpected")]
		[TestCase(2, 25, 33554432, TestName = "Exercise18_Power_WhenRaise2To25_ReturnsExpected")]
		[TestCase(3, 11, 177147, TestName = "Exercise18_Power_WhenRaise3To11_ReturnsExpected")]
		[TestCase(-1, 2, 1, TestName = "Exercise18_Power_WhenRaiseNeg1To2_ReturnsExpected")]
		[TestCase(-1, 3, -1, TestName = "Exercise18_Power_WhenRaiseNeg1To3_ReturnsExpected")]
		public void Exercise18_Power_ReturnsExpected(int a, int b, int expected)
		{
			// Arrange

			// Act
			var result = Section1.Power(a, b);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Exercise18_Power_WhenBNegative_ThrowsArgumentException()
		{
			// Arrange

			// Act and Assert
			Assert.Throws<ArgumentException>(() => Section1.Power(1, -1));
		}

		[TestCase(0, 0, TestName = "Exercise19_RecursiveFibonacci_When0_ReturnsExpected")]
		[TestCase(1, 1, TestName = "Exercise19_RecursiveFibonacci_When1_ReturnsExpected")]
		[TestCase(2, 1, TestName = "Exercise19_RecursiveFibonacci_When2_ReturnsExpected")]
		[TestCase(3, 2, TestName = "Exercise19_RecursiveFibonacci_When3_ReturnsExpected")]
		[TestCase(4, 3, TestName = "Exercise19_RecursiveFibonacci_When4_ReturnsExpected")]
		[TestCase(5, 5, TestName = "Exercise19_RecursiveFibonacci_When5_ReturnsExpected")]
		public void Exercise19_RecursiveFibonacci_ReturnsExpected(int fibonacci, int expected)
		{
			// Arrange

			// Act
			var result = Section1.RecursiveFibonacci(fibonacci);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(0, 0, TestName = "Exercise19_Fibonacci_When0_ReturnsExpected")]
		[TestCase(1, 1, TestName = "Exercise19_Fibonacci_When1_ReturnsExpected")]
		[TestCase(2, 1, TestName = "Exercise19_Fibonacci_When2_ReturnsExpected")]
		[TestCase(3, 2, TestName = "Exercise19_Fibonacci_When3_ReturnsExpected")]
		[TestCase(4, 3, TestName = "Exercise19_Fibonacci_When4_ReturnsExpected")]
		[TestCase(5, 5, TestName = "Exercise19_Fibonacci_When5_ReturnsExpected")]
		public void Exercise19_Fibonacci_ReturnsExpected(int fibonacci, int expected)
		{
			// Arrange

			// Act
			var result = Section1.Fibonacci(fibonacci);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(30, TestName = "Exercise19_Fibonacci_When20_ForLoopFibonacci_FasterThanRecursiveFibonacci_AtHigherValues")]
		[TestCase(31, TestName = "Exercise19_Fibonacci_When21_ForLoopFibonacci_FasterThanRecursiveFibonacci_AtHigherValues")]
		[TestCase(32, TestName = "Exercise19_Fibonacci_When22_ForLoopFibonacci_FasterThanRecursiveFibonacci_AtHigherValues")]
		[TestCase(33, TestName = "Exercise19_Fibonacci_When23_ForLoopFibonacci_FasterThanRecursiveFibonacci_AtHigherValues")]
		[TestCase(34, TestName = "Exercise19_Fibonacci_When24_ForLoopFibonacci_FasterThanRecursiveFibonacci_AtHigherValues")]
		[TestCase(35, TestName = "Exercise19_Fibonacci_When25_ForLoopFibonacci_FasterThanRecursiveFibonacci_AtHigherValues")]
		public void Exercise19_ForLoopFibonacci_FasterThanRecursiveFibonacci_AtHigherValues(int fibonacci)
		{
			// Arrange and Act
			Stopwatch sw = Stopwatch.StartNew();
			Section1.RecursiveFibonacci(fibonacci);
			sw.Stop();
			TimeSpan recurFibTime = sw.Elapsed;

			sw.Restart();
			Section1.Fibonacci(fibonacci);
			sw.Stop();
			TimeSpan fibTime = sw.Elapsed;

			// Assert
			Assert.That(fibTime, Is.LessThan(recurFibTime));
		}

		[TestCase(1, 0, TestName = "Exercise20_LogFact_When1_ReturnsExpected")]
		[TestCase(2, 0.69314718055994529, TestName = "Exercise20_LogFact_When2_ReturnsExpected")]
		[TestCase(10, 15.104412573075518, TestName = "Exercise20_LogFact_When10_ReturnsExpected")]
		public void Exercise20_LogFact_ReturnsExpected(int n, double expected)
		{
			// Arrange

			// Act
			var result = Section1.LogFact(n);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(0, TestName = "Exercise20_LogFact_When0_ThrowsArgumentException")]
		[TestCase(-1, TestName = "Exercise20_LogFact_WhenNeg1_ThrowsArgumentException")]
		public void Exercise20_LogFact_WhenLessThanOne_ThrowsArgumentException(int n)
		{
			// Arrange
			// Act and Assert
			Assert.Throws<ArgumentException>(() => Section1.LogFact(n));
		}

		[TestCase(5, new int[] { }, -1, "", TestName = "Exercise22_Rank_WhenValuesEmpty_ReturnsNeg1")]
		[TestCase(5, new int[] { 2, 3, 5, 8, 9, 20, 31 }, 2, "lo:0 hi6\r\n\tlo:0 hi2\r\n\t\tlo:2 hi2\r\n", TestName = "Exercise22_Rank_WhenKeyInValues_ReturnsIndex")]
		[TestCase(4, new int[] { 2, 3, 5, 8, 9, 20, 31 }, -1, "lo:0 hi6\r\n\tlo:0 hi2\r\n\t\tlo:2 hi2\r\n\t\t\tlo:2 hi1\r\n", TestName = "Exercise22_Rank_WhenKeyNotInValues_ReturnsNeg1")]
		public void Exercise22_Rank_FindsKeyInValues(int key, int[] values, int expected, string expectedLoHi)
		{
			// Arrange

			// Act
			var consoleOut = Console.Out;
			using (StringWriter consoleOutput = new())
			{

				Console.SetOut(consoleOutput);
				var result = Section1.Rank(key, values, true);

				// Assert
				Assert.That(result, Is.EqualTo(expected));
				Assert.That(consoleOutput.ToString().Equals(expectedLoHi));
			}
			Console.SetOut(consoleOut);
		}

		[Test]
		public void Exercise22_Rank_WhenValuesNull_ThrowsArgumentNullException()
		{
			// Arrange

			// Act and Assert
			Assert.Throws<ArgumentNullException>(() => Section1.Rank(1, null));
		}

		[TestCase("Chapter1\\Data\\tinyAllowlist.txt", "Chapter1\\Data\\tinyText.txt", '+', "50\r\n99\r\n13\r\n", TestName = "Exercise23_BinarySearch_PrintsValuesNotInWhitelist")]
		[TestCase("Chapter1\\Data\\tinyAllowlist.txt", "Chapter1\\Data\\tinyText.txt", '-', "23\r\n10\r\n18\r\n23\r\n98\r\n84\r\n11\r\n10\r\n48\r\n77\r\n54\r\n98\r\n77\r\n77\r\n68\r\n", TestName = "Exercise23_BinarySearch_PrintsValuesInWhitelist")]
		public void Exercise23_BinarySearch_PrintInOutWhitelist(string whitelistFile, string testFile, char shouldPrint, string expected)
		{
			// Arrange
			var consoleOut = Console.Out;
			using (StringWriter consoleOutput = new())
			{
				Console.SetOut(consoleOutput);

				// Act
				Section1.BinarySearch(whitelistFile, testFile, shouldPrint);

				// Assert
				Assert.That(consoleOutput.ToString(), Is.EqualTo(expected));
			}
			Console.SetOut(consoleOut);
		}

		[Test]
		public void Exercise23_BinarySearch_ShouldThrow()
		{
			Assert.Multiple(() =>
			{
				Assert.Throws<ArgumentNullException>(() => Section1.BinarySearch(null, "Chapter1\\Data\\tinyText.txt", '+'));
				Assert.Throws<ArgumentNullException>(() => Section1.BinarySearch("Chapter1\\Data\\tinyAllowlist.txt", null, '+'));
				Assert.Throws<ArgumentException>(() => Section1.BinarySearch("Chapter1\\Data\\NonExistentFile.txt", "Chapter1\\Data\\tinyText.txt", '+'));
				Assert.Throws<ArgumentException>(() => Section1.BinarySearch("Chapter1\\Data\\tinyAllowlist.txt", "Chapter1\\Data\\NonExistentFile.txt", '+'));
				Assert.Throws<ArgumentException>(() => Section1.BinarySearch("Chapter1\\Data\\tinyAllowlist.txt", "Chapter1\\Data\\tinyText.txt", 'x'));
			});
		}

		[TestCase(24, 16, 8, TestName = "Exercise24_Euclid_WhenNotOne_GetsGCD")]
		[TestCase(8567, 561, 1, TestName = "Exercise24_Euclid_WhenOne_GetsGCD")]
		public void Exercise24_Euclid_GetsGCD(int high, int low, int expected)
		{
			// Arrange

			// Act
			int result = Section1.Euclid(high, low);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Exercise24_WhenGetGCD_ShouldPrint()
		{
			var consoleOut = Console.Out;
			using (StringWriter consoleOutput = new())
			{
				Console.SetOut(consoleOutput);

				// Act
				int result = Section1.Euclid(1234567, 1111111, true);

				// Assert
				Assert.That(result, Is.EqualTo(1));
				Assert.That(consoleOutput.ToString(), Is.EqualTo("High 1234567 Low 1111111 Remainder 123456\r\nHigh 1111111 Low 123456 Remainder 7\r\nHigh 123456 Low 7 Remainder 4\r\nHigh 7 Low 4 Remainder 3\r\nHigh 4 Low 3 Remainder 1\r\nHigh 3 Low 1 Remainder 0\r\n"));
			}
			Console.SetOut(consoleOut);
		}

		[Test]
		public void Exercise25_Euclid_Proof()
		{
			// Source https://www.whitman.edu/mathematics/higher_math_online/section03.03.html
			// Lemma: Suppose a and b are not both zero.
			//	a. (a, b) = (b, a),
			//	b. if a > 0 and a | b then(a, b) = a,
			//	c. if a ≡ c (mod b), then(a, b) = (c, b).

			// Part a. (a, b) = (b, a)
			int a = 16;
			int b = 24;
			Assert.That(Section1.Euclid(a, b), Is.EqualTo(Section1.Euclid(b, a)), "Prove that GCD(a,b) is equal to GCD(b,a)");

			// Part b. if a > 0 and a | b then(a, b) = a
			a = 8;
			b = 24;
			Assert.That(a > 0, "Prove a is greater than 0");
			Assert.That(b % a, Is.EqualTo(0), "Prove b is evenly divisible by a");
			Assert.That(a, Is.EqualTo(Section1.Euclid(a, b)), "Prove the GCD(a,b) is equal to a");

			// Part c. if a ≡ c (mod b), then(a, b) = (c, b).
			a = 12;
			b = 24;
			int c = 60;
			Assert.That(a, Is.EqualTo(c % b), "Prove that a is equal to c mod b");
			Assert.That(Section1.Euclid(a, b), Is.EqualTo(Section1.Euclid(c, b)), "Prove that GCD(a,b) is equal to GCD(c,b)");
		}

		[TestCase(3, 2, 1, new[] { 1, 2, 3 }, TestName = "Exercise26_Sort_SortDescendingToAscending")]
		[TestCase(1, 2, 3, new[] { 1, 2, 3 }, TestName = "Exercise26_Sort_SortAscendingToAscending")]
		[TestCase(3, 1, 2, new[] { 1, 2, 3 }, TestName = "Exercise26_Sort_SortAscendingToAscending")]
		[TestCase(1, 1, 1, new[] { 1, 1, 1 }, TestName = "Exercise26_Sort_SortsSameValues")]
		public void Exercise26_Sort_ShouldSort(int a, int b, int c, IEnumerable<int> expected)
		{
			// Arrange

			// Act
			var result = Section1.Sort(a, b, c);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(10, 5, 0.25, 0.058399200439453125, TestName = "Exercise27_BinomialRecursive_Trials10_Successes5_ShouldCalculateLikelihood")]
		[TestCase(10, 3, 0.25, 0.25028228759765625, TestName = "Exercise27_BinomialRecursive_Trials10_Successes3_ShouldCalculateLikelihood")]
		[TestCase(10, 2, 0.25, 0.2815675735473633, TestName = "Exercise27_BinomialRecursive_Trials10_Successes2_ShouldCalculateLikelihood")]
		[TestCase(10, 1, 0.25, 0.18771171569824219d, TestName = "Exercise27_BinomialRecursive_Trials10_Successes1_ShouldCalculateLikelihood")]
		public void Exercise27_BinomialRecursive_ShouldCalculateLikelihood(int trials, int successes, double probability, double expected)
		{
			// Arrange
			// The book example binomial(100, 50, 0.25) runs recursively for too long to get a result

			// Assert
			var result = Section1.RecursiveBinomial(trials, successes, probability);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(1, 1, TestName = "Exercise27_Factorial1_ShouldCalculate")]
		[TestCase(2, 2, TestName = "Exercise27_Factorial2_ShouldCalculate")]
		[TestCase(3, 6, TestName = "Exercise27_Factorial3_ShouldCalculate")]
		[TestCase(4, 24, TestName = "Exercise27_Factorial4_ShouldCalculate")]
		[TestCase(5, 120, TestName = "Exercise27_Factorial5_ShouldCalculate")]
		public void Exercise27_Factorial_ShouldCalculate(int value, int expected)
		{
			// Arrange

			// Act
			BigInteger result = Section1.Factorial(value);

			// Assert
			Assert.That((int)result, Is.EqualTo(expected));
		}

		[TestCase(100, 50, 0.25, 4.5073108750863822E-08d, TestName = "Exercise27_Recursive_Trials100_Successes50_ShouldCalculateLikelihood")]
		[TestCase(10, 5, 0.25, 0.058399200439453125, TestName = "Exercise27_Recursive_Trials10_Successes5_ShouldCalculateLikelihood")]
		[TestCase(10, 3, 0.25, 0.25028228759765625, TestName = "Exercise27_Recursive_Trials10_Successes3_ShouldCalculateLikelihood")]
		[TestCase(10, 2, 0.25, 0.2815675735473633, TestName = "Exercise27_Recursive_Trials10_Successes2_ShouldCalculateLikelihood")]
		[TestCase(10, 1, 0.25, 0.18771171569824219, TestName = "Exercise27_Recursive_Trials10_Successes1_ShouldCalculateLikelihood")]
		public void Exercise27_Binomial_ShouldCalculateLikelihood(int trials, int successes, double probability, double expected)
		{
			// Arrange

			// Assert
			var result = Section1.Binomial(trials, successes, probability);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(0, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, TestName = "Exercise29_RankLess0_ReturnsNumberOfValuesLess")]
		[TestCase(1, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, TestName = "Exercise29_RankLess1_ReturnsNumberOfValuesLess")]
		[TestCase(5, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 4, TestName = "Exercise29_RankLess5_ReturnsNumberOfValuesLess")]
		[TestCase(5, new[] { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9 }, 4, TestName = "Exercise29_RankLess5_WhenTwo5s_ReturnsNumberOfValuesLess")]
		[TestCase(5, new[] { 1, 2, 3, 4, 5, 5, 5, 6, 7, 8, 9 }, 4, TestName = "Exercise29_RankLess5_WhenThree5s_ReturnsNumberOfValuesLess")]
		public void Exercise29_RankLess_ReturnsNumberOfValuesLess(int key, int[] values, int expected)
		{
			// Arrange

			// Act
			int result = Section1.RankLess(key, values);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(0, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, TestName = "Exercise29_Count0_ReturnsCount")]
		[TestCase(1, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, TestName = "Exercise29_Count1_ReturnsCount")]
		[TestCase(5, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, TestName = "Exercise29_Count5_ReturnsCount")]
		[TestCase(5, new[] { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9 }, 2, TestName = "Exercise29_Count5_WhenTwo5s_ReturnsCount")]
		[TestCase(5, new[] { 1, 2, 3, 4, 5, 5, 5, 6, 7, 8, 9 }, 3, TestName = "Exercise29_Count5_WhenThree5s_ReturnsCount")]
		public void Exercise29_RankCount_ReturnsCountOfKey(int key, int[] values, int expected)
		{
			// Arrange

			// Act
			int result = Section1.RankCount(key, values);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCaseSource("RelativelyPrimeBools")]
		public void Exercise30_RelativelyPrime_ReturnsExpected(int dimension, bool[,] expected)
		{
			// Act
			var result = Section1.RelativelyPrime(dimension);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		public static IEnumerable<TestCaseData> RelativelyPrimeBools()
		{
			TestCaseData testCaseData = new(0, new bool[,] { });
			testCaseData.SetName("Exercise30_RelativelyPrime_WhenZero_ReturnsEmpty");
			yield return testCaseData;
			testCaseData = new TestCaseData(2, new bool[,] { { false, true }, { true, true } });
			testCaseData.SetName("Exercise30_RelativelyPrime_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(3, new bool[,] { { false, true, false }, { true, true, true }, { false, true, false } });
			testCaseData.SetName("Exercise30_RelativelyPrime_When3x3_ReturnsExpected");
			yield return testCaseData;
		}

		[TestCase(2, 0, TestName = "Exercise31_When2PointsAnd0Probability_ReturnsExpected")]
		[TestCase(4, 0, TestName = "Exercise31_When4PointsAnd0Probability_ReturnsExpected")]
		[TestCase(6, 1, TestName = "Exercise31_When6PointsAnd100Probability_ReturnsExpected")]
		[TestCase(12, 1, TestName = "Exercise31_When12PointsAnd100Probability_ReturnsExpected")]
		public void Exercise31(int number, double probability)
		{
			// Arrange

			// Act
			var pointPairs = Section1.RandomConnections(number, probability);

			// Assert
			double angle = 360.0 / number;
			for (int i = 0; i < number; i++)
			{
				double angleInRadians = angle * i * Math.PI / 180;
				Assert.That(pointPairs.ElementAt(i).Point1.X, Is.EqualTo(Math.Cos(angleInRadians)));
				Assert.That(pointPairs.ElementAt(i).Point1.Y, Is.EqualTo(Math.Sin(angleInRadians)));

				if (probability == 0) Assert.That(pointPairs.ElementAt(i).Connected, Is.False);
				else Assert.That(pointPairs.ElementAt(i).Connected, Is.True);

				if ((i + 1) == number)
				{
					Assert.That(pointPairs.ElementAt(i).Point2.X, Is.EqualTo(Math.Cos(0)));
					Assert.That(pointPairs.ElementAt(i).Point2.Y, Is.EqualTo(Math.Sin(0)));
				}
				else
				{
					double nextAngleInRadians = angle * (i + 1) * Math.PI / 180;
					Assert.That(pointPairs.ElementAt(i).Point2.X, Is.EqualTo(Math.Cos(nextAngleInRadians)));
					Assert.That(pointPairs.ElementAt(i).Point2.Y, Is.EqualTo(Math.Sin(nextAngleInRadians)));
				}
			}
		}

		[TestCase(new double[] { 85, 79, 41, 21, 64, 4, 42, 31, 87, 81 }, 5, 20, 120, new int[] { 1, 2, 2, 2, 3 }, "x\r\nxx\r\nxx\r\nxx\r\nxxx\r\n", TestName = "Exercise32_Histogram1_OutputsExpected")]
		[TestCase(new double[] { 70, 35, 39, 90, 29, 23, 2, 88, 16, 82 }, 5, 20, 120, new int[] { 2, 4, 0, 1, 3 }, "xx\r\nxxxx\r\n\r\nx\r\nxxx\r\n", TestName = "Exercise32_Histogram2_OutputsExpected")]
		[TestCase(new double[] { 99, 19, 60, 13, 72, 68, 36, 57, 43, 9 }, 5, 20, 120, new int[] { 3, 1, 2, 3, 1 }, "xxx\r\nx\r\nxx\r\nxxx\r\nx\r\n", TestName = "Exercise32_Histogram3_OutputsExpected")]
		public void Exercise32(double[] sequence, int intervals, double left, double right, int[] expected, string expectedConsoleOut)
		{
			var consoleOut = Console.Out;
			using (StringWriter consoleOutput = new())
			{

				Console.SetOut(consoleOutput);
				var result = Section1.Histogram(sequence, intervals, left, right);

				// Assert
				Assert.That(result, Is.EqualTo(expected));
				Assert.That(consoleOutput.ToString().Equals(expectedConsoleOut));
			}
			Console.SetOut(consoleOut);
		}

		[TestCase(new double[] { 7, 8 }, new double[] { 9, 10 }, 143, TestName = "Exercise33_VectorProduct_With2Dimensions_ReturnsExpected")]
		[TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 }, 32, TestName = "Exercise33_VectorProduct_With3Dimensions_ReturnsExpected")]
		[TestCase(new double[] { 1, 11, 12, 94 }, new double[] { 0, 9, 27, 66 }, 6627, TestName = "Exercise33_VectorProduct_With4Dimensions_ReturnsExpected")]
		public void Exercise33_VectorProduct(double[] a, double[] b, double expected)
		{
			// Arrange

			// Act
			var result = Section1.VectorDot(a, b);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCaseSource("MatrixProduct")]
		public void Exercise33_MatrixProduct_ReturnsExpected(double[,] a, double[,] b, double[,] expected)
		{
			// Arrange

			// Act
			var result = Section1.MatrixProduct(a, b);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		public static IEnumerable<TestCaseData> MatrixProduct()
		{
			TestCaseData testCaseData = new(new double[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } },
				new double[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } }, new double[,] { { 15, 18, 21 }, { 42, 54, 66 }, { 69, 90, 111 } });
			testCaseData.SetName("Exercise33_MatrixProduct_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new double[,] { { 3, 4, 2 } },
				new double[,] { { 13, 9, 7, 15 }, { 8, 7, 4, 6 }, { 6, 4, 0, 3 } }, new double[,] { { 83, 63, 37, 75 } });
			testCaseData.SetName("Exercise33_MatrixProduct_When1x3_Mult3x4_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new double[,] { { 1, 2, 3 } },
				new double[,] { { 4 }, { 5 }, { 6 } }, new double[,] { { 32 } });
			testCaseData.SetName("Exercise33_MatrixProduct_When1x3_Mult3x1_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new double[,] { { 4 }, { 5 }, { 6 } },
				new double[,] { { 1, 2, 3 } }, new double[,] { { 4, 8, 12 }, { 5, 10, 15 }, { 6, 12, 18 } });
			testCaseData.SetName("Exercise33_MatrixProduct_When3x1_Mult1x3_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new double[,] { { 1, 2, 3 } },
				new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }, new double[,] { { 1, 2, 3 } });
			testCaseData.SetName("Exercise33_MatrixProduct_WhenMultByIdentity_ReturnsExpected");
			yield return testCaseData;
		}

		[TestCaseSource("MatrixTranspose")]
		public void Exercise33_MatrixTranspose_ReturnsExpected(double[,] a, double[,] expected)
		{
			// Act

			// Arrange
			var result = Section1.MatrixTranspose(a);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		public static IEnumerable<TestCaseData> MatrixTranspose()
		{
			TestCaseData testCaseData = new(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
				new double[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } });
			testCaseData.SetName("Exercise33_MatrixTranspose_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new double[,] { { 1, 2, 3 } }, new double[,] { { 1 }, { 2 }, { 3 } });
			testCaseData.SetName("Exercise33_MatrixTranspose_When1x3_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new double[,] { { 1 } }, new double[,] { { 1 } });
			testCaseData.SetName("Exercise33_MatrixTranspose_When1x1_ReturnsExpected");
			yield return testCaseData;
		}

		[TestCaseSource("MatrixVectorProduct")]
		public void Exercise33_MatrixVectorProduct_ReturnsExpected(double[,] a, double[] x, double[] expected)
		{
			// Arrange

			// Act
			var result = Section1.MatrixVectorProduct(a, x);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		public static IEnumerable<TestCaseData> MatrixVectorProduct()
		{
			TestCaseData testCaseData = new(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, new double[] { 1, 2, 3 },
				new double[] { 14, 32, 50 });
			testCaseData.SetName("Exercise33_MatrixVectorProduct_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } }, new double[] { 1, 2, 3, 4 },
				new double[] { 30, 70 });
			testCaseData.SetName("Exercise33_MatrixVectorProduct_When4x2_ReturnsExpected");
			yield return testCaseData;
		}

		[TestCaseSource("VectorMatrixProduct")]
		public void Exercise33_VectorMatrixProduct_ReturnsExpected(double[] y, double[,] a, double[] expected)
		{
			// Arrange

			// Act
			var result = Section1.VectorMatrixProduct(y, a);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		public static IEnumerable<TestCaseData> VectorMatrixProduct()
		{
			TestCaseData testCaseData = new(new double[] { 1, 2, 3 }, new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
				new double[] { 14, 32, 50 });
			testCaseData.SetName("Exercise33_VectorMatrixProduct_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new TestCaseData(new double[] { 1, 2, 3, 4 }, new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } },
				new double[] { 30, 70 });
			testCaseData.SetName("Exercise33_VectorMatrixProduct_When4x2_ReturnsExpected");
			yield return testCaseData;
		}

		[TestCaseSource("MinMax")]
		public void Exercise34_MinMax_ReturnsExpected(double[] values, (double min, double max) expected)
		{
			// Arrange
			var section1 = new Section1();

			// Act
			(double min, double max) result = (0, 0);
			foreach (double value in values)
			{
				result = section1.MinMax(value);
			}

			// Assert
			Assert.That(result == expected);
		}

		public static IEnumerable<TestCaseData> MinMax()
		{
			TestCaseData testCaseData = new(new double[] { 1, 2, 3, 4, 5, 6, 7 }, (1d, 7d));
			testCaseData.SetName("Exercise34_MinMax_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new(new double[] { -7, -6, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 }, (-7d, 7d));
			testCaseData.SetName("Exercise34_MinMax_WhenMinNeg7And7_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new(new double[] { 3 }, (3d, 3d));
			testCaseData.SetName("Exercise34_MinMax_WhenOneValue_ReturnsExpected");
			yield return testCaseData;
			testCaseData = new(new double[] { 32, 81, 4, 79, 22, 16, 15, 39, 100, 41 }, (4d, 100d));
			testCaseData.SetName("Exercise34_MinMax_WhenValuesUnordered_ReturnsExpected");
			yield return testCaseData;
		}

		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5.5, TestName = "Exercise34_Median_WhenEvenCount_ReturnsExpected")]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7 }, 4, TestName = "Exercise34_Median_WhenOddCount_ReturnsExpected")]
		[TestCase(new double[] { 7 }, 7, TestName = "Exercise34_Median_WhenOneValue_ReturnsExpected")]
		[TestCase(new double[] { 60, 74, 30, 77, 58, 43, 44, 53, 86, 66 }, 59, TestName = "Exercise34_Median_WhenValuesUnordered_ReturnsExpected")]
		public void Exercise34_Median_ReturnsExpected(double[] values, double expected)
		{
			// Arrange
			var section1 = new Section1();

			// Act
			double result = 0;
			foreach (double value in values)
			{
				result = section1.Median(value);
			}

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, 1, TestName = "Exercise34_Smallest_WhenIndex0_ReturnsExpected")]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 3, TestName = "Exercise34_Smallest_WhenIndex2_ReturnsExpected")]
		[TestCase(new double[] { 7 }, 0, 7, TestName = "Exercise34_Smallest_WhenOneValue_ReturnsExpected")]
		[TestCase(new double[] { 7 }, 1, double.NaN, TestName = "Exercise34_Smallest_WhenIndexOutOfRange_ReturnsExpected")]
		[TestCase(new double[] { 60, 74, 30, 77, 58, 43, 44, 53, 86, 66 }, 9, 86, TestName = "Exercise34_Smallest_WhenLastIndex_ReturnsExpected")]
		public void Exercise34_Smallest_ReturnsExpected(double[] values, int index, double expected)
		{
			// Arrange
			var section1 = new Section1();

			// Act
			double result = 0;
			foreach (double value in values)
			{
				result = section1.Smallest(value, index);
			}

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(new double[] { 1, 6, 2, 12, 15, 11 }, 531, TestName = "Exercise34_SumOfSquares_ReturnsExpected")]
		[TestCase(new double[] { 0 }, 0, TestName = "Exercise34_SumOfSquares_WhenValue0_ReturnsExpected")]
		[TestCase(new double[] { -6, 3, 8, -4 }, 125, TestName = "Exercise34_SumOfSquares_WhenNegValues_ReturnsExpected")]
		public void Exercise34_SumOfSquares_ReturnsExpected(double[] values, double expected)
		{
			// Arrange
			var section1 = new Section1();

			// Act
			double result = 0;
			foreach (double value in values)
			{
				result = section1.SumOfSquares(value);
			}

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7 }, 4, TestName = "Exercise34_Average_ReturnsExpected")]
		[TestCase(new double[] { 4 }, 4, TestName = "Exercise34_Average_WhenOneValue_ReturnsExpected")]
		public void Exercise34_Average_ReturnsExpected(double[] values, double expected)
		{
			// Arrange
			var section1 = new Section1();

			// Act
			double result = 0;
			foreach (double value in values)
			{
				result = section1.Average(value);
			}

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7 }, 0.42857142857142855, TestName = "Exercise34_PercentGreaterThanAverage_ReturnsExpected")]
		[TestCase(new double[] { 2, 8, 16, 24, 32, 40 }, 0.5, TestName = "Exercise34_PercentGreaterThanAverage_WhenHalfGreater_ReturnsExpected")]
		[TestCase(new double[] { 2 }, 0, TestName = "Exercise34_PercentGreaterThanAverage_WhenOneValue_ReturnsExpected")]
		public void Exercise34_PercentGreaterThanAverage_ReturnsExpected(double[] values, double expected)
		{
			// Arrange
			var section1 = new Section1();

			// Act
			double result = 0;
			foreach (double value in values)
			{
				result = section1.PercentGreater(value);
			}

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(new double[] { 14, 77, 29, 59, 64 }, "14 \r\n14 77 \r\n14 29 77 \r\n14 29 59 77 \r\n14 29 59 64 77 \r\n", TestName = "Exercise34_PrintInOrder_ReturnsExpected")]
		[TestCase(new double[] { 88 }, "88 \r\n", TestName = "Exercise34_PrintInOrder_WhenOneValue_ReturnsExpected")]
		public void Exercise34_PrintInOrder_ReturnsExpected(double[] values, string expected)
		{
			// Arrange
			var section1 = new Section1();

			var consoleOut = Console.Out;
			using (StringWriter consoleOutput = new())
			{

				Console.SetOut(consoleOutput);

				// Act
				foreach (double value in values)
				{
					section1.PrintInOrder(value);
				}

				// Assert
				Assert.That(consoleOutput.ToString(), Is.EqualTo(expected));
			}
			Console.SetOut(consoleOut);
		}

		[TestCase(new double[] { 88 }, "88 \r\n", TestName = "Exercise34_PrintRandom_WhenOneValue_ReturnsExpected")]
		public void Exercise34_PrintRandom_WhenOneValue_ReturnsExpected(double[] values, string expected)
		{
			// Arrange
			var section1 = new Section1();

			var consoleOut = Console.Out;
			using (StringWriter consoleOutput = new())
			{

				Console.SetOut(consoleOutput);

				// Act
				foreach (double value in values)
				{
					section1.PrintRandom(value);
				}

				// Assert
				Assert.That(consoleOutput.ToString(), Is.EqualTo(expected));
			}
			Console.SetOut(consoleOut);
		}

		[TestCase(6, TestName = "Exercise35_DiceSimulation_FindsRollsToReachDistribution")]
		public void Exercise35_DiceSimulation_FindsRollsToReachDistribution(int sides)
		{
			var test = Section1.DiceDistribution(sides);

			int rolls = 2;
			while (true)
			{
				var simulation = Section1.DiceSimulation(sides, rolls);
				try
				{
					Assert.That(test, Is.EqualTo(simulation).Within(0.001));
					break;
				}
				catch
				{
					rolls *= 2;
				}
			}
			Assert.Pass($"Rolls {rolls:N0}");
		}

		[TestCase(10, 100, TestName = "Exercise36_ShuffleTest_ExpectedDistribution")]
		[TestCase(10, 1000, TestName = "Exercise36_ShuffleTest_When1000Shuffles_ExpectedDistribution")]
		[TestCase(10, 10000, TestName = "Exercise36_ShuffleTest_When10000Shuffles_ExpectedDistribution")]
		public void Exercise36_ShuffleTest_ExpectedDistribution(int arrayLength, int shuffles)
		{
			var values = new double[arrayLength];
			for (int i = 0; i < arrayLength; i++)
			{
				values[i] = i;
			}

			var dist = Section1.ShuffleTest(values, shuffles);
			var delta = 0.1;
			for (int i = 0; i < arrayLength; i++)
			{
				for (int j = 0; j < arrayLength; j++)
				{
					Assert.That(dist[i, j] / shuffles, Is.EqualTo(delta).Within(delta * 1.5));
				}
			}

		}

		[TestCase(10, 100, TestName = "Exercise37_BadShuffleTest_ExpectedDistribution")]
		[TestCase(10, 1000, TestName = "Exercise37_BadShuffleTest_When1000Shuffles_ExpectedDistribution")]
		[TestCase(10, 10000, TestName = "Exercise37_BadShuffleTest_When10000Shuffles_ExpectedDistribution")]
		public void Exercise37_BadShuffleTest_ExpectedDistribution(int arrayLength, int shuffles)
		{
			var values = new double[arrayLength];
			for (int i = 0; i < arrayLength; i++)
			{
				values[i] = i;
			}

			var dist = Section1.ShuffleTest(values, shuffles);
			var delta = 0.01;
			for (int i = 0; i < arrayLength; i++)
			{
				for (int j = 0; j < arrayLength; j++)
				{
					Assert.That(dist[i, j] / shuffles, Is.Not.EqualTo(delta).Within(0.01));
				}
			}
		}

		[TestCase(100, TestName = "Exercise38_BruteForceSearch")]
		[TestCase(1000, TestName = "Exercise38_BruteForceSearch_When1000")]
		[TestCase(10000, TestName = "Exercise38_BruteForceSearch_When10000")]
		public void Exercise38_BruteForceSearch(int n)
		{
			// Arrange
			var values = Section1.GenerateRandomCollection(n).OrderBy(x => x).ToArray();
			Random random = new();
			int value = random.Next(0, n);

			// Act
			Stopwatch sw = Stopwatch.StartNew();
			Section1.BruteForceSearch(value, values);
			sw.Stop();
			var bruteForceTime = sw.Elapsed;

			sw.Restart();
			Section1.Rank(value, values);
			sw.Stop();
			var binaryTime = sw.Elapsed;

			// Assert
			Assert.Pass($"Brute Force Time:{bruteForceTime} Binary Time:{binaryTime}");
		}
	}
}
