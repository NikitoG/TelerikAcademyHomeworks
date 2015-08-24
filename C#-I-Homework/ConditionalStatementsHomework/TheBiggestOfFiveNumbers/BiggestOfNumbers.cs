//Problem 6. The Biggest of Five Numbers

//Write a program that finds the biggest of five numbers by using only five if statements.

using System;

class BiggestOfNumbers
{
    static void Main()
    {
        double a;
        do
        {
            Console.Write("Write a number a:");
        } while (!double.TryParse(Console.ReadLine(), out a));

        double b;
        do
        {
            Console.Write("Write a number b:");
        } while (!double.TryParse(Console.ReadLine(), out b));

        double c;
        do
        {
            Console.Write("Write a number c:");
        } while (!double.TryParse(Console.ReadLine(), out c));

        double d;
        do
        {
            Console.Write("Write a number d:");
        } while (!double.TryParse(Console.ReadLine(), out d));

        double e;
        do
        {
            Console.Write("Write a number e:");
        } while (!double.TryParse(Console.ReadLine(), out e));

        double biggestNum = a;
        if (biggestNum < b)
        {
            biggestNum = b;
        }
        if (biggestNum < c)
        {
            biggestNum = c;
        }
        if (biggestNum < d)
        {
            biggestNum = d;
        }
        if (biggestNum < e)
        {
            biggestNum = e;
        }

        Console.WriteLine("From {0}, {1}, {2}, {3} and {4} the biggest is: {5}",
            a, b, c, d, e, biggestNum);
    }
}
