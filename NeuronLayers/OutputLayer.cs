using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Neurons;

namespace NeuralNetwork.NeuronLayers {
	internal class OutputLayer : DependentLayer {

		public OutputLayer(LayeredNetwork network, NeuronGeneratorDelegate<OutputNeuron> genMethod, int neuronCount) : base(network, delegate (LayeredNetwork net) {
			return genMethod(net);
		}, neuronCount) { }

	}
}
