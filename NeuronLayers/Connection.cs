using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Neurons;

namespace NeuralNetwork.NeuronLayers {
	internal abstract partial class GeneralLayer {
		public class Connection : ISupervisingConnection {

			public event EventHandler ConnectionRemoved;

			private GeneralLayer output;
			private DependentLayer input;

			public Connection(GeneralLayer outLayer, DependentLayer inLayer) {
				output = outLayer;
				input = inLayer;
				output.outCon.Add(this);
				foreach(var inNeuron in inLayer.neurons) {
					foreach(var outNeuron in outLayer.neurons)
						((DependentNeuron)inNeuron).ConnectTo(outNeuron);
				}
			}

			public GeneralLayer OutputLayer => output;

			public DependentLayer InputLayer => input;

			public void AddOutputNeuron(GeneralNeuron outNeuron) {
				foreach(var inNeuron in input.neurons) {
					((DependentNeuron)inNeuron).ConnectTo(outNeuron);
				}
			}

			public void AddOutputNeurons(GeneralNeuron[] outNeurons) {
				foreach(var outNeuron in outNeurons)
					AddOutputNeuron(outNeuron);
			}

			public void AddInputNeuron(DependentNeuron inNeuron) {
				foreach(var outNeuron in output.neurons) {
					inNeuron.ConnectTo(outNeuron);
				}
			}

			public void AddInputNeurons(DependentNeuron[] inNeurons) {
				foreach(var inNeuron in inNeurons)
					AddInputNeuron(inNeuron);
			}

			public void RemoveConnections() {
				if(output == null)
					return;
				ConnectionRemoved(this, new EventArgs());
				output.outCon.Remove(this);
				output = null;
				input.RemoveInputConnections(this);
				input = null;
				//TODO: Remove connection class
			}

		}
	}
}
