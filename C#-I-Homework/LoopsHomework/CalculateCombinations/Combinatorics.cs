//Problem 7. Calculate N! / (K! * (N-K)!)

//In combinatorics, the number of ways to choose k different members out of a group of n different elements (also known as the number of combinations) is calculated by the following formula: formula For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
//Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops.

using System;
using System.Numerics;

class Combinatorics
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
        BigInteger factorialNK = 1;
        if ((1 < k) && (k < n) && (n < 100))
        {
            for (int i = 1; i <= n; i++)
            {
                if (i <= k)
                {
                    factorialK *= i;
                }
                factorialN *= i;
            }
            for (int j = 1; j <= (n -k); j++)
            {
                factorialNK *= j;
            }

            Console.WriteLine(factorialN / (factorialK * factorialNK) );
        }
        else
        {
            Console.WriteLine("Wrong input!");
        }
    }
}
