using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronSchedulingEval
{
    public class Data
    {
        public readonly double InputX;
        public readonly double InputY;

        public Data(double inputX, double inputY)
        {
            this.InputX = inputX;
            this.InputY = inputY;
        }

        public override string ToString()
        {
            return $"x: {InputX}, y: {InputY}";
        }
    }
}
