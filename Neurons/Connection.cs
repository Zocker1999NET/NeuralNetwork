using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Neurons {
	public abstract partial class GeneralNeuron {
		/// <summary>
		/// Represents a connection between two neurons, which can communicate with the methods of this connection.
		/// </summary>
		public class Connection {

			private static readonly Random randomGen = new Random();

			/// <summary>
			/// The neuron which sets the value of the connection.
			/// </summary>
			GeneralNeuron output;
			/// <summary>
			/// The neuron which gets the value of the connection.
			/// </summary>
			DependentNeuron input;
			/// <summary>
			/// The weight of the connection.
			/// </summary>
			double weight = 0f;

			/// <summary>
			/// Generates a new connection and let the output neuron know this.
			/// </summary>
			/// <param name="outNeuron">The output neuron which sets the value of the connection.</param>
			/// <param name="inNeuron">The input neuron which gets the value of the connection.</param>
			public Connection(GeneralNeuron outNeuron, DependentNeuron inNeuron) {
				output = outNeuron;
				input = inNeuron;
				weight = (randomGen.NextDouble() * 2) - 1;
				output.outCon.Add(this);
			}

			internal Connection(GeneralNeuron outNeuron, DependentNeuron inNeuron, ISupervisingConnection supervisor) : this(outNeuron,inNeuron) {
				supervisor.ConnectionRemoved += supervisor_ConnectionRemoved;
			}

			internal GeneralNeuron OutputNeuron => output;

			internal DependentNeuron InputNeuron => input;

			/// <summary>
			/// Gets or sets the weight of the connection. Changes of the weight also causes an automatic refresh of the input neuron.
			/// </summary>
			public double Weight {
				get => weight;
				set {
					weight = value;
					input.flagChange();
				}
			}

			/// <summary>
			/// Gets the current value of the connection, weight already observed.
			/// </summary>
			public double WeightedInput => output.CurrentValue * weight;

			/// <summary>
			/// Removes this connection.
			/// </summary>
			public void RemoveConnection() {
				if(output == null)
					return;
				output.outCon.Remove(this);
				output = null;
				input.RemoveInputConnection(this);
				input = null;
				//TODO: Remove connection class
			}

			private void supervisor_ConnectionRemoved(object sender, EventArgs e) => RemoveConnection();

		}
	}
}
