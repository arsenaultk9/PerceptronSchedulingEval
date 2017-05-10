using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronSchedulingEval
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            // Load sample input patterns.
            double[,] inputs = new double[,] {
                { 0.72, 0.82 }, { 0.91, -0.69 }, { 0.46, 0.80 },
                { 0.03, 0.93 }, { 0.12, 0.25 }, { 0.96, 0.47 },
                { 0.79, -0.75 }, { 0.46, 0.98 }, { 0.66, 0.24 },
                { 0.72, -0.15 }, { 0.35, 0.01 }, { -0.16, 0.84 },
                { -0.04, 0.68 }, { -0.11, 0.10 }, { 0.31, -0.96 },
                { 0.00, -0.26 }, { -0.43, -0.65 }, { 0.57, -0.97 },
                { -0.47, -0.03 }, { -0.72, -0.64 }, { -0.57, 0.15 },
                { -0.25, -0.43 }, { 0.47, -0.88 }, { -0.12, -0.90 },
                { -0.58, 0.62 }, { -0.48, 0.05 }, { -0.79, -0.92 },
                { -0.42, -0.09 }, { -0.76, 0.65 }, { -0.77, -0.76 } };

            // Load sample output patterns.
            int[] outputs = new int[] {
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            var dataA = new TrainingData(0.72, 0.82, -1);
            var dataB = new TrainingData(0.91, -0.69, -1);
            var dataC = new TrainingData(0.46, 0.80, -1);
            var dataD = new TrainingData(0.03, 0.93, -1);
            var dataE = new TrainingData(0.12, 0.25, -1);
            var dataF = new TrainingData(0.96, 0.47, -1);
            var dataG = new TrainingData(0.79, -0.75, -1);
            var dataH = new TrainingData(0.46, 0.98, -1);
            var dataI = new TrainingData(0.66, 0.24, -1);
            var dataJ = new TrainingData(0.72, -0.15, -1);
            var dataK = new TrainingData(0.35, 0.01, - 1);
            var dataL = new TrainingData(-0.16, 0.84, -1);
            var dataM = new TrainingData(-0.04, 0.68, -1);

            var dataN = new TrainingData(-0.11, 0.10, 1);
            var dataO = new TrainingData(0.31, -0.96, 1);
            var dataP = new TrainingData(0.00, -0.26, 1);
            var dataQ = new TrainingData(-0.43, -0.65, 1);
            var dataR = new TrainingData(0.57, -0.97, 1);
            var dataS = new TrainingData(-0.47, -0.03, 1);
            var dataT = new TrainingData(-0.72, -0.64, 1);
            var dataU = new TrainingData(-0.57, 0.15, 1);
            var dataV = new TrainingData(-0.25, -0.43, 1);
            var dataW = new TrainingData(0.47, -0.88, 1);
            var dataX = new TrainingData(-0.12, -0.90, 1);
            var dataY = new TrainingData(-0.58, 0.62, 1);
            var dataZ = new TrainingData(-0.48, 0.05, 1);
            var dataAa = new TrainingData(-0.79, -0.92, 1);
            var dataBb = new TrainingData(-0.42, -0.09, 1);
            var dataCc = new TrainingData(-0.76, 0.65, 1);
            var dataDd = new TrainingData(-0.77, -0.76, 1);

            var network = new NeuralNetwork(0.1,
                dataA,
                dataB,
                dataC,
                dataD,
                dataE,
                dataF,
                dataG,
                dataH,
                dataI,
                dataJ,
                dataK,
                dataL,
                dataM,
                dataN,
                dataO,
                dataP,
                dataQ,
                dataR,
                dataS,
                dataT,
                dataU,
                dataV,
                dataW,
                dataX,
                dataY,
                dataZ,
                dataAa,
                dataBb,
                dataCc,
                dataDd);

            network.Train();

            Console.WriteLine();
            Console.WriteLine("X, Y, Output");
            for (double x = -1; x <= 1; x += .5)
            {
                for (double y = -1; y <= 1; y += .5)
                {
                    var data = new Data(x, y);
                    var output = network.Evaluate(data);
                    Console.WriteLine("{0}, {1}, {2}", x, y, (output == 1) ? "Blue" : "Red");
                }
            }
            Console.ReadKey();
        }
    }
}
