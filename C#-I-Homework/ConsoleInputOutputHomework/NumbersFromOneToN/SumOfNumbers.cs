//Problem 8. Numbers from 1 to n

//Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.

using System;

class SumOfNumbers
{
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Enter an integer number: ");
        } while (!int.TryParse(Console.ReadLine(), out n));

        if (n >= 1)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            for (int i = 1; i >= n; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}