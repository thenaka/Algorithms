using System;
using System.Diagnostics;

namespace AlgorithmExercises.Common
{
	/// <summary>
	/// Represents a date with month, day, and year.
	/// </summary>
	public interface IDate
	{
		/// <summary>
		/// Month of the date.
		/// </summary>
		/// <remarks>Valid values 1-12.</remarks>
		int Month { get; }
		/// <summary>
		/// Day of the date.
		/// </summary>
		/// <remarks>Must be valid for the given month and takes into account if it is a leap year.</remarks>
		int Day { get; }
		/// <summary>
		/// Year of the date.
		/// </summary>
		int Year { get; }
	}

	/// <inheritdoc/>
	public class Date : IDate, IComparable<Date>, IEquatable<Date>
	{
		/// <summary>
		/// Create a date with the given month, day, and year.
		/// </summary>
		/// <param name="month">The numberical month.</param>
		/// <param name="day">The day of the month.</param>
		/// <param name="year">The year.</param>
		/// <exception cref="ArgumentException">Thrown when month or day are outside a valid range.</exception>
		public Date(int month, int day, int year)
		{
			if (month < 1 || month > 12) throw new ArgumentException($"Must be 1 to 12", nameof(month));
			Month = month;
			Year = year;
			if (!IsValidDay(day)) throw new ArgumentException($"Must be a valid day for the month", nameof(day));
			Day = day;
		}

		/// <inheritdoc/>
		public int Month { get; init; }

		/// <inheritdoc/>
		public int Day { get; init; }

		/// <inheritdoc/>
		public int Year { get; init; }

		/// <summary>
		/// Compares this date against <paramref name="other"/>.
		/// </summary>
		/// <param name="other">The other date to compare.</param>
		/// <returns>-1 if this date precedes <paramref name="other"/>, 1 if this date follows <paramref name="other"/>, 0 if they are equal.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="other"/> is null.</exception>
		public int CompareTo(Date other)
		{
			if (other is null) throw new ArgumentNullException(nameof(other));

			if (other.Year > this.Year) return 1;
			if (other.Year < this.Year) return -1;

			if (other.Month > this.Month) return 1;
			if (other.Month < this.Month) return -1;

			if (other.Day > this.Day) return 1;
			if (other.Day < this.Day) return -1;

			return 0;
		}

		/// <summary>
		/// Determines if this is equal to <paramref name="obj"/>.
		/// </summary>
		/// <param name="obj">Object to determine equality.</param>
		/// <returns>True if they are equal, otherwise false.</returns>
		public override bool Equals(object obj)
		{
			if (obj is not Date other) return false;
			return Equals(other);
		}

		/// <summary>
		/// Determines if this is equal to <paramref name="other"/>.
		/// </summary>
		/// <param name="other">Date to determine equality.</param>
		/// <returns>True if they are equal, otherwise false.</returns>
		public bool Equals(Date other)
		{
			if (other is null) return false;
			return CompareTo(other) == 0;
		}

		/// <summary>
		/// Determine if two <see cref="Date"/> are equal.
		/// </summary>
		/// <param name="left">First date to determine equality.</param>
		/// <param name="right">Second date to determine equality.</param>
		/// <returns>True if they are equal, otherwise false.</returns>
		public static bool operator ==(Date left, Date right)
		{
			if (left is null)
			{
				if (right is null) return true;
				return false;
			}
			return left.Equals(right);
		}

		/// <summary>
		/// Determine if two <see cref="Date"/> are not equal.
		/// </summary>
		/// <param name="left">First date to determine inequality.</param>
		/// <param name="right">Second date to determine inequality.</param>
		/// <returns>True if they are unequal, otherwise false.</returns>
		public static bool operator !=(Date left, Date right)
		{
			if (left is null)
			{
				if (right is null) return false;
				return true;
			}
			return !left.Equals(right);
		}

		/// <summary>
		/// Get the <see cref="HashCode"/> for this <see cref="Date"/>
		/// </summary>
		/// <returns>The <see cref="HashCode"/> for this <see cref="Date"/>.</returns>
		public override int GetHashCode()
		{
			return HashCode.Combine(Month, Day, Year);
		}

		/// <summary>
		/// String representation of this date.
		/// </summary>
		/// <returns>Date as mm/dd/yyyy.</returns>
		public override string ToString()
		{
			return $"{Month}/{Day}/{Year}";
		}

		private bool IsValidDay(int day)
		{
			Debug.Assert(Month != 0, "Month must be set before calling this method");
			switch (Month)
			{
				case 1: // Jan
				case 3: // Mar
				case 5: // May
				case 7: // July
				case 8: // Aug
				case 10: // Oct
				case 12: // Dec
					return day > 0 && day <= 31;
				case 4: // Apr
				case 6: // Jun
				case 9: // Sep
				case 11: // Nov
					return day > 0 && day <= 30;
				case 2: // Feb
					bool isLeapYear = false;
					if (Year % 4 == 0)
					{
						if (Year % 100 == 0)
						{
							isLeapYear = Year % 400 == 0;
						}
						isLeapYear = true;
					}

					return isLeapYear ? day > 0 && day <= 29 : day > 0 && day <= 28;
				default:
					return false; // should never hit this case
			}
		}
	}
}
