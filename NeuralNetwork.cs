using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork {
	/// <summary>
	/// Represents a neural network with many neurons.
	/// </summary>
	public abstract class NeuralNetwork {

		private List<GeneralNeuron> neurons;

		private bool calcPaused = false;

		/// <summary>
		/// Gets if the neural network is paused so the neurons inside will not recalculate their outputs on input changes.
		/// </summary>
		public bool CalculationPaused {
			get {
				return calcPaused;
			}
			protected set {
				calcPaused = value;
			}
		}

		/// <summary>
		/// Registers a new neuron in its network. Neurons use this method to register themselves.
		/// </summary>
		/// <param name="neuron"></param>
		internal void registerNeuron(GeneralNeuron neuron) {
			if(!neuron.Network.IsNeuronRegistered(neuron)) {
				neuron.Network.registerNeuron(neuron);
				neuron.Network.neurons.Add(neuron);
			}
		}

		public bool IsNeuronRegistered(GeneralNeuron neuron) {
			return neurons.IndexOf(neuron) != -1;
		}

		internal void unregisterNeuron(GeneralNeuron neuron) {
			neurons.Remove(neuron);
		}

	}
}
