using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Functions;

namespace NeuralNetwork.Neurons {
	/// <summary>
	/// Represents a basic output neuron
	/// </summary>
	public class OutputNeuron : DependentNeuron {

		/// <summary>
		/// Generates a basic output neuron with the specified activation function which is part of the given network.
		/// </summary>
		/// <param name="network">The network the new neuron is to be part of.</param>
		/// <param name="activationFunction">The activation function the new neuron should use to calculate its output.</param>
		public OutputNeuron(NeuralNetwork network, GeneralFunction activationFunction) : base(network, activationFunction) { }

		/// <summary>
		/// Event handler for changing output values.
		/// </summary>
		/// <param name="val">The new output value.</param>
		protected override void ValueChanged(double val) { }

		/// <summary>
		/// Gets the current value of the neuron as boolean.
		/// Values below 0.5 are represented as false, higher values as true.
		/// </summary>
		public bool BooleanValue => CurrentValue >= 0.5f;

	}
}