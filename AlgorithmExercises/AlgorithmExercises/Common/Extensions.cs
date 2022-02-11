using System;
using System.Collections.Generic;

namespace AlgorithmExercises.Common
{
	public static class Extensions
	{
		/// <summary>
		/// Inserts <paramref name="value"/> sorted into a ascended sorted <paramref name="list"/>.
		/// </summary>
		/// <typeparam name="T"><see cref="IComparable{T}"/> value</typeparam>
		/// <param name="list">Ascended sorted list to insert the value into.</param>
		/// <param name="value">Value to insert sorted into.</param>
		public static void SortedInsert<T>(this List<T> list, T value) where T : IComparable<T>
		{
			int index = list.GetIndex(value);
			list.Insert(index, value);
		}

		/// <summary>
		/// Get the index where <paramref name="value"/> would be inserted in an ascended sorted <paramref name="list"/>.
		/// </summary>
		/// <typeparam name="T"><see cref="IComparable{T}"/> value</typeparam>
		/// <param name="list">List to find the index.</param>
		/// <param name="value">Value to find the index.</param>
		/// <returns>Returns the index value would be inserted in an ascended sorted list.</returns>
		public static int GetIndex<T>(this List<T> list, T value) where T : IComparable<T>
		{
			int index = list.BinarySearch(value);
			return index < 0 ? ~index : index;
		}
	}
}
