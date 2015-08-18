namespace CompareSortAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class TestSelectionMethods
    {
        private const int NumberCheckArray = 3;
        private const int NumberOfSortMethods = 3;
        private static readonly string[] CompareType = 
                                                        {
                                                            "-----Unsorted array!-----", 
                                                            "-----Sorted array!-----", 
                                                            "-----Reversed array!-----" 
                                                        };

        private static readonly string[] TypeArray = 
                                                    { 
                                                         "---------------Integers!---------------", 
                                                         "---------------Double Numbers!---------------",
                                                         "---------------Strings!---------------" 
                                                     };

        public static void Main(string[] args)
        {
            var arrayOfIntegers = new int[3][];
            var arrayOfDouble = new double[3][];
            var arrayOfString = new string[3][];

            arrayOfIntegers[0] = new int[500];
            arrayOfDouble[0] = new double[500];
            arrayOfString[0] = new string[500];

            for (int i = 0; i < arrayOfIntegers[0].Length; i++)
            {
                arrayOfIntegers[0][i] = GetRandom.IntegerNumber(-100, 100);
                arrayOfDouble[0][i] = GetRandom.DoubleNumber(-100d, 100d);
                arrayOfString[0][i] = GetRandom.CharSequence(5);
            }

            arrayOfIntegers[1] = arrayOfIntegers[0].ToList<int>().OrderBy(s => s).ToArray();
            arrayOfDouble[1] = arrayOfDouble[0].ToList<double>().OrderBy(s => s).ToArray();
            arrayOfString[1] = arrayOfString[0].ToList<string>().OrderBy(s => s).ToArray();

            arrayOfIntegers[2] = arrayOfIntegers[0].ToList<int>().OrderByDescending(s => s).ToArray();
            arrayOfDouble[2] = arrayOfDouble[0].ToList<double>().OrderByDescending(s => s).ToArray();
            arrayOfString[2] = arrayOfString[0].ToList<string>().OrderByDescending(s => s).ToArray();

            Console.WriteLine(TypeArray[0]);
            for (int j = 0; j < NumberCheckArray; j++)
            {
                Console.WriteLine(CompareType[j]);
                for (int k = 0; k < NumberOfSortMethods; k++)
                {
                    var sortMethods = (SortingAlgorithms)k;
                    CompareSortrAlgorithm(sortMethods, (int[])arrayOfIntegers[j].Clone());
                }
            }

            Console.WriteLine();

            Console.WriteLine(TypeArray[1]);
            for (int j = 0; j < NumberCheckArray; j++)
            {
                Console.WriteLine(CompareType[j]);
                for (int k = 0; k < NumberOfSortMethods; k++)
                {
                    var sortMethods = (SortingAlgorithms)k;
                    CompareSortrAlgorithm(sortMethods, (double[])arrayOfDouble[j].Clone());
                }
            }

            Console.WriteLine();

            Console.WriteLine(TypeArray[2]);
            for (int j = 0; j < NumberCheckArray; j++)
            {
                Console.WriteLine(CompareType[j]);
                for (int k = 0; k < NumberOfSortMethods; k++)
                {
                    var sortMethods = (SortingAlgorithms)k;
                    CompareSortrAlgorithm(sortMethods, (string[])arrayOfString[j].Clone());
                }
            }

            Console.WriteLine();
        }

        internal static void CompareSortrAlgorithm<T>(SortingAlgorithms type, T[] inputArray) where T : IComparable
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            switch (type)
            {
                case SortingAlgorithms.SelectionSort:
                    SortingMethods.SelectionSort(inputArray);
                    Console.Write("Selection sort: ");
                    break;
                case SortingAlgorithms.QuickSort:
                    SortingMethods.Quicksort(inputArray, 0, inputArray.Length - 1);
                    Console.Write("Quick sort: ");
                    break;
                case SortingAlgorithms.InsertionSort:
                    SortingMethods.InsertionSort(inputArray);
                    Console.Write("Insertion sort: ");
                    break;
                default:
                    break;
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
        }
    }
}
