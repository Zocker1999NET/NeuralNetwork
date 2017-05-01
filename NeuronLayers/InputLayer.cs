using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Neurons;

namespace NeuralNetwork.NeuronLayers {
	internal class InputLayer : GeneralLayer {

		public InputLayer(LayeredNetwork network, NeuronGeneratorDelegate<InputNeuron> genMethod, int neuronCount) : base(network, delegate (LayeredNetwork net) {
			return genMethod(net);
		}, neuronCount) { }

		public sealed override bool AddNeurons(int addCount) => base.AddNeurons(addCount);

		public sealed override void RemoveLayer() => base.RemoveLayer();

	}
}
