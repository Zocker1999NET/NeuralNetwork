using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Functions {
	/// <summary>
	/// Represents a function used by neurons.
	/// </summary>
	public abstract class GeneralFunction {

		private static bool betw(double v, double v1, double v2) {
			return v1 > v2 ? v2 <= v && v <= v1 : v1 <= v && v <= v2;
		}

		/// <summary>
		/// Returns the value of the function at the certain position.
		/// </summary>
		/// <param name="x">The requested position.</param>
		/// <returns>The value of the function.</returns>
		public double this[double x] {
			get {
				return Function(x);
			}
		}

		/// <summary>
		/// The parameter the function is addicted to which can also be modified by neurons.
		/// </summary>
		protected double param;

		/// <summary>
		/// Returns the value of the function at the certain position.
		/// </summary>
		/// <param name="x">The requested position.</param>
		/// <returns>The value of the function.</returns>
		public abstract double Function(double x);

		/// <summary>
		/// Returns the differential of the function at the certain position.
		/// </summary>
		/// <param name="x">The requested position.</param>
		/// <returns>The differential of the function.</returns>
		public abstract double Differential(double x);

		/// <summary>
		/// Calculates a possible position for the given value.
		/// </summary>
		/// <param name="y"></param>
		/// <returns></returns>
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
			return x + (step / 2);
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
			param = param + (step / 2);
			return true;
		}

	}
}
