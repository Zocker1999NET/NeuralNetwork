using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Functions {
	public class LinearFunction : GeneralFunction {

		public LinearFunction(double slope) {
			param = slope;
		}

		public override double Function(double x) {
			return x * param;
		}

		public override double Inverse(double y) {
			return y / param;
		}

		public override bool SetParameterFor(double x, double y) {
			param = y / x;
			return true;
		}

	}
}
