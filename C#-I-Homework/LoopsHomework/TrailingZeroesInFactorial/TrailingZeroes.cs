//Problem 18.* Trailing Zeroes in N!

//Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
//Your program should work well for very big numbers, e.g. n=100000.

using System;
using System.Numerics;

class TrailingZeroes
{
    static void Main()
    {
        long n;
        do
        {
            Console.WriteLine("Enter a number :");
        } while (!long.TryParse(Console.ReadLine(), out n));

        //BigInteger factorialN = 1;
        //for (int i  = 1; i <= n; i ++)
        //{
        //    factorialN *= i;
        //}
        //long count = 0;
        //BigInteger divisor = 10;
        //while (factorialN % divisor == 0)
        //{
        //    ++count;
        //    divisor *= 10;
        //}
        //Console.WriteLine(count);

        int primeFactor = 5;
        int count = 0;
        while (n >= primeFactor )
        {
            ++count;
            primeFactor *= 5;
        }
        long trailingZeroes = 0;
        for (int k = 1; k <= count; k++)
        {
            trailingZeroes += n / (long)Math.Pow(5, k);
        }
        Console.WriteLine("Trailing zeroes of {0}! -> {1}", n,trailingZeroes);
    }
}
