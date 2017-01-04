using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Functions;

namespace NeuralNetwork {
	/// <summary>
	/// Represents a layered neural network with one hidden layer.
	/// </summary>
	public class OneLayerNetwork : LayeredNetwork {

		private List<InputNeuron> inputLayer;
		private List<HiddenNeuron> hiddenLayer;
		private List<OutputNeuron> outputLayer;

		/// <summary>
		/// Generates a neural network with one layer.
		/// </summary>
		/// <param name="inputCount"></param>
		/// <param name="hiddenCount"></param>
		/// <param name="outputCount"></param>
		/// <param name="boolOutput">If true, the output neurons will only return 0 or 1.</param>
		public OneLayerNetwork(int inputCount, int hiddenCount, int outputCount, bool boolOutput) {
			addCountToList(inputCount, generateInputNeuron, inputLayer);
			addCountToList(hiddenCount, generateHiddenNeuron, hiddenLayer);
			addCountToList(outputCount, generateOutputNeuron, outputLayer, boolOutput);
			addConnections(hiddenLayer.ToArray(), inputLayer.ToArray());
			addConnections(outputLayer.ToArray(), hiddenLayer.ToArray());
		}

		protected virtual InputNeuron generateInputNeuron() {
			return new InputNeuron(this);
		}

		protected virtual HiddenNeuron generateHiddenNeuron() {
			return new HiddenNeuron(this, new LogisticFunction(nextRandom(2)));
		}

		protected virtual OutputNeuron generateOutputNeuron(bool config) {
			return config ? new OutputNeuron(this, null) : new OutputNeuron(this, new LogisticFunction(nextRandom(2)));
		}

	}
}
