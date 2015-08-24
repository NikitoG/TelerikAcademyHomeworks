//Problem 9. Matrix of Numbers

//Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix like in the examples below. Use two nested loops.

using System;

class Matrix
{
    static void Main()
    {
        byte n;
        do
        {
            Console.Write("Enter a positive integer number: ");
        } while (!byte.TryParse(Console.ReadLine(), out n) && n > 0);

        for (int i = 1; i <= n; i++)
        {
            for (int j = i; j < (i + n); j++)
            {
                Console.Write("{0, 3}", j);
            }
            Console.WriteLine();
        }
    }
}
