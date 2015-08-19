//Problem 2. Random numbers

//Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;


namespace RandomNumbers
{
    class RanNum
    {
        static Random rnd = new Random();
        static void Main()
        {
            int min = 100;
            int max = 200;
            int count = 10;
            Console.WriteLine("Ten random integers: ");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(rnd.Next(min, max + 1));
            }
            Console.WriteLine("And ten random floating-point numbers: ");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(rnd.NextDouble()*(max - min) + min);
            }
        }
    }
}
