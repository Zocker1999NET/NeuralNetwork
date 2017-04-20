using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Exceptions {
	/// <summary>
	/// Defines possible types of float values which can cause exceptions.
	/// </summary>
	public enum KindOfFloatValue {
		/// <summary>
		/// Unknown type of float value.
		/// </summary>
		Unknown,
		/// <summary>
		/// Float value for a connection weight.
		/// </summary>
		Weight,
	}
}
