using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Functions {
	public abstract class GeneralFunction {

		private static bool betw(double v, double v1, double v2) {
			return v1 > v2 ? v2 <= v && v <= v1 : v1 <= v && v <= v2;
		}

		public double this[double x] {
			get {
				return Function(x);
			}
		}

		protected double param;

		public abstract double Function(double x);

		public virtual double Inverse(double y) {
			double x = -10;
			double step = 1;
			double oldVal = Function(x);
			double newVal = Function(x);
			while(step >= 0.001) {
				while(!betw(y, oldVal, newVal)) {
					x += step;
					oldVal = newVal;
					newVal = Function(x);
					if(x > 10)
						return 0;
				}
				x -= step;
				step /= 10;
			}
			return x + ( step / 2 );
		}

		public virtual bool SetParameterFor(double x, double y) {
			double oldP = param;
			param = -10;
			double step = 1;
			double oldVal = Function(x);
			double newVal = Function(x);
			while(step >= 0.001) {
				step /= 10;
				while(!betw(y, oldVal, newVal)) {
					param += step;
					oldVal = newVal;
					newVal = Function(x);
					if(x > 10) {
						param = oldP;
						return false;
					}
				}
				param -= step;
				step /= 10;
			}
			param = param + ( step / 2 );
			return true;
		}

	}
}
