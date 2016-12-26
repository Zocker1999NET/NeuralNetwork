using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Functions {
	public abstract class GeneralFunction {

		private static bool betw(float v, float v1, float v2) {
			return v1 > v2 ? v2 <= v && v <= v1 : v1 <= v && v <= v2;
		}

		public float this[float x] {
			get {
				return Function(x);
			}
		}

		protected float param;

		public abstract float Function(float x);

		public virtual float Inverse(float y) {
			float x = -10f;
			float step = 1f;
			float oldVal = Function(x);
			float newVal = Function(x);
			while(step >= 0.001f) {
				while(!betw(y, oldVal, newVal)) {
					x += step;
					oldVal = newVal;
					newVal = Function(x);
					if(x > 10)
						return 0f;
				}
				x -= step;
				step /= 10f;
			}
			return x + ( step / 2f );
		}

		public virtual bool SetParameterFor(float x, float y) {
			float oldP = param;
			param = -10f;
			float step = 1f;
			float oldVal = Function(x);
			float newVal = Function(x);
			while(step >= 0.001f) {
				step /= 10f;
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
				step /= 10f;
			}
			param = param + ( step / 2f );
			return true;
		}

	}
}
