//Problem 16.* Print Long Sequence
//Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …
//You might need to learn how to use loops in C# (search in Internet).

using System;
using System.Collections.Generic;
using System.Linq;

class LongSequence
{
    static void Main()
    {
        IEnumerable<int> longSequence = Enumerable.Range(2, 1000);

        foreach (int number in longSequence)
        {
            if (number % 2 == 0)
                Console.Write(number + ", ");
            else
                Console.Write(-number + ", ");
        }
    }
}