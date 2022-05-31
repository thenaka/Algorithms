using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExercises.Common.Collections
{
	public class FixedCapacityStackOfStrings
	{
		private string[] _items;
		private int _currentSize;
		
		public FixedCapacityStackOfStrings(int capacity)
		{
			_items = new string[capacity];
		}

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
