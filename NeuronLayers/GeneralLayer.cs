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
	internal abstract partial class GeneralLayer {
		
		/// <summary>
		/// Represents a method for generating neurons.
		/// </summary>
		/// <typeparam name="T">The type of neuron which should be generated.</typeparam>
		/// <param name="network">The network the created neurons are to be part of.</param>
		/// <returns></returns>
		public delegate T NeuronGeneratorDelegate<T>(LayeredNetwork network) where T : GeneralNeuron;

		/// <summary>
		/// The neuron generator for this specific layer.
		/// </summary>
		private NeuronGeneratorDelegate<GeneralNeuron> generator;
		/// <summary>
		/// A list of all neurons which are part of this layer. 
		/// </summary>
		private List<GeneralNeuron> neurons = new List<GeneralNeuron>();
		/// <summary>
		/// A list of all output connections this layer handles for its neurons.
		/// </summary>
		private List<Connection> outCon = new List<Connection>();
		/// <summary>
		/// The network this layer is part of.
		/// </summary>
		private LayeredNetwork net;

		/// <summary>
		/// Generates a new layer with the given properties.
		/// </summary>
		/// <param name="network">The network the new layer is to be part of.</param>
		/// <param name="genMethod">The generation method which is to be used to generate new neurons.</param>
		/// <param name="neuronCount">The count of neurons the new layer is supposed to handle at the beginnging.</param>
		public GeneralLayer(LayeredNetwork network, NeuronGeneratorDelegate<GeneralNeuron> genMethod, int neuronCount) {
			generator = genMethod;
			net = network;
			for(int i = 0; i < neuronCount; i++)
				neurons.Add(generator(net));
		}

		/// <summary>
		/// Allows access to the neurons for inheriting classes.
		/// </summary>
		protected List<GeneralNeuron> Neurons => neurons;

		/// <summary>
		/// Refers to the network this layer is part of.
		/// </summary>
		public LayeredNetwork Network => net;

		/// <summary>
		/// Returns if this layer is disabled meaning it does not work anymore.
		/// </summary>
		public bool Disabled => net == null;
		
		/// <summary>
		/// Generates the given count of neurons and adds them to this layer.
		/// </summary>
		/// <param name="addCount">The requested count of neurons. If the given number is negative, neurons will be removed.</param>
		/// <returns>The new generated neurons as array.</returns>
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

		/// <summary>
		/// Generates the given count of neurons and adds them to this layer.
		/// </summary>
		/// <param name="addCount">The count of neurons which are to be generated. If the given number is negative, the given count of neurons will be removed.</param>
		/// <returns>True if layer is not disabled.</returns>
		public virtual bool AddNeurons(int addCount) {
			if(Disabled)
				return false;
			GenNeurons(addCount);
			return true;
		}

		/// <summary>
		/// Removes the given count of neurons.
		/// </summary>
		/// <param name="remCount">The count of neurons which are to be removed. If the given number is negative, the given count of neurons will be added.</param>
		/// <returns>True if layer is not disabled.</returns>
		public bool RemoveNeurons(int remCount) {
			return AddNeurons(-remCount);
		}

		/// <summary>
		/// Adds or removes a certain count of neurons to reach the requested count.
		/// </summary>
		/// <param name="newCount">The new count of neurons.</param>
		/// <returns>True if layer is not disabled.</returns>
		public bool ChangeNeuronCount(int newCount) {
			return AddNeurons(newCount - neurons.Count);
		}

		/// <summary>
		/// Refreshes the outputs of all neurons. See <see cref="GeneralNeuron.RefreshOutput"/>.
		/// </summary>
		public void RefreshOutputs() {
			if(Disabled)
				return;
			foreach(var neuron in neurons)
				neuron.RefreshOutput();
		}

		/// <summary>
		/// The outputs of all neurons in an array. See <see cref="GeneralNeuron.CurrentValue"/>
		/// </summary>
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

		/// <summary>
		/// Disables all neurons and connections and removes this layer.
		/// </summary>
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
