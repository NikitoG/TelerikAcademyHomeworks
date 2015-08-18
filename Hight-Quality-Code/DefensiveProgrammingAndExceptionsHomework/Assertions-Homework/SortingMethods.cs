namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    internal class SortingMethods
    {
        internal static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array could not be null!");
            Debug.Assert(arr.Length != 0, "Array could not be empty!");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }

            Debug.Assert(AssertionsHelperMethods.IsSorted(arr), "Array is not sorted!");
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array could not be null!");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, string.Format("Start index must be between 0 and {0}!", arr.Length - 1));
            Debug.Assert(endIndex == arr.Length - 1, string.Format("End index must be exactly {0}!", arr.Length - 1));

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert(AssertionsHelperMethods.IsMinElement(arr, minElementIndex, startIndex), string.Format("index of the smallest element is not {0}!", minElementIndex));
            
            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "First value is null!");
            Debug.Assert(y != null, "Second value is null!");
            Debug.Assert(x.GetType() == y.GetType(), "X and y are different type!");

            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
