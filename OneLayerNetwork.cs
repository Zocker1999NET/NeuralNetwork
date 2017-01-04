using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork {
	/// <summary>
	/// Represents a layered neural network with one hidden layer.
	/// </summary>
	public class OneLayerNetwork : LayeredNetwork {

		private List<InputNeuron> inputLayer;
		private List<HiddenNeuron> hiddenLayer;
		private List<OutputNeuron> outputLayer;

		public OneLayerNetwork(int inputCount, int hiddenCount, int outputCount) {

		}

		protected virtual InputNeuron generateInputNeuron() {
			return new InputNeuron(this);
		}

	}
}
