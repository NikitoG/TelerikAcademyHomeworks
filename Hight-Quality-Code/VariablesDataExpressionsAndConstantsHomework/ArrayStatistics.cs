namespace VariablesDataExpressionsAndConstantsHomework
{
    using System;
    using System.Linq;
    using System.Text;

    public class ArrayStatistics
    {
        public void PrintStatistics(double[] sequence)
        {
            double maxElement = this.GetMax(sequence);
            double minElement = this.GetMin(sequence);
            double average = this.GetAverage(sequence);

            StringBuilder statistics = new StringBuilder();
            statistics.AppendLine(string.Format("Max: {0}", maxElement));
            statistics.AppendLine(string.Format("Min: {0}", minElement));
            statistics.AppendLine(string.Format("Average: {0}", average));

            Console.WriteLine(statistics);
        }

        public double GetMax(double[] sequence)
        {
            double maxElement = double.MinValue;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] > maxElement)
                {
                    maxElement = sequence[i];
                }
            }

            return maxElement;
        }

        public double GetMin(double[] sequence)
        {
            double minElement = sequence.Min();

            return minElement;
        }

        public double GetAverage(double[] sequence)
        {
            double average = sequence.Average();

            return average;
        }
    }
}
