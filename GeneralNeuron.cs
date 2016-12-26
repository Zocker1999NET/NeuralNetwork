using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Exceptions;

namespace NeuralNetwork {
	public abstract partial class GeneralNeuron {

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
