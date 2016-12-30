using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Functions;

namespace NeuralNetwork {
	public class HiddenNeuron : DependentNeuron {

		public HiddenNeuron(NeuralNetwork network, GeneralFunction activationFunction) : base(network, activationFunction) { }

		protected override sealed void valueChanged(float val) { }

	}
}