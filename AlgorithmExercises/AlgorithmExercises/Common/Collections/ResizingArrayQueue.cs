using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmExercises.Common.Collections
{
	/// <summary>
	/// Queue (FIFO) collection of <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">Type of items in the queue.</typeparam>
	/// <remarks>Implementation taken from .NET Source Reference (https://source.dot.net/#System.Collections.NonGeneric/System/Collections/Queue.cs,f7cdfd0f848ca249).</remarks>
	public class ResizingArrayQueue<T> : IEnumerable, IEnumerable<T>
	{
		private object[] _array = new object[32];
		private int _size = 0;
		private int _head = 0; // First valid element in the queue
		private int _tail = 0; // Last valid element in the queue
		private const int _growFactor = 200;
		private const int MinimumGrow = 4;

		public bool IsEmpty => _size == 0;
		public int ArraySize => _array.Length;
		public int Size => _size;

		public virtual void Enqueue(object obj)
		{
			if (_size == _array.Length)
			{
				int newcapacity = (int)((long)_array.Length * (long)_growFactor / 100);
				if (newcapacity < _array.Length + MinimumGrow)
				{
					newcapacity = _array.Length + MinimumGrow;
				}
				SetCapacity(newcapacity);
			}

			_array[_tail] = obj;
			_tail = (_tail + 1) % _array.Length;
			_size++;
		}

		public virtual object? Dequeue()
		{
			if (_size == 0)
				throw new InvalidOperationException("Queue empty");

			object? removed = _array[_head];
			_array[_head] = null;
			_head = (_head + 1) % _array.Length;
			_size--;
			return removed;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			for(int i = _head; i <= _tail; i++)
			{
				yield return (T)_array[i];
			}
		}

		private void SetCapacity(int capacity)
		{
			object[] newArray = new object[capacity];
			if (_size > 0)
			{
				if (_head < _tail)
				{
					Array.Copy(_array, _head, newArray, 0, _size);
				}
				else
				{
					Array.Copy(_array, _head, newArray, 0, _array.Length - _head);
					Array.Copy(_array, 0, newArray, _array.Length - _head, _tail);
				}
			}

			_array = newArray;
			_head = 0;
			_tail = (_size == capacity) ? 0 : _size;
		}
	}
}
