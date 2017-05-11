using System;

namespace PerceptronSchedulingEval
{
    public class Neuron
    {
        private readonly double learningRate;

        private double weightX;
        private double weightY;

        private double weightB;

        public Neuron(double learningRate)
        {
            this.learningRate = learningRate;

            var r = new Random();

            weightX = r.NextDouble();
            weightY = r.NextDouble();
            weightB = r.NextDouble();
        }

        public double Train(TrainingData data)
        {
            var localError = data.Output - Evaluate(data);

            if (localError == 0) return localError;

            weightX += learningRate*localError*data.InputX;
            weightY += learningRate*localError*data.InputY;
            weightB += learningRate*localError*1;

            return localError;
        }

        public int Evaluate(Data data)
        {
            var sum = (data.InputX * weightX) + (data.InputY * weightY) + (1 * weightB);
            return (sum >= 0) ? 1 : -1; // Activation function
        }
    }
}
