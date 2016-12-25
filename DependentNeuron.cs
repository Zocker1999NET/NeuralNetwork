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
			inCon.Add(new Connection(source, this, weigth));
		}

		public Connection[] getInputConnections() {
			return inCon.ToArray();
		}

		protected float sumUpInputs() {
			float sum = 0f;
			foreach(Connection con in inCon)
				sum += con.WeightedInput;
			return sum;
		} 
		
	}
}
