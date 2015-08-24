//Problem 2. Numbers Not Divisible by 3 and 7

//Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n not divisible by 3 and 7, on a single line, separated by a space.

using System;

class NumbersNotDivisibleBy
{
    static void Main()
    {
        uint number;
        do
        {
            Console.Write("Enter a positive integer: ");
        } while (!uint.TryParse(Console.ReadLine(), out number));

        uint dividerOne = 3;
        uint dividerTwo = 7;
        for (int i = 1; i <= number; i++)
        {
            if ((i % dividerOne != 0) && (i % dividerTwo != 0))
            {
                Console.Write("{0} ", i);
            }

        }
        Console.WriteLine();
    }
}
