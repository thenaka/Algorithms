namespace AlgorithmExercises.Common.Collections
{
	/// <summary>
	/// Fixed capacity collection of strings.
	/// </summary>
	/// <remarks>From Chapter 1 Section 3.</remarks>
	public class FixedCapacityStackOfStrings
	{
		private string[] _items;
		private int _currentSize;

		public FixedCapacityStackOfStrings(int capacity)
		{
			_items = new string[capacity];
		}

		public bool IsFull => _currentSize == _items.Length;
		public bool IsEmpty => _currentSize == 0;
		public int Size => _currentSize;

		public void Push(string item)
		{
			_items[_currentSize++] = item;
		}

		public string Pop()
		{
			return _items[--_currentSize];
		}
	}
}
