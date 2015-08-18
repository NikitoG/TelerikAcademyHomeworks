namespace Assertions_Homework
{
    using System;

    internal class AssertionsHelperMethods
    {
        internal static bool IsSorted<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (arr[i].CompareTo(arr[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool IsMinElement<T>(T[] arr, int index, int startIndex) where T : IComparable<T>
        {
            for (int i = startIndex; i < arr.Length - 1; i++)
            {
                if (arr[i].CompareTo(arr[index]) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool HasElement<T>(T[] arr, T value) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i].CompareTo(value) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
