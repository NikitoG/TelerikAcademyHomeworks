//Problem 15. Prime numbers

//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.

using System;
using System.Collections.Generic;
using System.Linq;

class Prime
{
    static void Main(string[] args)
    {
        int N = 10000000;
        List<int> primeNumbers = new List<int>();
        primeNumbers.Add(2);
        bool isPrime = true;
        for (int i = 3; i <= N; i += 2)
        {
            isPrime = true;
            for (int j = 0; j < Math.Sqrt(primeNumbers.Count); j++)
            {
                if (i % primeNumbers[j] == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                primeNumbers.Add(i);
            }
        }

        Console.WriteLine(string.Join(", ", primeNumbers));
    }
}

