//Problem 9. Print a Sequence
//Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

using System;
using System.Collections.Generic;
using System.Linq;

class Sequence
{
    static void Main()
    {
        IEnumerable<int> sequence = Enumerable.Range(2, 10);

        foreach (int num in sequence)
        {
            if (num % 2 == 0)
                Console.Write(num + ", ");
            else
                Console.Write(-num + ", ");
        }
    }
}
