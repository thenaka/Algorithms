using System.Collections;
using System.Collections.Generic;

namespace AlgorithmExercises.Common.Collections
{
	public class LinkedList<T> : IEnumerable<T>, IEnumerable
	{
		private Node<T> _first; // link to least recently added node
		private Node<T> _last;  // link to most recently added node
		private Node<T> _current; // for iterating the collection
		private int _currentSize;  // number of items on the queue

		/// <summary>
		/// Get if this linked list is empty.
		/// </summary>
		public bool IsEmpty => _first is null;
		/// <summary>
		/// The number of items in this linked list.
		/// </summary>
		public int Size => _currentSize;
		/// <summary>
		/// The first item in this linked list.
		/// </summary>
		public T FirstItem => _first.Item;
		/// <summary>
		/// The last item in this linked list.
		/// </summary>
		public T LastItem => _last.Item;

		/// <summary>
		/// Adds an item to the end of the list.
		/// </summary>
		/// <param name="item">Item to add to the list.</param>
		public void Add(T item)
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

		/// <summary>
		/// Removes the last node from the list.
		/// </summary>
		public void Remove()
		{
			Remove(_currentSize);
		}

		/// <summary>
		/// Removes the node at the <paramref name="deleteIndex"/>.
		/// </summary>
		/// <param name="deleteIndex">One-based index to delete.</param>
		public void Remove(int deleteIndex)
		{
			if (deleteIndex < 1 || deleteIndex > _currentSize) throw new System.ArgumentException("Must be one or greater and no greater than the current size", nameof(deleteIndex));

			if (deleteIndex == 1)
			{ // handle special case where the first node is being deleted
				Node<T> oldFirst = _first;

				_first = _first.Next;

				oldFirst.Item = default;
				oldFirst.Next = null;

				_currentSize--;
				return;
			}

			Node<T> currentNode = _first;
			for (int i = 1; i <= _currentSize; i++)
			{
				if (i + 1 == deleteIndex) // the next node is being deleted
				{
					Node<T> deletedNode = currentNode.Next;

					// dereference the next node by skipping it
					currentNode.Next = currentNode.Next.Next;

					deletedNode.Item = default;
					deletedNode.Next = null;

					if (deleteIndex == _currentSize) // last node was deleted
					{
						_last = currentNode;
					}

					_currentSize--;
					break;
				}
				currentNode = currentNode.Next;
			}
		}

		/// <summary>
		/// Tries to find <paramref name="searchItem"/> in this linked list.
		/// </summary>
		/// <param name="searchItem">Item to find.</param>
		/// <returns>The index of the item if it is found, otherwise -1.</returns>
		public int Find(T searchItem)
		{
			int index = 1;
			foreach (T item in this)
			{
				if (item.Equals(searchItem)) return index;
				index++;
			}
			return -1;
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

