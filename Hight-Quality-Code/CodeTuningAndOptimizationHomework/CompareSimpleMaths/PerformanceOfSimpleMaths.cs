namespace CompareSimpleMaths
{
    using System;
    using System.Diagnostics;

    public class PerformanceOfSimpleMaths
    {
        private static readonly string[] NumberType = 
                                                        {
                                                            "-----Integer!-----", 
                                                            "-----Long!-----", 
                                                            "-----Float!-----", 
                                                            "-----Double!-----", 
                                                            "-----Decimal!-----" 
                                                        };

        private static readonly string[] OperationsType = 
                                                        {
                                                            "-----Add!-----", 
                                                            "-----Substract!-----", 
                                                            "-----Increment!-----", 
                                                            "-----Multiply!-----", 
                                                            "-----Divide!-----" 
                                                        };

        public static void Main()
        {
            int integerNumber = 1;
            long longNumber = 1L;
            float floatNumber = 1.0f;
            double doubleNumber = 1.0d;
            decimal decimalNumber = 1.0M;

            Console.WriteLine(NumberType[0]);
            ComparePerformance(integerNumber);
            Console.WriteLine();

            Console.WriteLine(NumberType[1]);
            ComparePerformance(longNumber);
            Console.WriteLine();

            Console.WriteLine(NumberType[2]);
            ComparePerformance(floatNumber);
            Console.WriteLine();

            Console.WriteLine(NumberType[3]);
            ComparePerformance(doubleNumber);
            Console.WriteLine();

            Console.WriteLine(NumberType[4]);
            ComparePerformance(decimalNumber);
            Console.WriteLine();
        }

        private static void ComparePerformance(dynamic number)
        {
            for (int i = 0; i < OperationsType.Length; i++)
            {
                Console.WriteLine(OperationsType[i]);
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                switch (i)
                {
                    case 0:
                        SimpleMathOperations.Add(number);
                        break;
                    case 1:
                        SimpleMathOperations.Substract(number);
                        break;
                    case 2:
                        SimpleMathOperations.Increment(number);
                        break;
                    case 3:
                        SimpleMathOperations.Multiply(number);
                        break;
                    case 4:
                        SimpleMathOperations.Divide(number);
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                stopWatch.Stop();
                Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            }
        }
    }
}
