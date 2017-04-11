using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Functions {
	/// <summary>
	/// Represents a LinearFunction for neurons.
	/// </summary>
	public class LinearFunction : GeneralFunction {

		/// <summary>
		/// Generates a linear function with the given parameter.
		/// </summary>
		/// <param name="slope"></param>
		public LinearFunction(double slope) {
			param = slope;
		}

		/// <summary>
		/// Returns the value of this linear function.
		/// </summary>
		/// <param name="x">The requested position.</param>
		/// <returns>The value of the function.</returns>
		public override double Function(double x) {
			return x * param;
		}

		/// <summary>
		/// Returns the differential of this linear function.
		/// </summary>
		/// <param name="x">The given input value.</param>
		/// <returns>The differential of the function.</returns>
		public override double Differential(double x) {
			return param;
		}

		/// <summary>
		/// Calculates the input value for the given output value.
		/// </summary>
		/// <param name="y">The given output value.</param>
		/// <returns>The requested input value.</returns>
		public override double Inverse(double y) {
			return y / param;
		}

		/// <summary>
		/// Sets the variable parameter to fullfil the given pair of values.
		/// </summary>
		/// <param name="x">The given input value.</param>
		/// <param name="y">The given output value.</param>
		/// <returns>Whether the parameter was adapted or not.</returns>
		public override bool SetParameterFor(double x, double y) {
			param = y / x;
			return true;
		}

	}
}
