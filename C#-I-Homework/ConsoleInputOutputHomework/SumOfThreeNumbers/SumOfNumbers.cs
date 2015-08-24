//Problem 1. Sum of 3 Numbers

//Write a program that reads 3 real numbers from the console and prints their sum.

using System;

class SumOfNumbers
{
    static void Main()
    {
        double numberA;
        do
        {
            Console.WriteLine("Enter a real number a = ");
        } while (!(double.TryParse(Console.ReadLine(), out numberA)));

        double numberB;
        do
        {
            Console.WriteLine("Enter a real number b = ");
        } while (!(double.TryParse(Console.ReadLine(), out numberB)));

        double numberC;
        do
        {
            Console.WriteLine("Enter a real number c = ");
        } while (!(double.TryParse(Console.ReadLine(), out numberC)));

        double sum = numberA + numberB + numberC;
        Console.WriteLine("{0} + {1} + {2} = {3}", numberA, numberB, numberC, sum);
    }
}