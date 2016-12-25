using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork {
	public abstract class NeuralNetwork {

		private bool calcPaused = false;

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
