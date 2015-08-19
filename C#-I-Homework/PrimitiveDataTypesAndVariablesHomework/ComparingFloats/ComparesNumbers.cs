//Problem 13.* Comparing Floats

//Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.

using System;

class ComparesNumbers
{
    static void Main()
    {
        decimal eps = 0.000001M;

        Console.WriteLine("a=");
        decimal a = decimal.Parse(Console.ReadLine());
        Console.WriteLine("b=");
        decimal b = decimal.Parse(Console.ReadLine());

        bool comparingFloat = Math.Abs(a - b) < eps;
        Console.WriteLine("Equal (with precision eps=0.000001) -> " + comparingFloat);
    }
}
