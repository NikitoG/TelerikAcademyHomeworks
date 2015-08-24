//Problem 4. Maximal sequence

//Write a program that finds the maximal sequence of equal elements in an array.

using System;
using System.Linq;

class MaxSequence
{
    static void Main()
    {
        Console.Write("Enter a integer separated by space: ");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int sequenceLength = 1;
        int maxSequnce = 1;
        int startPosition = 0;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] == numbers[i + 1])
            {
                ++sequenceLength;
                if (sequenceLength > maxSequnce)
                {
                    maxSequnce = sequenceLength;
                    startPosition = i + 2 - sequenceLength;
                }
            }
            else
            {
                
                sequenceLength = 1;
            }
        }
        if (maxSequnce > 1)
        {
            Console.WriteLine("Maximal sequnce of equal elements is {0} and start from {1} position!!!", maxSequnce, startPosition);
        }
        else
        {
            Console.WriteLine("In this array don't have equal elements!");
        }
    }
}
