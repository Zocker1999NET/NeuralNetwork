using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Functions;

namespace NeuralNetwork {
	/// <summary>
	/// An output neuron which is able to send its output to a given delegate when the output changes.
	/// </summary>
	public class DelegateOutputNeuron : OutputNeuron {

		/// <summary>
		/// Represents a method which can work as a delegate for an output neuron.
		/// </summary>
		/// <param name="value">The value the output neuron has after a change.</param>
		public delegate void OutputDelegate(float value);

		/// <summary>
		/// The method this neuron will use when its output changes.
		/// </summary>
		private OutputDelegate outputMeth;

		/// <summary>
		/// Generates a new DelegateOutputNeuron with the specified activation function which is part of the given network.
		/// </summary>
		/// <param name="network">The network the new neuron is to be part of.</param>
		/// <param name="function">The activation function the new neuron should use.</param>
		public DelegateOutputNeuron(NeuralNetwork network, GeneralFunction function) : base(network, function) { }

		/// <summary>
		/// Generates a new DelegateOutputNeuron with the specified activation function using the given output method which is part of the given network.
		/// </summary>
		/// <param name="network">The network the new neuron is to be part of.</param>
		/// <param name="function">The activation function the new neuron should use.</param>
		/// <param name="outputMethod">The output method the new neuron will use.</param>
		public DelegateOutputNeuron(NeuralNetwork network, GeneralFunction function, OutputDelegate outputMethod) : base(network, function) {
			outputMeth = outputMethod;
		}

		/// <summary>
		/// Gets or sets the method this neuron uses when its output changes.
		/// </summary>
		public OutputDelegate OutputMethod {
			get {
				return outputMeth;
			}
			set {
				outputMeth = value;
			}
		}

		/// <summary>
		/// Will execute the given output method when the own output value changes.
		/// </summary>
		/// <param name="val">The new output value of the neuron.</param>
		protected sealed override void valueChanged(float val) {
			outputMeth(val);
		}

	}
}