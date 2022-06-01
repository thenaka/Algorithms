namespace AlgorithmExercises.Common.Collections
{
	/// <summary>
	/// Stack collection of <typeparamref name="T"/>.
	/// </summary>
	/// <remarks>From Chapter 1 Section 3.</remarks>
	public class Stack<T>
	{
		private Node _first;  // top of stack (most recently added node)
		private int _currentSize;  // number of items

		/// <summary>
		/// A node in the stack.
		/// </summary>
		private class Node
		{
			internal T item;
			internal Node next;
		}

		public bool IsEmpty => _first is null;
		public int Size => _currentSize;

		/// <summary>
		/// Add item to top of the stack.
		/// </summary>
		/// <param name="item">Item to add.</param>
		public void Push(T item)
		{
			Node oldfirst = _first;
			_first = new Node
			{
				item = item,
				next = oldfirst
			};
			_currentSize++;
		}

		/// <summary>
		/// Remove item from top of the stack.
		/// </summary>
		/// <returns>The removed item.</returns>
		public T Pop()
		{
			T item = _first.item;
			_first = _first.next;
			_currentSize--;
			return item;
		}
	}
}
