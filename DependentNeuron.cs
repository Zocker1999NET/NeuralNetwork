using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Exceptions;

namespace NeuralNetwork {
	public abstract class DependentNeuron : GeneralNeuron {

		protected List<Connection> inCon;

		public void AddInputConnection(GeneralNeuron source, float weigth) {
			rangeEx(weigth, KindOfFloatValue.Weigth);
			inCon.Add(new Connection(source, this, weigth));
		}

		public Connection[] getInputConnections() {
			return inCon.ToArray();
		}
		
	}
}
