using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronSchedulingEval
{
    public class TrainingData : Data
    {
        public readonly double Output;

        public TrainingData(double inputX, double inputY, double output) : base(inputX, inputY)
        {
            this.Output = output;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, result: {Output}";
        }
    }
}
