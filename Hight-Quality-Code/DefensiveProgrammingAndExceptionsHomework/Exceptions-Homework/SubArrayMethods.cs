namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class SubArrayMethods
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array cannot be null!");
            }

            if (startIndex < 0 || arr.Length <= startIndex)
            {
                throw new ArgumentOutOfRangeException(string.Format("Start index must be in a range between 0 and {0}", arr.Length - 1));
            }

            if (count < 0 || (arr.Length - startIndex) < count)
            {
                throw new ArgumentOutOfRangeException(string.Format("Count must be in a range between 1 and {0}", arr.Length - startIndex));
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (str == null)
            {
                throw new ArgumentNullException("String cannot be null!");
            }

            if (str.Length == 0)
            {
                throw new ArgumentOutOfRangeException("String cannot be empty!");
            }

            if (count < 0 || count > str.Length)
            {
                throw new ArgumentOutOfRangeException(string.Format("Count must be in a range between 1 and {0}", str.Length));
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }
    }
}
