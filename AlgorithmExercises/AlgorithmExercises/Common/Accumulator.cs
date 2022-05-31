using System;

namespace AlgorithmExercises.Common
{
	/// <summary>
	/// Accumulates data values.
	/// </summary>
	/// <remarks>From Exercise 1.2.18</remarks>
	public class Accumulator
	{
		private double _mean;
		private double _stdDev;
		private int _valuesCount;

		public void AddDataValue(double newDataValue)
		{
			_valuesCount++;
			_stdDev += 1.0 * (_valuesCount - 1) / _valuesCount * (newDataValue - _mean) * (newDataValue - _mean);
			_mean += (newDataValue - _mean) / _valuesCount;
		}

		public double Mean => _mean;

		public double Var => _stdDev / (_valuesCount - 1);

		public double StdDev => Math.Sqrt(Var);
	}
}
