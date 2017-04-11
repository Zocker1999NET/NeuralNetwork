using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork.Exceptions;

namespace NeuralNetwork.Neurons {
	/// <summary>
	/// Represents a neuron which needs to be able to return its current value.
	/// All neurons inherit from this class.
	/// </summary>
	public abstract partial class GeneralNeuron {

		/// <summary>
		/// Checks if the given double value is out of range (range is defined by [-1;1]).
		/// </summary>
		/// <param name="value">The double value which is to be checked.</param>
		/// <returns>True if the double value is out of range.</returns>
		public static bool ValueOutOfRange(double value) {
			return (-1 > value || value > 1);
		}

		/// <summary>
		/// Throws a specific ValueOutOfRangeException if the given value is out of range.
		/// See <see cref="ValueOutOfRange(double)"/>.
		/// </summary>
		/// <param name="value">The double value which is to be checked.</param>
		/// <param name="type">Defines which kind of value the given one is for the text of the exception.</param>
		protected static void RangeEx(double value, KindOfFloatValue type = KindOfFloatValue.Unknown) {
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
		private double curVal;

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
			NeuralNetwork.RegisterNeuron(this);
		}

		/// <summary>
		/// Gets the network this neuron is part of.
		/// </summary>
		public NeuralNetwork Network {
			get {
				return net;
			}
		}

		/// <summary>
		/// Indicates if this neuron is disabled.
		/// </summary>
		public bool Disabled {
			get {
				return net == null;
			}
		}

		/// <summary>
		/// Event handler for changing output values.
		/// </summary>
		/// <param name="val">The new output value.</param>
		protected abstract void ValueChanged(double val);

		/// <summary>
		/// Calculates a new output value based on may changed input values or any other source.
		/// </summary>
		/// <returns>The new output</returns>
		protected abstract double CalculateOutput();

		/// <summary>
		/// Refreshes the output.
		/// If the value has changed, it fires specific events to the connections and to itself.
		/// </summary>
		public void RefreshOutput() {
			if(Disabled)
				return;
			double newVal = CalculateOutput();
			RangeEx(newVal);
			if(curVal != newVal) {
				curVal = newVal;
				valueChanged(newVal);
				foreach(Connection con in outCon)
					con.FlagChange();
			}
		}

		/// <summary>
		/// Gets the current value of the neuron.
		/// </summary>
		public double CurrentValue {
			get {
				if(Disabled)
					return 0f;
				RefreshOutput();
				return curVal;
			}
		}

		/// <summary>
		/// Returns all output connections this neuron is part of.
		/// </summary>
		/// <returns>All output connections as array.</returns>
		public Connection[] GetOutputConnections() {
			return outCon.ToArray();
		}

		/// <summary>
		/// Removes this neuron and all connections this neuron has.
		/// </summary>
		public virtual void RemoveNeuron() {
			if(Disabled)
				return;
			NeuralNetwork.UnregisterNeuron(this);
			foreach(Connection c in outCon)
				c.RemoveConnection();
		}

	}
}
