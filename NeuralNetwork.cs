using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork {
	/// <summary>
	/// Represents a neural network with many neurons.
	/// </summary>
	public abstract class NeuralNetwork {

		private bool calcPaused = false;

		/// <summary>
		/// Gets if the neural network is paused so the neurons inside will not recalculate their outputs on input changes.
		/// </summary>
		public bool CalculationPaused {
			get {
				return calcPaused;
			}
			protected set {
				calcPaused = value;
			}
		}

	}
}
