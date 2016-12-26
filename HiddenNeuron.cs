using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Functions;

namespace NeuralNetwork {
	public class HiddenNeuron : DependentNeuron {

		GeneralFunction actFunc;

		public HiddenNeuron(NeuralNetwork network, GeneralFunction activationFunction) : base(network) {
			actFunc = activationFunction;
		}

		public GeneralFunction ActivationFunction {
			get {
				return actFunc;
			}
		}

		protected override float ActivationFunctionMethod(float value) {
			return actFunc[value];
		}

	}
}