using System;
using System.Collections.Generic;
using System.Linq;

namespace PerceptronSchedulingEval
{
    public class NeuralNetwork
    {
        private readonly List<TrainingData> trainingData;

        private readonly Neuron neuron;

        public NeuralNetwork(double learningRate, params TrainingData[] trainingDatas)
        {
            neuron = new Neuron(learningRate);

            trainingData = trainingDatas.ToList();
        }

        public void Train()
        {
            var iteration = 0;
            double globalError;

            do
            {
                globalError = 0;

                foreach (var data in trainingData)
                {
                    var localError = neuron.Train(data);
                    globalError += Math.Abs(localError);
                }

                Console.WriteLine("Iteration {0}\tError {1}", iteration, globalError);
                iteration++;

            } while (globalError != 0);
        }

        public int Evaluate(Data data)
        {
            return neuron.Evaluate(data);
        }
    }
}
