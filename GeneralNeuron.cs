using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Exceptions;

namespace NeuralNetwork {
	/// <summary>
	/// Represents a neuron which needs to be able to return its current value.
	/// All neurons inherit from this class.
	/// </summary>
	public abstract partial class GeneralNeuron {

		/// <summary>
		/// Checks if the given float value is out of range (range is defined by [-1;1]).
		/// </summary>
		/// <param name="value">The float value which is to be checked.</param>
		/// <returns>True if the float value is out of range.</returns>
		public static bool ValueOutOfRange(float value) {
			return ( -1 > value || value > 1 );
		}

		/// <summary>
		/// Throws a specific ValueOutOfRangeException if the given value is out of range.
		/// See <see cref="ValueOutOfRange(float)"/>.
		/// </summary>
		/// <param name="value">The float value which is to be checked.</param>
		/// <param name="type">Defines which kind of value the given one is for the text of the exception.</param>
		protected static void rangeEx(float value, KindOfFloatValue type = KindOfFloatValue.Unknown) {
			if(ValueOutOfRange(value))
				throw new ValueOutOfRangeException(type, value);
		}

		/// <summary>
		/// Lists all output connections.
		/// </summary>
		private List<Connection> outCon = new List<Connection>();
		/// <summary>
		/// Represents the current value the neuron returns as output.
		/// </summary>
		private float curVal;

		/// <summary>
		/// The <seealso cref="NeuralNetwork"/> this neuron is part of.
		/// </summary>
		protected NeuralNetwork net;

		/// <summary>
		/// Generates a new neuron which is part of the given network.
		/// </summary>
		/// <param name="network">The network the new neuron is to be part of.</param>
		public GeneralNeuron(NeuralNetwork network) {
			net = network;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>The new output</returns>
		public abstract float CalculateOutput();

		/// <summary>
		/// Gets (or sets) the current value of the neuron.
		/// Only inherited classes are allowed to change the current value.
		/// </summary>
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

		/// <summary>
		/// Returns all output connections this neuron is part of.
		/// </summary>
		/// <returns>All output connections as array.</returns>
		public Connection[] GetOutputConnections() {
			return outCon.ToArray();
		}

	}
}
