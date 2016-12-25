using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Exceptions;

namespace NeuralNetwork {
	public abstract class GeneralNeuron {

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

			public void FlagChange() {
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

		public static bool ValueOutOfRange(float value) {
			return ( -1 > value || value > 1 );
		}

		protected static void rangeEx(float value, KindOfFloatValue type = KindOfFloatValue.Unknown) {
			if(ValueOutOfRange(value))
				throw new ValueOutOfRangeException(type, value);
		}

		private List<Connection> outCon = new List<Connection>();
		private float curVal;

		protected NeuralNetwork net;

		public GeneralNeuron(NeuralNetwork network) {
			net = network;
		}


		public abstract float CalculateOutput();

		public float CurrentValue {
			get {
				CalculateOutput();
				return curVal;
			}
			protected set {
				rangeEx(value);
				curVal = value;
				foreach(Connection con in outCon)
					con.FlagChange();
			}
		}

		public Connection[] GetOutputConnections() {
			return outCon.ToArray();
		}

	}
}
