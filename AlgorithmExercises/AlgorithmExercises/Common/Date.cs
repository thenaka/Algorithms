using System;
using System.Diagnostics;

namespace AlgorithmExercises.Common
{
	public interface IDate
	{
		int Month { get; }
		int Day { get; }
		int Year { get; }
	}

	// https://artofmemory.com/blog/how-to-calculate-the-day-of-the-week/

	/// <summary>
	/// Representation of a date.
	/// </summary>
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

		public int Month { get; init; }

		public int Day { get; init; }

		public int Year { get; init; }

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

		public override bool Equals(object obj)
		{
			if (obj is not Date other) return false;
			return Equals(other);
		}

		public bool Equals(Date other)
		{
			if (other is null) return false;
			return CompareTo(other) == 0;
		}

		public static bool operator ==(Date left, Date right)
		{
			if (left is null)
			{
				if (right is null) return true;
				return false;
			}
			return left.Equals(right);
		}

		public static bool operator !=(Date left, Date right)
		{
			if (left is null)
			{
				if (right is null) return false;
				return true;
			}
			return !left.Equals(right);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Month, Day, Year);
		}

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
