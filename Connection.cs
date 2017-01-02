using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork {
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
			float weight = 0f;
			/// <summary>
			/// Flags if change was logged by the output neuron.
			/// Will automatically set back to false when the input neuron asks for the new value.
			/// </summary>
			bool change = false;

			/// <summary>
			/// Generates a new connection and let the output neuron know this.
			/// </summary>
			/// <param name="outNeuron">The output neuron which sets the value of the connection.</param>
			/// <param name="inNeuron">The input neuron which gets the value of the connection.</param>
			/// <param name="newWeight">The weight of the connection.</param>
			public Connection(GeneralNeuron outNeuron, DependentNeuron inNeuron, float newWeight) {
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
			public float Weight {
				get {
					return weight;
				}
				set {
					weight = value;
					FlagChange();
				}
			}

			/// <summary>
			/// Allows the output neuron to mark a change of its value.
			/// Can cause an automatic refresh of the input neuron.
			/// </summary>
			internal void FlagChange() {
				change = true;
				input.RefreshOutput();
			}

			/// <summary>
			/// Gets the current value of the connection, weight already observed.
			/// </summary>
			public float WeightedInput {
				get {
					change = false;
					return output.CurrentValue * weight;
				}
			}

			/// <summary>
			/// Gets if a change was logged by the output neuron.
			/// Will automatically set back to false when the input neuron asks for the new value.
			/// </summary>
			public bool Change {
				get {
					return change;
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
