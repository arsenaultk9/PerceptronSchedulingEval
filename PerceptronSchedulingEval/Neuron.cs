using System;

namespace PerceptronSchedulingEval
{
    public class Neuron
    {
        private readonly double learningRate;

        private double weightX;
        private double weightY;

        public Neuron(double learningRate)
        {
            this.learningRate = learningRate;

            var r = new Random();
            weightX = r.NextDouble();
            weightY = r.NextDouble();
        }

        public double Train(TrainingData data)
        {
            double localError = data.Output - Evaluate(data);

            if (localError != 0)
            {
                weightX += learningRate*localError*data.InputX;
                weightY += learningRate*localError*data.InputY;
            }

            return localError;
        }

        public int Evaluate(Data data)
        {
            double sum = (data.InputX * weightX) + (data.InputY * weightY);
            return (sum >= 0) ? 1 : -1;
        }
    }
}
