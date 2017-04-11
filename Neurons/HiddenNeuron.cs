using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Functions;

namespace NeuralNetwork.Neurons {
	/// <summary>
	/// Represents an hidden neuron.
	/// </summary>
	public sealed class HiddenNeuron : DependentNeuron {

		/// <summary>
		/// Generates a hidden neuron with the specified activation function which is part of the given network.
		/// </summary>
		/// <param name="network">The network the new neuron is to be part of.</param>
		/// <param name="activationFunction">The activation function the new neuron should use to calculate its output.</param>
		public HiddenNeuron(NeuralNetwork network, GeneralFunction activationFunction) : base(network, activationFunction) { }

		/// <summary>
		/// Event handler for changed output value, not needed for hidden neurons.
		/// </summary>
		/// <param name="val">The new output value.</param>
		protected override sealed void ValueChanged(double val) { }

	}
}