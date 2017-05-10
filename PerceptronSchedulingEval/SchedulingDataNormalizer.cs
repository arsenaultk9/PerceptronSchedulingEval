using System;
using System.Collections.Generic;
using System.Linq;

namespace PerceptronSchedulingEval
{
    public class SchedulingDataNormalizer
    {
        private TimeSpan ealiestDeliveryDifference;
        private TimeSpan latestDeliveryDifference;

        private int minimumOverproduction;
        private int maximumOverproduction;

        public IEnumerable<TrainingData> NormalizeSchedulingTrainingData(
            params SchedulingTrainingData[] schedulingTrainingDatas)
        {
            ealiestDeliveryDifference = schedulingTrainingDatas.OrderBy(std => std.Latness.Ticks).First().Latness;
            latestDeliveryDifference = schedulingTrainingDatas.OrderByDescending(std => std.Latness.Ticks).First().Latness;

            minimumOverproduction = schedulingTrainingDatas.OrderBy(std => std.Overproduction).First().Overproduction;
            maximumOverproduction = schedulingTrainingDatas.OrderByDescending(std => std.Overproduction).First().Overproduction;

            var trainingDatas = new List<TrainingData>();

            foreach (var schedulingTrainingData in schedulingTrainingDatas)
            {
                var data = GetData(schedulingTrainingData);
                var trainingData = new TrainingData(data.InputX, data.InputY, schedulingTrainingData.isValid ? 1 : - 1);

                trainingDatas.Add(trainingData);
            }

            return trainingDatas;
        }

        public Data NormarlizeSchedulingData(SchedulingData schedulingData)
        {
            return GetData(schedulingData);
        }

        #region Private Methods

        private Data GetData(SchedulingData schedulingData)
        {
            var deliveryFromStart = schedulingData.Latness.Ticks - ealiestDeliveryDifference.Ticks;
            var deliveryRatio = (double)deliveryFromStart /(latestDeliveryDifference.Ticks - ealiestDeliveryDifference.Ticks);

            var overproductionFromStart = schedulingData.Overproduction - minimumOverproduction;
            var overproductionRatio = (double)overproductionFromStart/(maximumOverproduction - minimumOverproduction);

            return new Data(deliveryRatio, overproductionRatio);
        }

        #endregion
    }
}
