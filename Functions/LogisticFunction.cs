using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Functions {
	public class LogisticFunction : GeneralFunction {

		public LogisticFunction(double propConst) {
			param = propConst;
		}

		public override double Function(double x) {
			return ( 2 / ( 1 + ( Math.Pow(Math.E, ( -param ) * x) ) ) ) - 1;
		}

		public override double Inverse(double y) {
			return -( Math.Log(( 2 / ( y + 1 ) ) - 1) / param );
		}

		public override bool SetParameterFor(double x, double y) {
			param = -( Math.Log(( 2 / ( y + 1 ) ) - 1) / x );
			return true;
		}

	}
}
