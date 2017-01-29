using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Neurons;

namespace NeuralNetwork {
	/// <summary>
	/// Represents a neural network with many neurons.
	/// </summary>
	public abstract class NeuralNetwork {

		/// <summary>
		/// Registers a new neuron in its network. Neurons use this method to register themselves.
		/// </summary>
		/// <param name="neuron">The neuron which is to be registered.</param>
		internal static void registerNeuron(GeneralNeuron neuron) {
			if(!neuron.Network.IsNeuronRegistered(neuron))
				neuron.Network.neurons.Add(neuron);
		}

		/// <summary>
		/// Unregisters the given neuron from its network.
		/// </summary>
		/// <param name="neuron">The neuron which is to be unregistered.</param>
		internal static void unregisterNeuron(GeneralNeuron neuron) {
			neuron.Network.neurons.Remove(neuron);
		}

		/// <summary>
		/// Stores all neurons the current network is working with.
		/// </summary>
		private List<GeneralNeuron> neurons;
		private Random random = new Random();
		private bool calcPaused = false;

		/// <summary>
		/// Generates a new random double which is greater or equal than 0 and smaller than the given maximum. Used to generate the weights at the beginning.
		/// </summary>
		/// <param name="max">The maximum of the random double.</param>
		/// <param name="neg">If true, the random double is greater than the negative of the given maximum and smaller then the given maximum.</param>
		/// <returns></returns>
		protected double nextRandom(double max = .5, bool neg = true) {
			double r = 0;
			while(r == 0)
				r = random.NextDouble();
			return max * ( neg ? ( 2 * r ) - 1 : r );
		}

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
		/// Checks if the given neuron is registered in this network.
		/// </summary>
		/// <param name="neuron"></param>
		/// <returns></returns>
		public bool IsNeuronRegistered(GeneralNeuron neuron) {
			return neurons.IndexOf(neuron) != -1;
		}

	}
}
