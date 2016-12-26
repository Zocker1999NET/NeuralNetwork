using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork {
	public abstract partial class GeneralNeuron {
		public class Connection {

			GeneralNeuron output;
			DependentNeuron input;
			float weight = 0f;
			bool change = false;

			public Connection(GeneralNeuron outNeuron, DependentNeuron inNeuron, float weigth) {
				output = outNeuron;
				input = inNeuron;
				output.outCon.Add(this);
			}

			public float Weigth {
				get {
					return weight;
				}
				set {
					weight = value;
				}
			}

			internal void FlagChange() {
				change = true;
				input.CalculateOutput();
			}

			public float WeightedInput {
				get {
					change = false;
					return output.CurrentValue * weight;
				}
			}

			public bool Change {
				get {
					return change;
				}
			}

		}
	}
}
