using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmExercises.Common.Collections
{
	public class ResizingArrayStack<T> : IEnumerable, IEnumerable<T>
	{
		private object[] _items = new object[1];  // stack items
		private int _currentSize = 0;  // number of items

		public bool IsEmpty => _currentSize == 0;
		public int ArraySize => _items.Length;
		public int Size => _currentSize;

		private void Resize(int max)
		{  // Move stack to a new array of size max.
			object[] temp = new object[max];
			for (int i = 0; i < _currentSize; i++)
			{
				temp[i] = _items[i];
			}
			_items = temp;
		}

		public void Push(T item)
		{  // Add item to top of stack.
			if (_currentSize == _items.Length)
			{
				Resize(2 * _items.Length);
			}
			_items[_currentSize++] = item;
		}

		public T Pop()
		{  // Remove item from top of stack.
			T item = (T)_items[--_currentSize];
			_items[_currentSize] = null;  // Avoid loitering (see text).
			if (_currentSize > 0 && _currentSize == _items.Length / 4)
			{
				Resize(_items.Length / 2);
			}
			return item;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new StackEnumerator(this);
		}

		/// <summary>
		/// Enumerator for <see cref="ResizingArrayStack{T}"/>.
		/// </summary>
		/// <remarks>Implementation taken from .NET source code browser for Stack (https://source.dot.net/#System.Collections.NonGeneric/System/Collections/Stack.cs,e8782a99ce9d55c5).</remarks>
		private sealed class StackEnumerator : IEnumerator<T>, ICloneable
		{
			private readonly ResizingArrayStack<T> _stack;
			private int _index;
			private T _currentElement;
			private bool _isDisposed;

			internal StackEnumerator(ResizingArrayStack<T> stack)
			{
				_stack = stack;
				_index = -2;
				_currentElement = default;
			}

			public object Clone() => MemberwiseClone();

			public bool MoveNext()
			{
				bool retval;
				if (_index == -2)
				{  // First call to enumerator.
					_index = _stack._currentSize - 1;
					retval = _index >= 0;
					if (retval)
					{
						_currentElement = (T)_stack._items[_index];
					}
					return retval;
				}
				if (_index == -1)
				{  // End of enumeration.
					return false;
				}

				retval = --_index >= 0;
				if (retval)
				{
					_currentElement = (T)_stack._items[_index];
				}
				else
				{
					_currentElement = default;
				}
				return retval;
			}

			object IEnumerator.Current => Current;
			
			public T Current
			{
				get
				{
					if (_index == -2) throw new InvalidOperationException();
					if (_index == -1) throw new InvalidOperationException();
					return _currentElement;
				}
			}

			public void Reset()
			{
				_index = -2;
				_currentElement = default;
			}

			private void Dispose(bool disposing)
			{
				if (!_isDisposed)
				{
					if (disposing)
					{
						(_currentElement as IDisposable)?.Dispose();
						_currentElement = default;
					}

					_isDisposed = true;
				}
			}

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}
		}
	}
}
