﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		/// Checks if the given neuron is registered in this network.
		/// </summary>
		/// <param name="neuron"></param>
		/// <returns></returns>
		public bool IsNeuronRegistered(GeneralNeuron neuron) {
			return neurons.IndexOf(neuron) != -1;
		}

	}
}
