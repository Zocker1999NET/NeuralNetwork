using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Neurons;

namespace NeuralNetwork.NeuronLayers {
	/// <summary>
	/// Represents a layer with neurons which need to be able to return its current value.
	/// All layers inherit from this class.
	/// </summary>
	internal abstract class DependentLayer : GeneralLayer {

		/// <summary>
		/// Lists all input connections.
		/// </summary>
		private List<Connection> inCon = new List<Connection>();

		/// <summary>
		/// Generates a new layer with the given properties.
		/// </summary>
		/// <param name="network">The network the new layer is to be part of.</param>
		/// <param name="genMethod">The generation method which is to be used to generate new neurons.</param>
		/// <param name="neuronCount">The count of neurons the new layer is supposed to handle at the beginnging.</param>
		public DependentLayer(LayeredNetwork network, NeuronGeneratorDelegate<DependentNeuron> genMethod, int neuronCount) : base(network, delegate (LayeredNetwork net) {
			return genMethod(net);
		}, neuronCount) { }

		/// <summary>
		/// Generates the given count of neurons and adds them to this layer.
		/// </summary>
		/// <param name="addCount">The count of neurons which are to be generated. If the given number is negative, the given count of neurons will be removed.</param>
		/// <returns>True if layer is not disabled.</returns>
		public sealed override bool AddNeurons(int addCount) {
			if(Disabled)
				return false;
			if(addCount == 0)
				return false;
			GeneralNeuron[] neuronsG = GenNeurons(addCount);
			if(neuronsG.Count() > 0) {
				var neurons = new DependentNeuron[addCount];
				for(var i = 0; i < neuronsG.Count(); i++)
					neurons[i] = (DependentNeuron)neuronsG[i];
				foreach(var inC in inCon)
					inC.AddInputNeurons(neurons);
			}
			return true;
		}

		/// <summary>
		/// Connects this layer with another one and handles the connection of all neurons inside the layers.
		/// </summary>
		/// <param name="source">The layer this layer is to get connnected with.</param>
		public void AddInputConnections(GeneralLayer source) {
			if(Disabled)
				return;
			foreach(var c in inCon)
				if(c.OutputLayer == source)
					return;
			inCon.Add(new Connection(source, this));
		}

		/// <summary>
		/// Removes a certain connection with a layer and disables all connections of the neurons.
		/// </summary>
		/// <param name="con">The connection which should be removed.</param>
		public void RemoveInputConnections(Connection con) {
			if(Disabled)
				return;
			if(con.InputLayer != this)
				return;
			if(con.OutputLayer == null)
				inCon.Remove(con);
			else
				con.RemoveConnections();
		}

		/// <summary>
		/// Removes a certain connection with a layer and disables all connections of the neurons.
		/// </summary>
		/// <param name="source">The layer which should be disconnected from this one.</param>
		public void RemoveInputConnections(GeneralLayer source) {
			if(Disabled)
				return;
			foreach(var c in inCon)
				if(c.OutputLayer == source)
					RemoveInputConnections(c);
		}

		/// <summary>
		/// Disables all neurons and connections and removes this layer.
		/// </summary>
		public sealed override void RemoveLayer() {
			if(Disabled)
				return;
			foreach(var inC in inCon)
				inC.RemoveConnections();
			base.RemoveLayer();
		}

	}
}
