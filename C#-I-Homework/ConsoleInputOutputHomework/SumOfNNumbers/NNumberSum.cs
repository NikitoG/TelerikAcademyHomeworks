//Problem 9. Sum of n Numbers

//Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum.

using System;

class NNumberSum
{
    static void Main(string[] args)
    {
        byte n;
        do
        {
            Console.Write("Enter a ineger number: ");
        } while (!byte.TryParse(Console.ReadLine(), out n));

        double sum = 0;
        for (int i = 1; i <= n; i++)
        {
            Console.Write("Enter number {0}: ", i);
            sum += double.Parse(Console.ReadLine());
        }

        Console.WriteLine("Sum: " + sum);
    }
}
