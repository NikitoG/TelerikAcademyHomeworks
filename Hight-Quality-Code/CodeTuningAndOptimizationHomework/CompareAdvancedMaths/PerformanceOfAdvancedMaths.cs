namespace CompareAdvancedMaths
{
    using System;
    using System.Diagnostics;

    public class PerformanceOfAdvancedMaths
    {
        private const int NumberOfIteration = 5000000;
        private static readonly string[] NumberType = 
                                                        {
                                                            "-----Float!-----", 
                                                            "-----Double!-----", 
                                                            "-----Decimal!-----" 
                                                        };

        private static readonly string[] OperationsType = 
                                                        {
                                                            "-----Square root!-----", 
                                                            "-----Natural logarithm!-----", 
                                                            "-----Sinus!-----" 
                                                        };

        public static void Main()
        {
            float floatNumber = 1.0f;
            double doubleNumber = 1.0d;
            decimal decimalNumber = 1.0M;

            Console.WriteLine(NumberType[0]);
            ComparePerformance(floatNumber);
            Console.WriteLine();

            Console.WriteLine(NumberType[1]);
            ComparePerformance(doubleNumber);
            Console.WriteLine();

            Console.WriteLine(NumberType[2]);
            ComparePerformance(decimalNumber);
        }

        private static void ComparePerformance(dynamic number)
        {
            var stopWatch = new Stopwatch();
            Console.WriteLine(OperationsType[2]);
            stopWatch.Start();

            for (int i = 0; i < NumberOfIteration; i++)
            {
                Math.Sin((double)number);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Reset();
            Console.WriteLine(OperationsType[0]);
            stopWatch.Start();
            for (int i = 0; i < NumberOfIteration; i++)
            {
                Math.Sqrt((double)number);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Reset();
            Console.WriteLine(OperationsType[1]);
            stopWatch.Start();

            for (int i = 0; i < NumberOfIteration; i++)
            {
                Math.Log((double)number);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
        }
    }
}
