using System;
using System.Linq;

namespace PerceptronSchedulingEval
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            var schedulingDataNormalizer = new SchedulingDataNormalizer();

            var taskA = new SchedulingTrainingData(new DateTime(2007, 1, 15), new DateTime(2007, 1, 15), 50, 50, true);
            var taskB = new SchedulingTrainingData(new DateTime(2007, 1, 15), new DateTime(2007, 1, 14), 50, 40, true);
            var taskC = new SchedulingTrainingData(new DateTime(2007, 1, 15), new DateTime(2007, 1, 16), 50, 60, true);
            var taskD = new SchedulingTrainingData(new DateTime(2007, 1, 15), new DateTime(2007, 1, 13), 50, 30, true);
            var taskE = new SchedulingTrainingData(new DateTime(2007, 1, 15), new DateTime(2007, 1, 17), 50, 70, true);

            var taskF = new SchedulingTrainingData(new DateTime(2007, 1, 15), new DateTime(2007, 1, 15), 50, 40, false);
            var taskG = new SchedulingTrainingData(new DateTime(2007, 1, 15), new DateTime(2007, 1, 14), 50, 30, false);
            var taskH = new SchedulingTrainingData(new DateTime(2007, 1, 15), new DateTime(2007, 1, 17), 50, 60, false);
            var taskI = new SchedulingTrainingData(new DateTime(2007, 1, 15), new DateTime(2007, 1, 13), 50, 20, false);
            var taskJ = new SchedulingTrainingData(new DateTime(2007, 1, 15), new DateTime(2007, 1, 18), 50, 70, false);


            var trainingDataNormalized = schedulingDataNormalizer.NormalizeSchedulingTrainingData(taskA,
                taskB,
                taskC,
                taskD,
                taskE,
                taskF,
                taskG,
                taskH,
                taskI,
                taskJ);

            var network = new NeuralNetwork(0.1, trainingDataNormalized.ToArray());
            network.Train();

            Console.WriteLine();
            Console.WriteLine("Required Date, Delivered Data, Required Qty, Delivered Qty, Is acceptable");

            var testA = new SchedulingData(new DateTime(2017, 1, 15), new DateTime(2017, 1, 14), 50, 45);
            var testB = new SchedulingData(new DateTime(2017, 1, 15), new DateTime(2017, 1, 16), 50, 25);
            var testC = new SchedulingData(new DateTime(2017, 1, 15), new DateTime(2017, 1, 16), 50, 55);

            var testData = new [] { testA, testB, testC};

            foreach (var schedulingData in testData)
            {
                var dataNormalized = schedulingDataNormalizer.NormarlizeSchedulingData(schedulingData);
                var output = network.Evaluate(dataNormalized) == 1 ? "True" : "False";

                Console.WriteLine($"{schedulingData}, {output}");
            }

            Console.ReadKey();
        }
    }
}
