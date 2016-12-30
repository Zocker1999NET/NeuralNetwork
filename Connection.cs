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
			/// The weigth of the connection.
			/// </summary>
			float weight = 0f;
			/// <summary>
			/// Flags if change was loged by the output neuron.
			/// Will automatically set back to false when the input neuron asks for the new value.
			/// </summary>
			bool change = false;

			/// <summary>
			/// Generates a new connection and let the output neuron know this.
			/// </summary>
			/// <param name="outNeuron">The output neuron which sets the value of the connection.</param>
			/// <param name="inNeuron">The input neuron which gets the value of the connection.</param>
			/// <param name="weigth">The weight of the connection.</param>
			public Connection(GeneralNeuron outNeuron, DependentNeuron inNeuron, float weigth) {
				output = outNeuron;
				input = inNeuron;
				output.outCon.Add(this);
			}

			/// <summary>
			/// Gets or sets the weigth of the connection.
			/// </summary>
			public float Weigth {
				get {
					return weight;
				}
				set {
					weight = value;
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
			/// Gets if a change was loged by the output neuron.
			/// Will automatically set back to false when the input neuron asks for the new value.
			/// </summary>
			public bool Change {
				get {
					return change;
				}
			}

		}
	}
}
