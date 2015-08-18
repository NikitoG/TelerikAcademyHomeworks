namespace CompareSortAlgorithms
{
    using System;
    using System.Collections.Generic;

    internal class SortingMethods
    {
        // http://codereview.stackexchange.com/questions/59968/performing-insertion-sort-in-c
        public static void InsertionSort<T>(T[] inputArray, Comparer<T> comparer = null)
        {
            var equalityComparer = comparer ?? Comparer<T>.Default;
            for (var counter = 0; counter < inputArray.Length - 1; counter++)
            {
                var index = counter + 1;
                while (index > 0)
                {
                    if (equalityComparer.Compare(inputArray[index - 1], inputArray[index]) > 0)
                    {
                        var oldValue = inputArray[index - 1];
                        inputArray[index - 1] = inputArray[index];
                        inputArray[index] = oldValue;
                    }

                    index--;
                }
            }
        }

        // http://snipd.net/quicksort-in-c
        public static void Quicksort<T>(T[] inputArray, int left, int right) where T : IComparable
        {
            int i = left, j = right;
            T pivot = inputArray[(left + right) / 2];

            while (i <= j)
            {
                while (inputArray[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (inputArray[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    T oldValue = inputArray[i];
                    inputArray[i] = inputArray[j];
                    inputArray[j] = oldValue;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(inputArray, left, j);
            }

            if (i < right)
            {
                Quicksort(inputArray, i, right);
            }
        }

        // http://mattrank.net/2012/01/selection-sort-in-c/
        public static void SelectionSort<T>(T[] inputArray) where T : IComparable
        {
            var indexMinElement = 0;

            for (var i = 0; i < inputArray.Length - 1; i++)
            {
                indexMinElement = i;

                for (var j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[j].CompareTo(inputArray[indexMinElement]) < 0)
                    {
                        indexMinElement = j;
                    }
                }

                var oldValue = inputArray[i];
                inputArray[i] = inputArray[indexMinElement];
                inputArray[indexMinElement] = oldValue;
            }
        }
    }
}
