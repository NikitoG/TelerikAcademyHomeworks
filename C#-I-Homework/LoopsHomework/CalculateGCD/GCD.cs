//Problem 17.* Calculate GCD

//Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
//Use the Euclidean algorithm (find it in Internet).

using System;

class GCD
{
    static void Main()
    {
        int a;
        do
        {
            Console.Write("Enter first Number: ");
        } while (!int.TryParse(Console.ReadLine(), out a));
        int b;
        do
        {
            Console.Write("Enter second Number: ");
        } while (!int.TryParse(Console.ReadLine(), out b));
        int greaterNum = Math.Abs(a);
        int lowerNum = Math.Abs(b);
        int step = lowerNum;
        if (a == 0)
        {
            Console.WriteLine("GCD({1}, {0}) -> {0}", b, a);
        }
        else if (b == 0 || a == b)
        {
            Console.WriteLine("GCD({0}, {1}) -> {0}", a, b);
        }
        else
        {
            if (Math.Abs(b) > Math.Abs(a))
            {
                greaterNum = b;
                lowerNum = a;
            }
            do
            {
                step = lowerNum;
                lowerNum = greaterNum % lowerNum;
                greaterNum = step;
            } while (lowerNum != 0);

            Console.WriteLine("GCD({0}, {1}) -> {2}", a, b, greaterNum);
            
        }
    }
}
