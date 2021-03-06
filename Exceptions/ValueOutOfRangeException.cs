﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Exceptions {
	public class ValueOutOfRangeException : Exception {

		private const string end = " is not in the defined range [-1;1] for these kind of neural networks.";

		private bool valueGiven = false;
		private double givenValue;

		private KindOfFloatValue kindOfValue = KindOfFloatValue.Unknown;

		private static string getBegin() {
			return getBegin(KindOfFloatValue.Unknown);
		}

		private static string getBegin(KindOfFloatValue type) {
			switch(type) {
				case KindOfFloatValue.Weight:
					return "The given weight";
			}
			return "The given double value";
		}

		public ValueOutOfRangeException() : base(getBegin() + end) { }

		public ValueOutOfRangeException(KindOfFloatValue type) : base(getBegin(type) + end) {
			kindOfValue = type;
		}

		public ValueOutOfRangeException(double value) : base(getBegin() + " \"" + value.ToString() + "\"" + end) {
			valueGiven = true;
			givenValue = value;
		}

		public ValueOutOfRangeException(KindOfFloatValue type, double value) : base(getBegin(type) + " \"" + value.ToString() + "\"" + end) {
			kindOfValue = type;
			valueGiven = true;
			givenValue = value;
		}

		public bool IsValueGiven {
			get {
				return valueGiven;
			}
		}

		public double GivenValue {
			get {
				if(valueGiven)
					return givenValue;
				return 0f;
			}
		}

		public KindOfFloatValue KindOfGivenValue {
			get {
				return kindOfValue;
			}
		}

	}
}
