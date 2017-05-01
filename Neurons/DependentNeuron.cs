using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Exceptions;
using NeuralNetwork.Functions;

namespace NeuralNetwork.Neurons {
	/// <summary>
	/// Represents a neuron which is to be also able to have input connections from other neurons.
	/// By default, hidden and output neurons inherit from this class.
	/// </summary>
	public abstract class DependentNeuron : GeneralNeuron {

		/// <summary>
		/// Lists all input connections
		/// </summary>
		protected List<Connection> inCon;

		GeneralFunction actFunc;

		/// <summary>
		/// Generates a new dependent neuron which is part of the given network.
		/// </summary>
		/// <param name="network">The network the new neuron is to be part of.</param>
		/// <param name="activationFunction">The activation function the neuron should use.</param>
		public DependentNeuron(NeuralNetwork network, GeneralFunction activationFunction) : base(network) {
			actFunc = activationFunction;
			if(actFunc == null)
				actFunc = new LogisticFunction();
		}

		/// <summary>
		/// Gets the activation function of this neuron. Can be changed.
		/// </summary>
		public GeneralFunction ActivationFunction => actFunc;

		/// <summary>
		/// Adds a new connection this neuron has to the given output neuron with the given weight.
		/// </summary>
		/// <param name="source">The output neuron of the new connection.</param>
		public void ConnectTo(GeneralNeuron source) {
			if(Disabled)
				return;
			foreach(Connection c in inCon)
				if(c.OutputNeuron == source)
					return;
			inCon.Add(new Connection(source, this));
		}

		/// <summary>
		/// Returns all input connections this neuron is part of.
		/// </summary>
		/// <returns>All input connections as array.</returns>
		public Connection[] GetInputConnections() {
			if(Disabled)
				return new Connection[0];
			return inCon.ToArray();
		}

		/// <summary>
		/// Removes an input connection if the given connection is connected with this neuron.
		/// </summary>
		/// <param name="con"></param>
		public void RemoveInputConnection(Connection con) {
			if(Disabled)
				return;
			if(con.InputNeuron != this)
				return;
			if(con.OutputNeuron == null)
				inCon.Remove(con);
			else
				con.RemoveConnection();
		}

		/// <summary>
		/// Removes an input connection if the given neuron is connected with this neuron.
		/// </summary>
		/// <param name="source">The neuron of whose connection should be removed.</param>
		public void RemoveInputConnection(GeneralNeuron source) {
			if(Disabled)
				return;
			foreach(Connection c in inCon)
				if(c.OutputNeuron == source)
					RemoveInputConnection(c);
		}

		/// <summary>
		/// Returns the sum of all inputs this neuron are given.
		/// </summary>
		/// <returns>The sum of all inputs</returns>
		protected double SumUpInputs() {
			double sum = 0f;
			foreach(Connection con in inCon)
				sum += con.WeightedInput;
			return sum;
		}

		/// <summary>
		/// Recalculates the output value with the activation function and the sum of the inputs.
		/// </summary>
		/// <returns>The new output value</returns>
		protected sealed override double CalculateOutput() {
			if(Disabled)
				return 0d;
			if(!Change || net.CalculationPaused)
				return CurrentValue;
			Change = false;
			return actFunc[SumUpInputs()];
		}

		/// <summary>
		/// Removes this neuron and all connections this neuron has.
		/// </summary>
		public sealed override void RemoveNeuron() {
			if(Disabled)
				return;
			base.RemoveNeuron();
			foreach(Connection c in inCon)
				c.RemoveConnection();
		}

	}
}
