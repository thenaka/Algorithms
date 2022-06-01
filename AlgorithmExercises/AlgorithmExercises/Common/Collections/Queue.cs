using System.Collections;
using System.Collections.Generic;

namespace AlgorithmExercises.Common.Collections
{
	/// <summary>
	/// Queue (FIFO) collection of <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Queue<T> : IEnumerable<T>, IEnumerable
	{
		private Node<T> _first; // link to least recently added node
		private Node<T> _last;  // link to most recently added node
		private Node<T> _current; // for iterating the collection
		private int _currentSize;  // number of items on the queue

		public bool IsEmpty => _first is null;
		public int Size => _currentSize;

		public void Enqueue(T item)
		{  // Add item to the end of the list.
			Node<T> oldlast = _last;
			_last = new Node<T>
			{
				Item = item,
				Next = null
			};

			if (IsEmpty)
			{
				_first = _last;
			}
			else
			{
				oldlast.Next = _last;
			}
			_currentSize++;
		}

		public T Dequeue()
		{  // Remove item from the beginning of the list.
			T item = _first.Item;
			_first = _first.Next;
			_currentSize--;
			if (IsEmpty)
			{
				_last = null;
			}
			return item;
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
