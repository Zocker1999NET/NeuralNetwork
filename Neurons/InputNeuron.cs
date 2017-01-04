using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Neurons {
	/// <summary>
	/// Represents a basic input neuron.
	/// </summary>
	public class InputNeuron : GeneralNeuron {

		protected double nextValue = 0f;

		/// <summary>
		/// Generates a new input neuron which is part of the given network.
		/// </summary>
		/// <param name="network">The network the new neuron is to be part of.</param>
		public InputNeuron(NeuralNetwork network) : base(network) { }

		/// <summary>
		/// Returns the current output the source would set without changing its own current output.
		/// </summary>
		/// <returns>The output the source would set.</returns>
		protected virtual double getCurrentOutputBySource() {
			return nextValue;
		}

		/// <summary>
		/// Tries to set the given value to the next value of this neuron.
		/// Some types of input neurons does not support this method.
		/// </summary>
		/// <param name="value">The next value of this neuron.</param>
		public void SetNextValue(double value) {
			nextValue = value;
			RefreshOutput();
		}

		/// <summary>
		/// Refreshes the given input of the source and stores it as the current output value.
		/// </summary>
		/// <returns>The new output value.</returns>
		protected sealed override double CalculateOutput() {
			if(Disabled)
				return 0;
			return getCurrentOutputBySource();
		}

		/// <summary>
		/// Event handler for changed output value, not needed for input neurons.
		/// </summary>
		/// <param name="val">The new output value.</param>
		protected sealed override void valueChanged(double val) {
		}
		
		/// <summary>
		/// Removes this neuron and all connections this neuron had.
		/// </summary>
		public sealed override void RemoveNeuron() {
			base.RemoveNeuron();
		}

	}
}
