using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Functions {
	public class LinearFunction : GeneralFunction {

		public LinearFunction(float slope) {
			param = slope;
		}

		public override float Function(float x) {
			return x * param;
		}

		public override float Inverse(float y) {
			return y / param;
		}

		public override bool SetParameterFor(float x, float y) {
			param = y / x;
			return true;
		}

	}
}
