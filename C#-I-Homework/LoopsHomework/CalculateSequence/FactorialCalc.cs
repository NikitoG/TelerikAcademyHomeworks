//Problem 5. Calculate 1 + 1!/X + 2!/X^2 + … + N!/X^N

//Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n.
//Use only one loop. Print the result with 5 digits after the decimal point.

using System;

class FactorialCalc
{
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Input 'n': ");
        } while (!int.TryParse(Console.ReadLine(), out n));
        int x;
        do
        {
            Console.Write("Input 'x': ");
        } while (!int.TryParse(Console.ReadLine(), out x));

        double sum = 1.0;
        int factorial = 1;
        int pow = 1;
        for (int i = 1; i <=n; i++)
        {
            factorial *= i;
            pow *= x;
            sum += (double)factorial/pow;
        }
        Console.WriteLine("{0:F5}", sum);
    }
}
