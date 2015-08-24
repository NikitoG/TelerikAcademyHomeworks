//Problem 6. Calculate N! / K!

//Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
//Use only one loop.

using System;
using System.Numerics;

class FactorialDividedFactorial
{
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Input 'n': ");
        } while (!int.TryParse(Console.ReadLine(), out n));
        int k;
        do
        {
            Console.Write("Input 'k': ");
        } while (!int.TryParse(Console.ReadLine(), out k));

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;
        if (( 1 < k) && (k < n) && (n < 100))
        {
            for (int i = 1; i <= n; i++)
            {
                if (i <= k)
                {
                    factorialK *= (BigInteger)i;
                }
                factorialN *= (BigInteger)i;
            }
            Console.WriteLine(factorialN/factorialK);
        }
        else
        {
            Console.WriteLine("Wrong input!");
        }
    }
}