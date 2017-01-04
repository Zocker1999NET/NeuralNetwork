using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Functions;
using NeuralNetwork.Neurons;

namespace NeuralNetwork {
	/// <summary>
	/// Represents a layered neural network with one hidden layer.
	/// </summary>
	public class OneLayerNetwork : LayeredNetwork {

		private List<HiddenNeuron> hiddenLayer = new List<HiddenNeuron>();

		/// <summary>
		/// Initializes a new neural network with one layer.
		/// </summary>
		/// <param name="inputCount">The count of the input neurons</param>
		/// <param name="hiddenCount">The count of the hidden neurons</param>
		/// <param name="outputCount">The count of the output neurons</param>
		/// <param name="boolOutput">If true, the output neurons will only return 0 or 1. See <see cref="generateOutputNeuron(bool)"/></param>
		public OneLayerNetwork(int inputCount, int hiddenCount, int outputCount, bool boolOutput) : base(inputCount, outputCount, false, boolOutput) {
			addCountToList(hiddenCount, generateHiddenNeuron, hiddenLayer);
			addConnections(hiddenLayer.ToArray(), inputLayer.ToArray());
			addConnections(outputLayer.ToArray(), hiddenLayer.ToArray());
		}

		/// <summary>
		/// Generates a new input neuron this kind of network should use.
		/// </summary>
		/// <param name="config">Optional configuration parameter, changes nothing in this case.</param>
		/// <returns>The new created neuron.</returns>
		protected override InputNeuron generateInputNeuron(bool config) {
			return new InputNeuron(this);
		}

		/// <summary>
		/// Generates a new hidden neuron this kind of network should use.
		/// </summary>
		/// <param name="config">Optional configuration parameter, changes nothing in this case.</param>
		/// <returns>The new created neuron.</returns>
		protected virtual HiddenNeuron generateHiddenNeuron(bool config) {
			return new HiddenNeuron(this, new LogisticFunction(nextRandom(2)));
		}

		/// <summary>
		/// Generates a new output neuron this kind of network should use.
		/// </summary>
		/// <param name="config">Optional configuration parameter, see boolOutput of <see cref="OneLayerNetwork(int, int, int, bool)"/> for this case.</param>
		/// <returns>The new created neuron.</returns>
		protected override OutputNeuron generateOutputNeuron(bool config) {
			return config ? new OutputNeuron(this, null) : new OutputNeuron(this, new LogisticFunction(nextRandom(2)));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override sealed int[] GetNeuronsCounts() {
			return new int[] { inputLayer.Count(), hiddenLayer.Count(), outputLayer.Count() };
		}

	}
}
