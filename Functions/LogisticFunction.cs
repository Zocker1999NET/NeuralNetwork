using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Functions {
	/// <summary>
	/// Represents a LogisticFunction for neurons.
	/// </summary>
	public class LogisticFunction : GeneralFunction {

		/// <summary>
		/// Generates a logistic function with the given parameter.
		/// </summary>
		/// <param name="propConst"></param>
		public LogisticFunction(double propConst) {
			param = propConst;
		}

		/// <summary>
		/// Returns the value of this logistic function.
		/// </summary>
		/// <param name="x">The requested position.</param>
		/// <returns>The value of the function.</returns>
		public override double Function(double x) {
			return (2 / (1 + (Math.Pow(Math.E, (-param) * x)))) - 1;
		}

		/// <summary>
		/// Returns the differential of this logistic function.
		/// </summary>
		/// <param name="x">The given input value.</param>
		/// <returns>The differential of the function.</returns>
		public override double Differential(double x) {
			return this[x] * (1 - this[x]);
		}

		/// <summary>
		/// Calculates the input value for the given output value.
		/// </summary>
		/// <param name="y">The given output value.</param>
		/// <returns>The requested input value.</returns>
		public override double Inverse(double y) {
			return -(Math.Log((2 / (y + 1)) - 1) / param);
		}

		/// <summary>
		/// Sets the variable parameter to fullfil the given pair of values.
		/// </summary>
		/// <param name="x">The given input value.</param>
		/// <param name="y">The given output value.</param>
		/// <returns>Whether the parameter was adapted or not.</returns>
		public override bool SetParameterFor(double x, double y) {
			param = -(Math.Log((2 / (y + 1)) - 1) / x);
			return true;
		}

	}
}
