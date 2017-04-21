using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Neurons {
	/// <summary>
	/// Represents an input neuron which converts its given value into the compatible range [-0.9;0.9].
	/// </summary>
	public class RangedInputNeuron : InputNeuron {

		double low = 0;
		double up = 0;

		/// <summary>
		/// Generates a new neuron which converts its value from the given range to the range [-0.9;0.9].
		/// Swapping the limits is possible, results in swapped (negative) output values.
		/// </summary>
		/// <param name="net">The network this neuron is to be part of.</param>
		/// <param name="lowerLimit">The lower limit of the given range.</param>
		/// <param name="upperLimit">The upper limit of the given range.</param>
		public RangedInputNeuron(NeuralNetwork net, double lowerLimit, double upperLimit) : base(net) {
			if(lowerLimit == upperLimit)
				throw new Exception("Both limits are the same!");
			low = lowerLimit;
			up = upperLimit;
		}

		/// <summary>
		/// Converts the given next value from the given range into a compatible range.
		/// </summary>
		/// <returns>The converted value in the compatible range [-0.9;0.9].</returns>
		protected override double GetCurrentOutputBySource() {
			if(low <= nextValue || nextValue <= up)
				throw new Exception("Next Value not inside the given range!");
			return ( ( ( nextValue - low ) / ( up - low ) ) * 1.8 ) - .9;
		}

	}
}
