//Problem 11. Random Numbers in Given Range

//Write a program that enters 3 integers n, min and max (min != max) and prints n random numbers in the range [min...max].

using System;

class RandomNumbers
{
    static void Main()
    {
        uint n;
        do
        {
            Console.Write("Enter n: ");
        } while (!uint.TryParse(Console.ReadLine(), out n) && n > 0);

        int min;
        do
        {
            Console.Write("Enter min: ");
        } while (!int.TryParse(Console.ReadLine(), out min));

        int max;
        do
        {
            Console.Write("Enter max: ");
        } while (!int.TryParse(Console.ReadLine(), out max) && min != max);

        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", rnd.Next(min, (max+1)));
        }
    }
}
