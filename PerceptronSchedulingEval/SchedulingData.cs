using System;

namespace PerceptronSchedulingEval
{
    public class SchedulingData
    {
        public readonly DateTime RequiredDate;
        public readonly DateTime DeliveredDate;

        public readonly int RequiredQuantity;
        public readonly int DeliveredQuantity;

        public TimeSpan Latness => RequiredDate - DeliveredDate;
        public int Overproduction => DeliveredQuantity - RequiredQuantity;
        public SchedulingData(DateTime requiredDate, DateTime deliveredDate, int requiredQuantity, int deliveredQuantity)
        {
            RequiredDate = requiredDate;
            DeliveredDate = deliveredDate;
            RequiredQuantity = requiredQuantity;
            DeliveredQuantity = deliveredQuantity;
        }

        public override string ToString()
        {
            return $"{RequiredDate}, {DeliveredDate}, {RequiredQuantity}, {DeliveredQuantity}";
        }
    }
}
