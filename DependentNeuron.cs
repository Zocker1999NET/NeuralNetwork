using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Exceptions;

namespace NeuralNetwork {
	/// <summary>
	/// Represents a neuron which is to be also able to have input connections from other neurons.
	/// By default, hidden and output neurons inherit from this class.
	/// </summary>
	public abstract class DependentNeuron : GeneralNeuron {

		/// <summary>
		/// Lists all input connections
		/// </summary>
		protected List<Connection> inCon;

		/// <summary>
		/// Generates a new dependent neuron which is part of the given network.
		/// </summary>
		/// <param name="network"></param>
		public DependentNeuron(NeuralNetwork network) : base(network) { }

		/// <summary>
		/// Adds a new connection this neuron has to the given output neuron with the given weigth.
		/// </summary>
		/// <param name="source">The output neuron of the new connection.</param>
		/// <param name="weigth">The weigth of the new connection.</param>
		public void AddInputConnection(GeneralNeuron source, float weigth) {
			inCon.Add(new Connection(source, this, weigth));
		}

		/// <summary>
		/// Returns all input connections this neuron is part of.
		/// </summary>
		/// <returns>All input connections as array.</returns>
		public Connection[] getInputConnections() {
			return inCon.ToArray();
		}

		/// <summary>
		/// Returns the sum of all inputs this neuron are given.
		/// </summary>
		/// <returns>The sum of all inputs</returns>
		protected float sumUpInputs() {
			float sum = 0f;
			foreach(Connection con in inCon)
				sum += con.WeightedInput;
			return sum;
		}

		/// <summary>
		/// Represents the activation function as method this specific neuron wants to use to calculate his output.
		/// </summary>
		/// <param name="value">The value the function is to calculate the specific output value for.</param>
		/// <returns></returns>
		protected abstract float ActivationFunctionMethod(float value);

		/// <summary>
		/// Recalculates the output value with the activation function and the sum of the inputs.
		/// </summary>
		/// <returns>The new output value</returns>
		public override float CalculateOutput() {
			bool change = false;
			foreach(Connection con in inCon)
				change = change || con.Change;
			return (net.CalculationPaused && change) ? ActivationFunctionMethod(sumUpInputs()) : CurrentValue;
		}

	}
}
