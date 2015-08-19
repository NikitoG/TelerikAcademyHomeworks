//Problem 11.* Numbers in Interval Dividable by Given Number

//Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0.

using System;

class DividablebyGivenNumber
{
    static void Main()
    {
        ulong start;
        do
        {
            Console.Write("Enter a positive integer numbers for start: ");
        } while(!ulong.TryParse(Console.ReadLine(), out start));

        ulong end;
        do
        {
            Console.Write("Enter a positive integer numbers for end: ");
        } while (!(ulong.TryParse(Console.ReadLine(), out end) && end > start));

        byte divider = 5;
        uint p = 0;

        for (ulong i = start; i <= end; i++)
        {
            if (i % divider == 0)
            {
                ++p;
                Console.Write("{0}, ", i);
            }
        }
        Console.WriteLine("Numbers between {0} and {1} dividableby by {2} is : {3}", start, end, divider, p);
    }
}