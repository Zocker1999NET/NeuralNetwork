using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Functions {
	/// <summary>
	/// Represents a BooleanFunction (only returning -1 or 1) for neurons.
	/// </summary>
	public class BooleanFunction : GeneralFunction {

		/// <summary>
		/// Generates a boolean function with the default parameter.
		/// </summary>
		public BooleanFunction() : base(0) { }

		/// <summary>
		/// Generates a boolean function with the given parameter.
		/// </summary>
		/// <param name="threshold">The threshold which decides if the output is negative or positive.</param>
		public BooleanFunction(double threshold) : base(threshold) { }

		/// <summary>
		/// Returns the value of this boolean function.
		/// </summary>
		/// <param name="x">The requested position.</param>
		/// <returns>The value of the function.</returns>
		public override double Function(double x) {
			return x < param ? -1d : 1d;
		}

		/// <summary>
		/// Returns the differential of this boolean function.
		/// </summary>
		/// <param name="x">The given input value.</param>
		/// <returns>The differential of the function.</returns>
		public override double Differential(double x) {
			return 0d;
		}

		/// <summary>
		/// Calculates the input value for the given output value.
		/// </summary>
		/// <param name="y">The given output value.</param>
		/// <returns>The requested input value.</returns>
		public override double Inverse(double y) {
			return param + y;
		}

		/// <summary>
		/// Sets the variable parameter to fullfil the given pair of values.
		/// </summary>
		/// <param name="x">The given input value.</param>
		/// <param name="y">The given output value.</param>
		/// <returns>Whether the parameter was adapted or not.</returns>
		public override bool SetParameterFor(double x, double y) {
			if(this[x] != (y <= 0d ? -1d : 1d))
				param = x + (0.5d * (x - param));
			return true;
		}

	}
}
