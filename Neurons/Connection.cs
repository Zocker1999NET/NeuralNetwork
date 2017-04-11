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
			/// <param name="newWeight">The weight of the connection.</param>
			public Connection(GeneralNeuron outNeuron, DependentNeuron inNeuron, double newWeight) {
				output = outNeuron;
				input = inNeuron;
				weight = newWeight;
				output.outCon.Add(this);
			}

			internal GeneralNeuron OutputNeuron {
				get {
					return output;
				}
			}

			internal DependentNeuron InputNeuron {
				get {
					return input;
				}
			}

			/// <summary>
			/// Gets or sets the weight of the connection. Changes of the weight also causes an automatic refresh of the input neuron.
			/// </summary>
			public double Weight {
				get {
					return weight;
				}
				set {
					weight = value;
					input.flagChange();
				}
			}

			/// <summary>
			/// Gets the current value of the connection, weight already observed.
			/// </summary>
			public double WeightedInput {
				get {
					return output.CurrentValue * weight;
				}
			}

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
				
			}

		}
	}
}
