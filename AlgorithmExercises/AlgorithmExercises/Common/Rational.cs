using System;

namespace AlgorithmExercises.Common
{
	public class Rational
	{
		private long _numerator;
		private long _denominator;

		/// <summary>
		/// Create an instance of a rational number with the given <paramref name="numerator"/> and <paramref name="denominator"/>.
		/// </summary>
		/// <param name="numerator">Numerator of the rational number.</param>
		/// <param name="denominator">Denominator of the rational number. Must not be zero.</param>
		/// <exception cref="ArgumentException"><paramref name="denominator"/> is zero.</exception>
		public Rational(long numerator, long denominator)
		{
			if (denominator == 0)
			{
				throw new ArgumentException("Must not be zero", nameof(denominator));
			}

			long gcd = Algorithms.Euclid(numerator, denominator);

			_numerator = numerator / gcd;
			_denominator = denominator / gcd;
		}

		public Rational Plus(Rational b)
		{
			return b; // TODO Implement
		}

		public Rational Minus(Rational b)
		{
			return b; // TODO Implement
		}

		public Rational Multiply(Rational b)
		{
			return b; // TODO Implement
		}

		public Rational Divide(Rational b)
		{
			return b; // TODO Implement
		}

		public bool Equal(object other)
		{
			return false; // TODO Implement
		}

		public override string ToString()
		{
			return base.ToString(); // TODO Implement
		}
	}
}
