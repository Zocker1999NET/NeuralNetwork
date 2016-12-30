using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Functions;

namespace NeuralNetwork {
	public class DelegateOutputNeuron : OutputNeuron {

		public delegate void OutputDelegate(float value);

		private OutputDelegate outputMeth;

		public DelegateOutputNeuron(NeuralNetwork network, GeneralFunction function) : base(network, function) { }

		public DelegateOutputNeuron(NeuralNetwork network, GeneralFunction function, OutputDelegate outputMethod) : base(network, function) {
			outputMeth = outputMethod;
		}

		public OutputDelegate OutputMethod {
			get {
				return outputMeth;
			}
			set {
				outputMeth = value;
			}
		}

		protected override void valueChanged(float val) {
			outputMeth(val);
		}

	}
}