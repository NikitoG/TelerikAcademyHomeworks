//Problem 6. Maximal K sum

//Write a program that reads two integer numbers N and K and an array of N elements from the console.
//Find in the array those K elements that have maximal sum.

using System;
using System.Linq;
using System.Collections.Generic;

class MaxKSum
{
    static void Main()
    {
        int N;
        do
        {
            Console.Write("Enter N: ");
        } while (!(int.TryParse(Console.ReadLine(), out N) && N >= 0));
        int K;
        do
        {
            Console.Write("Enter K: ");
        } while (!(int.TryParse(Console.ReadLine(), out K) && K > 0));

        int[] numbers = new int[N];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int sum = 0;
        List<int> maxSum = new List<int>();
        int index = 0;
        int minValue = int.MaxValue;
        int minIndex = -1;
        if (K >= N)
        {
            Console.WriteLine("K >= N");
            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine("Max sum = {0}", numbers.Sum());
        }
        else
        {
            for (int i = 0; i < K; i++)
            {
                maxSum.Add(numbers[i]);
            }
            for (int i = maxSum.Count; i < numbers.Length; i++)
            {
                index = -1;
                minValue = int.MaxValue;
                minIndex = -1;
                foreach (int num in maxSum)
                {
                    index++;

                    if (num <= minValue)
                    {
                        minValue = num;
                        minIndex = index;
                    }
                }
                if (numbers[i] >= minValue)
                {
                    maxSum.Add(numbers[i]);
                    maxSum.RemoveAt(minIndex);
                }

            }
            Console.WriteLine(string.Join(", ", maxSum));
            Console.WriteLine("Max sum = {0}", maxSum.Sum());
        }

    }
}
