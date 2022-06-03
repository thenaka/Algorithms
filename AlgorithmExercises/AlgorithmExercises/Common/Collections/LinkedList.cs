using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorithmExercises.Common.Collections
{
	public class LinkedList<T> : IEnumerable<T>, IEnumerable where T : IComparable<T>
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
		/// <exception cref="InvalidOperationException">No items in the linked list.</exception>
		public void Remove()
		{
			if (_currentSize == 0) throw new InvalidOperationException("No items in linked list");
			Remove(_currentSize);
		}

		/// <summary>
		/// Removes the node at the <paramref name="deleteIndex"/>.
		/// </summary>
		/// <param name="deleteIndex">One-based index to delete.</param>
		/// <exception cref="ArgumentException"><paramref name="deleteIndex"/> is less than one or greater than <see cref="Size"/>.</exception>
		/// <exception cref="InvalidOperationException">No items in the linked list.</exception>
		public void Remove(int deleteIndex)
		{
			if (_currentSize == 0) throw new InvalidOperationException("No items in linked list");
			if (deleteIndex < 1 || deleteIndex > _currentSize) throw new ArgumentException("Must be one or greater and no greater than the current size", nameof(deleteIndex));

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
					RemoveAfter(currentNode);
					break;
				}
				currentNode = currentNode.Next;
			}
		}

		/// <summary>
		/// Remove all nodes where <see cref="Node{T}.Item"/> is equal to <paramref name="key"/>.
		/// </summary>
		/// <param name="key">Remove all nodes with this given key.</param>
		public void RemoveKey(T key)
		{
			Stack<int> indicesToDelete = new(); // use stack so indices will be popped out largest to smallest
			Node<T> current = _first;
			for (int i = 1; i <= _currentSize; i++)
			{
				if (key.Equals(current.Item)) indicesToDelete.Push(i);
				current = current.Next;
			}

			while (!indicesToDelete.IsEmpty)
			{
				Remove(indicesToDelete.Pop());
			}
		}

		/// <summary>
		/// Finds the index of the first occurence of <paramref name="searchItem"/> in this linked list.
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

		/// <summary>
		/// Insert <paramref name="after"/> after <paramref name="before"/>.
		/// </summary>
		/// <param name="before">Node that is before after.</param>
		/// <param name="after">Node that is after before.</param>
		public void InsertAfter(Node<T> before, Node<T> after)
		{
			if (before is null) throw new ArgumentNullException(nameof(before));
			if (after is null) throw new ArgumentNullException(nameof(after));

			// Special case, before is the last node
			if (before.Next is null)
			{
				before.Next = after;
				_last = after;
				_currentSize++;
				return;
			}

			after.Next = before.Next;
			before.Next = after;
			_currentSize++;
		}

		/// <summary>
		/// Get the node at <paramref name="index"/>.
		/// </summary>
		/// <param name="index">One-based index to get the node at.</param>
		/// <returns>The node at the given index.</returns>
		/// <exception cref="ArgumentException"><paramref name="index"/> is less than one or greater than <see cref="Size"/>.</exception>
		public Node<T> GetNode(int index)
		{
			if (_currentSize == 0) throw new InvalidOperationException("Linked list is empty");
			if (index < 1 || index > _currentSize) throw new ArgumentException("Must be one or greater or less ore equal to Size", nameof(index));

			Node<T> current = _first;
			for (int i = 1; i <= _currentSize; i++)
			{
				if (i == index) return current;
				current = current.Next;
			}
			return current;
		}

		/// <summary>
		/// Removes the node after <paramref name="node"/> if it exists and points <paramref name="node"/> to the one after.
		/// </summary>
		/// <param name="node">Node to reference removing the next one.</param>
		/// <exception cref="ArgumentNullException"><paramref name="node"/> is null.</exception>
		private void RemoveAfter(Node<T> node)
		{
			if (node is null) throw new ArgumentNullException(nameof(node));

			Node<T> nodeToDelete = node.Next;
			if (nodeToDelete is not null)
			{
				// dereference the next node by skipping it
				node.Next = node.Next.Next;

				if (node.Next is null)
				{ // the last node was deleted
					_last = node;
				}

				_currentSize--;

				ResetNode(nodeToDelete);
			}
		}

		/// <summary>
		/// Set node to delete to default and unlink it from the linked list.
		/// </summary>
		/// <param name="node"></param>
		private static void ResetNode(Node<T> node)
		{
			Debug.Assert(node is not null, "Node must not be null");
			node.Item = default;
			node.Next = null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <inheritdoc/>
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

