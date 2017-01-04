using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork.Neurons {
	/// <summary>
	/// An input neuron which is able to receive its output from a given delegate.
	/// </summary>
	public class DelegateInputNeuron : InputNeuron {

		/// <summary>
		/// Represents a method which can work as a delegate for an input neuron.
		/// </summary>
		/// <returns>The value the source of the input neuron would set to the output of the input neuron.</returns>
		public delegate double InputDelegate();

		/// <summary>
		/// The method this neuron will use to get its output.
		/// </summary>
		private InputDelegate inputMeth;

		/// <summary>
		/// Generates a new DelegateInputNeuron which is part of the given network.
		/// </summary>
		/// <param name="network">The network the new neuron is to be a part of.</param>
		public DelegateInputNeuron(NeuralNetwork network) : base(network) { }

		/// <summary>
		/// Generates a new DelegateInputNeuron which is part of the given network with the given delegate.
		/// </summary>
		/// <param name="network">The network the new neuron is to be a part of.</param>
		/// <param name="inputMethod">The delegate the new neuron is to use to get its output.</param>
		public DelegateInputNeuron(NeuralNetwork network, InputDelegate inputMethod) : base(network) {
			inputMeth = inputMethod;
		}

		/// <summary>
		/// Gets or sets the method this neuron uses to get its output.
		/// </summary>
		public InputDelegate InputMethod {
			get {
				return inputMeth;
			}
			set {
				inputMeth = value;
			}
		}

		/// <summary>
		/// Uses the given delegate to get its new output without changing its own current output.
		/// Returns 0 if a delegate is not given.
		/// </summary>
		/// <returns>The new value the delegate would set to the output.</returns>
		protected override double getCurrentOutputBySource() {
			if(inputMeth == null)
				return 0;
			return inputMeth();
		}

	}
}