using System.Collections;
using System.Collections.Generic;

namespace AlgorithmExercises.Common.Collections
{
	/// <summary>
	/// Stack (LIFO) collection of <typeparamref name="T"/>.
	/// </summary>
	/// <remarks>From Chapter 1 Section 3.</remarks>
	public class Stack<T> :  IEnumerable<T>, IEnumerable
	{
		private Node<T> _first;    // top of stack (most recently added node)
		private Node<T> _current;  // used for iterating
		private int _currentSize;  // number of items

		public bool IsEmpty => _first is null;
		public int Size => _currentSize;

		/// <summary>
		/// Add item to top of the stack.
		/// </summary>
		/// <param name="item">Item to add.</param>
		public void Push(T item)
		{
			Node<T> oldfirst = _first;
			_first = new Node<T>
			{
				Item = item,
				Next = oldfirst
			};
			_currentSize++;
		}

		/// <summary>
		/// Remove item from top of the stack.
		/// </summary>
		/// <returns>The removed item.</returns>
		public T Pop()
		{
			T item = _first.Item;
			_first = _first.Next;
			_currentSize--;
			return item;
		}

		/// <summary>
		/// Returns the last item pushed onto the stack without removing it.
		/// </summary>
		/// <returns>The most recently pushed item.</returns>
		public T Peek()
		{
			return _first.Item;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			_current = _first;
			while (_current is not null)
			{
				yield return _current.Item;
				_current = _current.Next;
			}
		}
	}
}
