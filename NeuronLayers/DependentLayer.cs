using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Neurons;

namespace NeuralNetwork.NeuronLayers {
	internal abstract class DependentLayer : GeneralLayer {

		private List<Connection> inCon = new List<Connection>();

		public DependentLayer(LayeredNetwork network, NeuronGeneratorDelegate<DependentNeuron> genMethod, int neuronCount) : base(network, delegate (LayeredNetwork net) {
			return genMethod(net);
		}, neuronCount) { }

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

		public void AddInputConnections(GeneralLayer source) {
			if(Disabled)
				return;
			foreach(var c in inCon)
				if(c.OutputLayer == source)
					return;
			inCon.Add(new Connection(source, this));
		}

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

		public void RemoveInputConnections(GeneralLayer source) {
			if(Disabled)
				return;
			foreach(var c in inCon)
				if(c.OutputLayer == source)
					RemoveInputConnections(c);
		}

		public sealed override void RemoveLayer() {
			if(Disabled)
				return;
			foreach(var inC in inCon)
				inC.RemoveConnections();
			base.RemoveLayer();
		}

	}
}
