using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Neurons;

namespace NeuralNetwork {
	public abstract class LayeredNetwork : NeuralNetwork {

		protected delegate T genListDelegate<T>();
		protected delegate T genListBoolDelegate<T>(bool config);

		protected void addCountToList<T>(int count, genListDelegate<T> method, List<T> l) {
			for(int c = 0; c < count; c++)
				l.Add(method());
		}

		protected void addCountToList<T>(int count, genListBoolDelegate<T> method, List<T> l, bool config) {
			for(int c = 0; c < count; c++)
				l.Add(method(config));
		}

		protected void addConnections(DependentNeuron[] output, GeneralNeuron[] input) {
			foreach(var o in output)
				foreach(var i in input)
					o.AddInputConnection(i, nextRandom());
		}

	}
}
