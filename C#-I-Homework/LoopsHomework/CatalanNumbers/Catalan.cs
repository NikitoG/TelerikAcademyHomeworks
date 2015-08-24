//Problem 8. Catalan Numbers

//In combinatorics, the Catalan numbers are calculated by the following formula: catalan-formula
//Write a program to calculate the nth Catalan number by given n (0 ≤ n ≤ 100).

using System;
using System.Numerics;

class Catalan
{
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Input 'n': ");
        } while (!int.TryParse(Console.ReadLine(), out n));

        BigInteger factorialN = 1;
        BigInteger factorialNOne = 1;
        BigInteger factorialaNTwo = 1;

        BigInteger catalan;

        for (int i = 1; i <= (2*n); i++)
        {
            if (i <= n)
            {
                factorialN *= i;
            }
            if (i <= (n + 1))
            {
                factorialNOne *= i;
            }
            factorialaNTwo *= i;
        }

        catalan = factorialaNTwo / (factorialN * factorialNOne);
        Console.WriteLine("N-th Catalan -> {0}", catalan);
    }
}
