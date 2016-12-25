using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Exceptions;

namespace NeuralNetwork {
	public abstract class GeneralNeuron {

		private List<Connection> outCon = new List<Connection>();

		public class Connection {

			GeneralNeuron output;
			DependentNeuron input;
			float weight = 0f;

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

			public float RawOutput {
				get {
					return output.CurrentValue;
				}
			}

			public float WeightedInput {
				get {
					return RawOutput * weight;
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
		
		private float curVal;

		protected void changeValue(float newVal) {
			curVal = newVal;

		}

		public abstract float CalculateOutput();

		public float CurrentValue {
			get {
				CalculateOutput();
				return curVal;
			}
		}

		public Connection[] GetOutputConnections() {
			return outCon.ToArray();
		}

	}
}
