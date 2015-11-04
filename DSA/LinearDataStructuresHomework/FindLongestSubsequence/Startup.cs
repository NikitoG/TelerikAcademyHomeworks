namespace FindLongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        //Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.

        //Write a program to test whether the method works correctly.

        public static void Main()
        {
            var sequence = new List<int>() { 1, 1, 2, 2, 5, 5, 5, 5, 5, 3, 5, 5};

            var longestSubsequence = FindLongestSubsequenceOfEqualNumbers(sequence);
            Console.WriteLine(string.Join(", ", longestSubsequence));
        }

        public static List<int> FindLongestSubsequenceOfEqualNumbers(List<int> sequence)
        {
            var equalNumbersCount = 1;
            var longestsubsequence = 1;
            var repeatedNumbers = sequence[0];

            for (int i = 0; i < sequence.Count - 1; i++)
            {
                if(sequence[i] == sequence[i + 1])
                {
                    equalNumbersCount++;
                }
                else
                {
                    if (equalNumbersCount > longestsubsequence)
                    {
                        longestsubsequence = equalNumbersCount;
                        repeatedNumbers = sequence[i];
                    }

                    equalNumbersCount = 1;
                }
            }

            var result = new List<int>();

            for (int i = 0; i < longestsubsequence; i++)
            {
                result.Add(repeatedNumbers);
            }

            return result;
        }
    }
}