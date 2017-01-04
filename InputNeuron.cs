using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork {
	/// <summary>
	/// Represents a basic input neuron.
	/// </summary>
	public abstract class InputNeuron : GeneralNeuron {

		/// <summary>
		/// Generates a new input neuron which is part of the given network.
		/// </summary>
		/// <param name="network">The network the new neuron is to be part of.</param>
		public InputNeuron(NeuralNetwork network) : base(network) { }

		/// <summary>
		/// Returns the current output the source would set without changing its own current output.
		/// </summary>
		/// <returns>The output the source would set.</returns>
		public abstract float GetCurrentOutputBySource();

		/// <summary>
		/// Refreshes the given input of the source and stores it as the current output value.
		/// </summary>
		/// <returns>The new output value.</returns>
		protected sealed override double CalculateOutput() {
			if(Disabled)
			return GetCurrentOutputBySource();
				return 0;
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
