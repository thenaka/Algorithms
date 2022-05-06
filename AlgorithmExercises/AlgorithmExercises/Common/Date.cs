﻿using System;
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
		/// <summary>
		/// Returns of the day of week for this date.
		/// </summary>
		/// <remarks>Will return the <see cref="Common.DayOfWeek"/> for a date that falls in the years 1700 - 2399.</remarks>
		DayOfWeek DayOfWeek { get; }
	}

	/// <inheritdoc/>
	public class Date : IDate, IComparable<Date>, IEquatable<Date>
	{
		/// <summary>
		/// Minimum year <see cref="DayOfWeek"/> can be calculated.
		/// </summary>
		private const int MIN_YEAR = 1700;
		/// <summary>
		/// Maximum year <see cref="DayOfWeek"/> can be calculated.
		/// </summary>
		private const int MAX_YEAR = 2399;

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

		/// <inheritdoc/>
		/// <exception cref="ArgumentException">Thrown if <see cref="Year"/> is less than 1700 or greater than 2399.</exception>
		public DayOfWeek DayOfWeek => CalculateDayOfWeek();

		/// <inheritdoc/>
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

		/// <inheritdoc/>
		public override bool Equals(object obj)
		{
			if (obj is not Date other) return false;
			return Equals(other);
		}

		/// <inheritdoc/>
		public bool Equals(Date other)
		{
			if (other is null) return false;
			return CompareTo(other) == 0;
		}

		/// <inheritdoc/>
		public static bool operator ==(Date left, Date right)
		{
			if (left is null)
			{
				if (right is null) return true;
				return false;
			}
			return left.Equals(right);
		}

		/// <inheritdoc/>
		public static bool operator !=(Date left, Date right)
		{
			if (left is null)
			{
				if (right is null) return false;
				return true;
			}
			return !left.Equals(right);
		}

		/// <inheritdoc/>
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
					bool isLeapYear = IsLeapYear();
					return isLeapYear ? day > 0 && day <= 29 : day > 0 && day <= 28;
				default:
					return false; // should never hit this case
			}
		}

		private bool IsLeapYear()
		{
			if (Year % 4 == 0)
			{
				if (Year % 100 == 0)
				{
					return Year % 400 == 0;
				}
				return true;
			}
			return false;
		}

		private DayOfWeek CalculateDayOfWeek()
		{
			if (Year < MIN_YEAR || Year > MAX_YEAR) throw new ArgumentException(nameof(Year));
			// Formula from https://artofmemory.com/blog/how-to-calculate-the-day-of-the-week/
			int lastTwoOfYear = Year % 100;
			int yearCode = (lastTwoOfYear + (lastTwoOfYear / 4)) % 7;
			int monthCode = GetMonthCode();
			int century = Year / 100;
			int centuryCode = GetCenturyCode(century);
			int leapYearCode = IsLeapYear() && (Month == 1 || Month == 2) ? -1 : 0;
			return (DayOfWeek)((yearCode + monthCode + centuryCode + Day + leapYearCode) % 7);
		}

		private int GetMonthCode()
		{
			return Month switch
			{
				// Jan or Oct
				(1) or (10) => 0,
				// Feb, Mar, or Nov
				(2) or (3) or (11) => 3,
				// Apr or Jul
				(4) or (7) => 6,
				// May
				(5) => 1,
				// Jun
				(6) => 4,
				// Aug
				(8) => 2,
				// Sep or Dec
				(9) or (12) => 5,
				_ => -1 // should not hit this case
			};
		}

		private static int GetCenturyCode(int century)
		{
			return century switch
			{
				(17) or (21) => 4,
				(18) or (22) => 2,
				(19) or (23) => 0,
				(20) => 6,
				_ => -1 // should not hit this case
			};
		}
	}
}
