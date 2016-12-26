using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork {
	public abstract class InputNeuron : GeneralNeuron {

		public InputNeuron(NeuralNetwork network) : base(network) { }

		public abstract float UpdateOutput();

		public override float CalculateOutput() {
			return UpdateOutput();
		}

	}
}
