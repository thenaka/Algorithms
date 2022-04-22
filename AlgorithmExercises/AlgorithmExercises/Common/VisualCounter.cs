using System;

namespace AlgorithmExercises.Common
{
	/// <summary>
	/// Counter that allows increment and decrement.
	/// </summary>
	public class VisualCounter
	{
		private int _maxOperations;
		private int _maxValue;
		private int _currentOperations;
		private int _currentValue;

		/// <summary>
		/// Counter that allows increment and decrement.
		/// </summary>
		/// <param name="maxOperations">Maximum number of operations allowed.</param>
		/// <param name="maxValue">Maximum value that the counter can be incremented.</param>
		/// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="maxOperations"/>
		/// or <paramref name="maxValue"/> is zero or less.</exception>
		public VisualCounter(int maxOperations, int maxValue)
		{
			if (maxOperations < 1) throw new ArgumentOutOfRangeException(nameof(maxOperations));
			if (maxValue < 1) throw new ArgumentOutOfRangeException(nameof(maxValue));

			_maxOperations = maxOperations;
			_maxValue = maxValue;
		}

		/// <summary>
		/// Increments the current value by one unless the current value is already at the max value
		/// or the current number of operations is equal to the max number of operations.
		/// </summary>
		/// <returns>The current value.</returns>
		public int Increment()
		{
			if (_currentValue == _maxValue || _currentOperations == _maxOperations) return _currentValue;
			_currentOperations++;
			return ++_currentValue;
		}

		/// <summary>
		/// Decrements the current value by one unless the current operations is equal to the max number of operations.
		/// </summary>
		/// <returns>The current value.</returns>
		public int Decrement()
		{
			if (_currentOperations == _maxOperations) return _currentValue;
			_currentOperations++;
			return --_currentValue;
		}
	}
}
