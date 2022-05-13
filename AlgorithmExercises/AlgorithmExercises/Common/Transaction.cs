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
	public class Transaction : ITransaction
	{
		private const string TRANSACTION_PATTERN = @"^\w+ \w+ ([1-9]|1[0-2])?/([1-9]|[1-3]\d?)/\d{4} -?\d+(\.\d{1,2})?$";
		private Regex _transactionRegex = new(TRANSACTION_PATTERN);

		/// <inheritdoc/>
		public string Customer { get; init; }
		/// <inheritdoc/>
		public Date Date { get; init; }
		/// <inheritdoc/>
		public double Amount { get; init; }

		/// <summary>
		/// Create an instance of a transaction.
		/// </summary>
		/// <param name="customer">The name of the customer.</param>
		/// <param name="date">The date the transaction occurred.</param>
		/// <param name="amount">The amount of the transaction.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="customer"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown if <paramref name="customer"/> is an empty string.</exception>
		public Transaction(string customer, Date date, double amount)
		{
			if (customer is null) throw new ArgumentNullException(nameof(customer));
			if (customer.Length == 0) throw new ArgumentException("Must provide customer name.", nameof(customer));
			if (date is null) throw new ArgumentNullException(nameof(date));

			Customer = customer;
			Date = date;
			Amount = amount;
		}

		/// <summary>
		/// Create an instance of a transaction.
		/// </summary>
		/// <param name="transaction">Transaction in format: First Last mm/dd/yyyy xx.xx</param>
		/// <exception cref="FormatException">Thrown if transaction is not in the correct format: First Last mm/dd/yyyy xx.xx</exception>
		public Transaction(string transaction)
		{
			if (!_transactionRegex.IsMatch(transaction)) throw new FormatException("Must provide transaction in format: First Last mm/dd/yyyy xx.xx");
		}

		// TODO ToString(), Equals(), CompareTo(), and GetHashCode()
	}
}
