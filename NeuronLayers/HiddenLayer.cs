using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Neurons;

namespace NeuralNetwork.NeuronLayers {
	internal class HiddenLayer : DependentLayer {

		public HiddenLayer(LayeredNetwork network, NeuronGeneratorDelegate<HiddenNeuron> genMethod, int neuronCount) : base(network, delegate (LayeredNetwork net) {
			return genMethod(net);
		}, neuronCount) { }

	}
}
