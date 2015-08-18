namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    internal class SearchingMethods
    {
        internal static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array could not be null!");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, string.Format("Start index must be between 0 and {0}!", arr.Length - 1));
            Debug.Assert(endIndex == arr.Length - 1, string.Format("End index must be exactly {0}!", arr.Length - 1));

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    Debug.Assert(arr[midIndex].CompareTo(value) == 0, "Incorrect index!");
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            Debug.Assert(AssertionsHelperMethods.HasElement(arr, value), "The array has searched value!");

            // Searched value not found
            return -1;
        }
    }
}
