using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Tests {
	/// <summary>
	/// Represents a NeuralNetwork which is testing the learning abilities of OneLayerNetworks with a XOR Gate Simulation.
	/// </summary>
	public class XOrNet : OneLayerNetwork {

		public XOrNet() : base(2, 3, 1, true) { }



	}
}
