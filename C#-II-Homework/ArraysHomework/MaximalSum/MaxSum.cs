//Problem 8. Maximal sum

//Write a program that finds the sequence of maximal sum in given array.

using System;
using System.Collections.Generic;
using System.Linq;

class MaxSum
{
    static void Main()
    {
        int N;
        do
        {
            Console.Write("Enter N: ");
        } while (!(int.TryParse(Console.ReadLine(), out N) && N >= 0));

        int[] numbers = new int[N];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());

        }
        if (numbers.Min() > 0)
        {
            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine("sum = {0}", numbers.Sum());
        }
        else if (numbers.Max() <= 0)
        {
            Console.WriteLine(numbers.Max());
            Console.WriteLine("sum = {0}", numbers.Max());
        }
        else
        {

            int tempSum = 0;
            int maxSum = 0;
            string bestSeqquence = "";
            List<int> currentSeqquence = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                currentSeqquence.Add(numbers[i]);
                tempSum += numbers[i];
                if (tempSum > maxSum)
                {
                    bestSeqquence = string.Join(", ", currentSeqquence);
                    maxSum = tempSum;
                }
                else if(tempSum < 0)
                {
                    tempSum = 0;
                    currentSeqquence.Clear();
                }
            }
            Console.WriteLine(bestSeqquence);
            Console.WriteLine("sum = {0}", maxSum);
        }
    }
}