using System;

namespace AlgorithmExercises.Common
{
	public class Rational : IEquatable<Rational>
	{
		private long _numerator;
		private long _denominator;

		private enum Operation
		{
			Add,
			Subtract
		}

		/// <summary>
		/// Create an instance of a rational number with the given <paramref name="numerator"/> and <paramref name="denominator"/>.
		/// </summary>
		/// <param name="numerator">Numerator of the rational number.</param>
		/// <param name="denominator">Denominator of the rational number. Must not be zero.</param>
		/// <exception cref="ArgumentException"><paramref name="denominator"/> is zero.</exception>
		/// <remarks>The <paramref name="numerator"/> and <paramref name="denominator"/> will be reduced by their greatest
		/// common denominator.</remarks>
		public Rational(long numerator, long denominator)
		{
			if (denominator == 0)
			{
				throw new ArgumentException("Must not be zero", nameof(denominator));
			}

			int numeratorSign = numerator < 0 ? -1 : 1;
			int denominatorSign = denominator < 0 ? -1 : 1;

			long gcd = Math.Abs(Algorithms.GreatestCommonDenominator(numerator, denominator));
			_numerator = Math.Abs(numerator) / gcd;
			_denominator = Math.Abs(denominator) / gcd;

			_numerator *= numeratorSign * denominatorSign; // have the numerator carry the sign
		}

		/// <summary>
		/// Adds this rational number to <paramref name="other"/>.
		/// </summary>
		/// <param name="other">The other rational number to add.</param>
		/// <returns>The addition of the two rational numbers.</returns>
		/// <remarks>This rational number is unchanged. The rational number returned is a new object.</remarks>
		public Rational Plus(Rational other)
		{
			CheckAdditionOverflow(other);
			return AddOrSubtract(other, Operation.Add);
		}

		/// <summary>
		/// Subtracts <paramref name="other"/> from this rational number.
		/// </summary>
		/// <param name="other">The other rational number to subtract for this one.</param>
		/// <returns>The subtraction of <paramref name="other"/> from this rational number.</returns>
		/// <remarks>This rational number is unchanged. The rational number returned is a new object.</remarks>
		public Rational Minus(Rational other)
		{
			return AddOrSubtract(other, Operation.Subtract);
		}

		/// <summary>
		/// Multiplies this rational number by <paramref name="other"/>.
		/// </summary>
		/// <param name="other">Other number to multiply.</param>
		/// <returns>This rational number multiplied by <paramref name="other"/></returns>
		public Rational Multiply(Rational other)
		{
			CheckMultiplyOverflow(other);
			return new Rational(_numerator * other._numerator, _denominator * other._denominator);
		}

		/// <summary>
		/// Divides this rational number by <paramref name="other"/>.
		/// </summary>
		/// <param name="other">Other number to divide.</param>
		/// <returns>This rational number divided by <paramref name="other"/></returns>
		public Rational Divide(Rational other)
		{
			return new Rational(_numerator * other._denominator, _denominator * other._numerator);
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"{_numerator}/{_denominator}";
		}

		/// <inheritdoc/>
		public override bool Equals(object obj)
		{
			return Equals(obj as Rational);
		}

		/// <inheritdoc/>
		public bool Equals(Rational other)
		{
			return
				other is not null &&
				_numerator == other._numerator &&
				_denominator == other._denominator;
		}

		/// <inheritdoc/>
		public override int GetHashCode()
		{
			return HashCode.Combine(_numerator, _denominator);
		}

		private Rational AddOrSubtract(Rational other, Operation operation)
		{
			long lcm = Algorithms.LeastCommonMultiple(_denominator, other._denominator);
			long multiplier = lcm / _denominator;
			long otherMultiplier = lcm / other._denominator;

			return operation switch
			{
				Operation.Add => new Rational((_numerator * multiplier) + (other._numerator * otherMultiplier), lcm),
				Operation.Subtract => new Rational((_numerator * multiplier) - (other._numerator * otherMultiplier), lcm),
				_ => throw new InvalidOperationException($"Must be valid {nameof(Operation)}")
			};
		}

		private void CheckAdditionOverflow(Rational other)
		{
			long numerator = Math.Abs(_numerator);
			long otherNumerator = Math.Abs(other._numerator);
			if (numerator > long.MaxValue - otherNumerator)
			{
				throw new OverflowException("Adding numerators results in overflow");
			}
			long denominator = Math.Abs(_denominator);
			long otherDenominator = Math.Abs(other._denominator);
			if (denominator > long.MaxValue - otherDenominator)
			{
				throw new OverflowException("Adding denominators results in overflow");
			}
		}

		private void CheckMultiplyOverflow(Rational other)
		{
			long numerator = Math.Abs(_numerator);
			long otherNumerator = Math.Abs(other._numerator);
			if (numerator > long.MaxValue / otherNumerator)
			{
				throw new OverflowException("Multiplying numerators results in overflow");
			}
			long denominator = Math.Abs(_denominator);
			long otherDenominator = Math.Abs(other._denominator);
			if (denominator > long.MaxValue / otherDenominator)
			{
				throw new OverflowException("Multiplying denominators results in overflow");
			}
		}
	}
}
