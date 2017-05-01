using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Neurons;

namespace NeuralNetwork.NeuronLayers {
	internal abstract partial class GeneralLayer {

		public delegate T NeuronGeneratorDelegate<T>(LayeredNetwork network) where T : GeneralNeuron;

		private NeuronGeneratorDelegate<GeneralNeuron> generator;
		private List<GeneralNeuron> neurons = new List<GeneralNeuron>();
		private List<Connection> outCon = new List<Connection>();
		private LayeredNetwork net;

		public GeneralLayer(LayeredNetwork network, NeuronGeneratorDelegate<GeneralNeuron> genMethod, int neuronCount) {
			generator = genMethod;
			net = network;
			for(int i = 0; i < neuronCount; i++)
				neurons.Add(generator(net));
		}

		protected List<GeneralNeuron> Neurons => neurons;

		public LayeredNetwork Network => net;

		public bool Disabled => net == null;
		
		protected GeneralNeuron[] GenNeurons(int addCount) {
			var ret = new GeneralNeuron[addCount];
			if(addCount == 0)
				return null;
			if(addCount > 0) {
				for(int i = 0; i < addCount; i++) {
					ret[i] = generator(net);
					neurons.Add(ret[i]);
				}
			} else {
				int newC = neurons.Count + addCount;
				while(newC < neurons.Count) {
					neurons.Last().RemoveNeuron();
					neurons.RemoveAt(neurons.Count - 1);
				}
			}
			return ret;
		}

		public virtual bool AddNeurons(int addCount) {
			if(Disabled)
				return false;
			GenNeurons(addCount);
			return true;
		}

		public bool RemoveNeurons(int remCount) {
			return AddNeurons(-remCount);
		}

		public bool ChangeNeuronCount(int newCount) {
			return AddNeurons(newCount - neurons.Count);
		}

		public void RefreshOutputs() {
			if(Disabled)
				return;
			foreach(var neuron in neurons)
				neuron.RefreshOutput();
		}

		public double[] CurrentValues {
			get {
				if(Disabled)
					return new double[0];
				double[] r = new double[neurons.Count];
				for(int i = 0; i < neurons.Count; i++)
					r[i] = neurons[i].CurrentValue;
				return r;
			}
		}

		public virtual void RemoveLayer() {
			if(Disabled)
				return;
			foreach(var outC in outCon)
				outC.RemoveConnections();
			foreach(var neuron in neurons)
				neuron.RemoveNeuron();
			net = null;
		}

	}
}
