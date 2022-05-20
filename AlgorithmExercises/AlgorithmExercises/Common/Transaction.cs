using System;
using System.Text.RegularExpressions;

namespace AlgorithmExercises.Common
{
	/// <summary>
	/// Record of a customer, date, and amount
	/// </summary>
	public interface ITransaction
	{
		/// <summary>
		/// Name of the customer.
		/// </summary>
		string Customer { get; }
		/// <summary>
		/// Date this transaction occurred.
		/// </summary>
		Date Date { get; }
		/// <summary>
		/// Amount of this transaction.
		/// </summary>
		double Amount { get; }
	}

	/// <inheritdoc/>
	public class Transaction : ITransaction, IComparable<Transaction>, IEquatable<Transaction>
	{
		/// <summary>
		/// Required format for a customer.
		/// </summary>
		public const string REQUIRED_CUSTOMER_FORMAT = "First Last";
		/// <summary>
		/// Required format for a date.
		/// </summary>
		public const string REQUIRED_DATE_FORMAT = "mm/dd/yyyy";
		public const string REQUIRED_AMOUNT_FORMAT = "[-]xx.xx or [-]xx.x or [-]xx";
		/// <summary>
		/// Required format for a <see cref="Transaction"/>.
		/// </summary>
		public const string REQUIRED_FORMAT = $"{REQUIRED_CUSTOMER_FORMAT} {REQUIRED_DATE_FORMAT} {REQUIRED_AMOUNT_FORMAT}";

		private const string CUSTOMER_PATTERN = @"^\w+ \w+$";
		private Regex _customerRegex = new(CUSTOMER_PATTERN);
		private const string TRANSACTION_PATTERN = @"^\w+ \w+ ([1-9]|1[0-2])\/([1-9]|[1-3]\d)\/\d{4} -?\d+(\.\d{1,2})?$";
		private Regex _transactionRegex = new(TRANSACTION_PATTERN);

		/// <inheritdoc/>
		public string Customer { get; private set; }
		/// <inheritdoc/>
		public Date Date { get; private set; }
		/// <inheritdoc/>
		public double Amount { get; private set; }

		/// <summary>
		/// Create a transaction.
		/// </summary>
		/// <param name="customer">The name of the customer.</param>
		/// <param name="date">The date the transaction occurred.</param>
		/// <param name="amount">The amount of the transaction. Will be rounded to two decimal places.</param>
		/// <exception cref="ArgumentNullException"><paramref name="customer"/> is null.</exception>
		/// <exception cref="ArgumentException"><paramref name="customer"/> is an empty string.</exception>
		/// <exception cref="FormatException"><paramref name="customer"/> is not in format <see cref="REQUIRED_CUSTOMER_FORMAT"/></exception>
		public Transaction(string customer, Date date, double amount)
		{
			ValidateAndCreate(customer, date, amount);
		}

		/// <summary>
		/// Create a transaction.
		/// </summary>
		/// <param name="transaction">Transaction in format: First Last mm/dd/yyyy xx.xx</param>
		/// <exception cref="FormatException">Transaction is not in <see cref="REQUIRED_FORMAT"/></exception>
		/// <exception cref="ArgumentException">Thrown when month, day, or year are outside a valid range.</exception>
		public Transaction(string transaction)
		{
			if (!_transactionRegex.IsMatch(transaction)) throw new FormatException($"Must be in {REQUIRED_FORMAT}");

			var transactionSplit = transaction.Split(' ');
			string customer = $"{transactionSplit[0]} {transactionSplit[1]}";
			Date date = new(transactionSplit[2]);
			double amount = Convert.ToDouble(transactionSplit[3]);

			ValidateAndCreate(customer, date, amount);
		}

		private void ValidateAndCreate(string customer, Date date, double amount)
		{
			if (customer is null) throw new ArgumentNullException(nameof(customer));
			if (customer.Length == 0) throw new ArgumentException("Must provide customer name.", nameof(customer));
			if (!_customerRegex.IsMatch(customer)) throw new FormatException($"{customer} must be in {REQUIRED_CUSTOMER_FORMAT}");
			if (date is null) throw new ArgumentNullException(nameof(date));

			Customer = customer;
			Date = date;
			Amount = Math.Round(amount, 2);
		}

		/// <inheritdoc/>
		public int CompareTo(Transaction other)
		{
			if (other is null) throw new ArgumentNullException(nameof(other));

			int customerCompare = Customer.CompareTo(other.Customer);
			if (customerCompare != 0) return customerCompare;

			int dateCompare = Date.CompareTo(other.Date);
			if (dateCompare != 0) return dateCompare;

			int amountCompare = Amount.CompareTo(other.Amount);
			if (amountCompare != 0) return amountCompare;

			return 0;
		}

		/// <inheritdoc/>
		public override bool Equals(object obj)
		{
			if (obj is not Transaction other) return false;
			return Equals(other);
		}

		/// <inheritdoc/>
		public bool Equals(Transaction other)
		{
			if (other is null) return false;
			return CompareTo(other) == 0;
		}

		/// <inheritdoc/>
		public static bool operator ==(Transaction left, Transaction right)
		{
			if (left is null)
			{
				if (right is null) return true;
				return false;
			}
			return left.Equals(right);
		}

		/// <inheritdoc/>
		public static bool operator !=(Transaction left, Transaction right)
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
			return HashCode.Combine(Customer, Date, Amount);
		}

		/// <summary>
		/// String representation of this Transaction.
		/// </summary>
		/// <returns>String representation of this Transaction.</returns>
		public override string ToString()
		{
			return $"{Customer} {Date} {Amount}";
		}
	}
}
