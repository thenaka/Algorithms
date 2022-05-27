using System;

namespace AlgorithmExercises.Common
{
	public static class Algorithms
	{
		/// <summary>
		/// Returns the greatest common denominator of <paramref name="p"/> and <paramref name="q"/>.
		/// </summary>
		/// <param name="p">First value.</param>
		/// <param name="q">Second value.</param>
		/// <returns>The greatest common denominator</returns>
		/// <remarks>Uses Euclid's algorithm.</remarks>
		public static int Euclid(int p, int q)
		{
			return Euclid(p, q, false);
		}

		/// <summary>
		/// Returns the greatest common denominator of <paramref name="p"/> and <paramref name="q"/>.
		/// </summary>
		/// <param name="p">First value.</param>
		/// <param name="q">Second value.</param>
		/// <param name="shouldPrint">True if should write to Console <paramref name="p"/>, <paramref name="q"/>, and remainder values.</param>
		/// <returns>The greatest common denominator</returns>
		/// <remarks>Uses Euclid's algorithm.</remarks>
		public static int Euclid(int p, int q, bool shouldPrint)
		{
			if (q == 0) return p;
			int candidate = p % q;
			if (shouldPrint) Console.WriteLine($"High {p} Low {q} Remainder {candidate}");
			return Euclid(q, candidate, shouldPrint);
		}

		/// <summary>
		/// Returns the greatest common denominator of <paramref name="p"/> and <paramref name="q"/>.
		/// </summary>
		/// <param name="p">First value.</param>
		/// <param name="q">Second value.</param>
		/// <returns>The greatest common denominator</returns>
		/// <remarks>Uses Euclid's algorithm.</remarks>
		public static long Euclid(long p, long q)
		{
			if (q == 0) return p;
			(_, long remainder) = Math.DivRem(p, q);
			return Euclid(q, remainder);
		}
	}
}
