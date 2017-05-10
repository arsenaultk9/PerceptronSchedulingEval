using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronSchedulingEval
{
    public class SchedulingTrainingData : SchedulingData
    {
        public readonly bool isValid; 
        public SchedulingTrainingData(DateTime requiredDate, DateTime deliveredDate, int requiredQuantity, int deliveredQuantity, bool isValid) 
            : base(requiredDate, deliveredDate, requiredQuantity, deliveredQuantity)
        {
            this.isValid = isValid;
        }
    }
}
