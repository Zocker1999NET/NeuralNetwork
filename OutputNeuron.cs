using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork {
	public abstract class OutputNeuron : HiddenNeuron {

		public OutputNeuron(NeuralNetwork network) : base(network) { }

	}
}