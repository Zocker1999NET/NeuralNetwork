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
				rangeEx(weigth, KindOfFloatValue.Weigth);
				output = outNeuron;
				input = inNeuron;
				output.outCon.Add(this);
			}

			public float Weigth {
				get {
					return weight;
				}
				set {
					rangeEx(value, KindOfFloatValue.Weigth);
					weight = value;
				}
			}

		}

		protected float lastVal;
		protected float curVal;

		public static bool ValueOutOfRange(float value) {
			return ( -1 > value || value > 1 );
		}

		protected static void rangeEx(float value, KindOfFloatValue type = KindOfFloatValue.Unknown) {
			if(ValueOutOfRange(value))
				throw new ValueOutOfRangeException(value);
		}

		public abstract float CalculateOutput();

		public virtual float GetLastOutput() {
			return lastVal;
		}

		public virtual float GetCurrentOutput() {
			return curVal;
		}

		public Connection[] GetOutputConnections() {
			return outCon.ToArray();
		}

	}
}
