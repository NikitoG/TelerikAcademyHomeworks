//Problem 5. Maximal increasing sequence

//Write a program that finds the maximal increasing sequence in an array.

using System;
using System.Linq;

class MaxIncreasingSequence
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
            if (numbers[i] < numbers[i + 1])
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
            int[] newArray = new int[maxSequnce];
            Console.Write("Maximal increasing sequence is: ");
            for (int i = startPosition; i < startPosition + maxSequnce; i++)
            {
                newArray[i - startPosition] = numbers[i];
            }
            Console.WriteLine(string.Join(", ", newArray));
            Console.WriteLine("Start from  position {0}!!!", startPosition);
        }
        else
        {
            Console.WriteLine("This array doesn't have increasing numbers!");
        }
    }
}

