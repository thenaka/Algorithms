namespace AlgorithmExercises.Common.Collections
{
	/// <summary>
	/// Holds an <see cref="Item"/> and a reference to <see cref="Next"/>.
	/// </summary>
	public class Node<T>
	{
		public T Item;
		public Node<T> Next;
	}
}
