﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Neurons;

namespace NeuralNetwork {
	/// <summary>
	/// Represents all layered neural networks
	/// </summary>
	public abstract class LayeredNetwork : NeuralNetwork {

		/// <summary>
		/// Delegates a generation method with a configuration argument for a certain neuron type.
		/// </summary>
		/// <typeparam name="T">The specific kind of neurons.</typeparam>
		/// <param name="config">The configuration argument. Behavior depends on the given method.</param>
		/// <returns></returns>
		protected delegate T genListBoolDelegate<T>(bool config) where T : GeneralNeuron;

		/// <summary>
		/// The input layer of this network
		/// </summary>
		protected List<InputNeuron> inputLayer = new List<InputNeuron>();

		/// <summary>
		/// The output layer of this network
		/// </summary>
		protected List<OutputNeuron> outputLayer = new List<OutputNeuron>();

		/// <summary>
		/// Generates the input and output layers with the given configuration.
		/// </summary>
		/// <param name="inputCount">The count of the input neurons.</param>
		/// <param name="outputCount">The count of the output neurons.</param>
		/// <param name="inputConfig">The configuration of the input neurons.</param>
		/// <param name="outputConfig">The configuration of the output neurons.</param>
		protected LayeredNetwork(int inputCount, int outputCount, bool inputConfig, bool outputConfig) {
			AddCountToList(inputCount, GenerateInputNeuron, inputLayer, inputConfig);
			AddCountToList(outputCount, GenerateOutputNeuron, outputLayer, outputConfig);
		}

		/// <summary>
		/// Adds the given count of neurons generated by the given method to the given list.
		/// </summary>
		/// <typeparam name="T">The specific kind of neurons.</typeparam>
		/// <param name="count">The count of neurons this method should add to the list.</param>
		/// <param name="method">The method which is to create the neurons to add to the list.</param>
		/// <param name="l">The list the created neurons will be added to.</param>
		/// <param name="config">The configuration argument. Behavior depends on the given method.</param>
		protected void AddCountToList<T>(int count, genListBoolDelegate<T> method, List<T> l, bool config = false) where T : GeneralNeuron {
			for(int c = 0; c < count; c++)
				l.Add(method(config));
		}

		/// <summary>
		/// Creates connections with random weights between both layers.
		/// </summary>
		/// <param name="output">The output neurons of the new connections.</param>
		/// <param name="input">The input neurons of the new connections.</param>
		protected void AddConnections(DependentNeuron[] output, GeneralNeuron[] input) {
			foreach(var o in output)
				foreach(var i in input)
					o.ConnectTo(i);
		}

		/// <summary>
		/// Generates a new input neuron this kind of network should use.
		/// </summary>
		/// <param name="config">The configuration argument. Behavior depends on the overriding method.</param>
		/// <returns>The new created neuron.</returns>
		protected abstract InputNeuron GenerateInputNeuron(bool config);

		/// <summary>
		/// Generates a new output neuron this kind of network should use.
		/// </summary>
		/// <param name="config">The configuration argument. Behavior depends on the overriding method.</param>
		/// <returns>The new created neuron.</returns>
		protected abstract OutputNeuron GenerateOutputNeuron(bool config);

		/// <summary>
		/// Uses the setNextValue methods of the input neurons to set their new values.
		/// </summary>
		/// <param name="inputValues">The next input values. The length must be the same or higher than the count of input neurons.</param>
		public void SetNextInputValues(params double[] inputValues) {
			if(inputValues.Length < inputLayer.Count)
				throw new Exception("Too less input values for this network!");
			for(int i = 0; i < inputLayer.Count; i++)
				inputLayer[i].SetNextValue(inputValues[i]);
		}

		/// <summary>
		/// Returns the current output values of the output layer.
		/// </summary>
		/// <returns>The current output values as array.</returns>
		public double[] GetCurrentOutputs() {
			var l = new List<double>();
			foreach(OutputNeuron output in outputLayer)
				l.Add(output.CurrentValue);
			return l.ToArray();
		}

		/// <summary>
		/// Returns the individual neuron counts of all layers.
		/// </summary>
		/// <returns>The count of neurons for each layer.</returns>
		public abstract int[] GetNeuronsCounts();

		/// <summary>
		/// Returns the count of layers this network has.
		/// </summary>
		/// <returns>The count of layers.</returns>
		public int GetLayerCounts() => GetNeuronsCounts().Count();

		/// <summary>
		/// Gets the counts of neurons in this network.
		/// </summary>
		public override int NeuronCount => GetNeuronsCounts().Sum();

		/// <summary>
		/// Initiates a recalculation of the whole network.
		/// Recalculates even if calculation is paused.
		/// </summary>
		public override void Recalculate() {
			foreach(GeneralNeuron neuron in inputLayer)
				neuron.RefreshOutput();
		}

	}
}
