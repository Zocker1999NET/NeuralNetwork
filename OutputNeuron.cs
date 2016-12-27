using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Functions;

namespace NeuralNetwork {
	public abstract class OutputNeuron : DependentNeuron {

		public OutputNeuron(NeuralNetwork network, GeneralFunction activationFunction) : base(network, activationFunction) { }

	}
}