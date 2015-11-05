namespace CountValue
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        // Problem 1. Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
        public static void Main()
        {
            var numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var numberCounts = new Dictionary<double, int>();

            foreach (var num in numbers)
            {
                if (!numberCounts.ContainsKey(num))
                {
                    numberCounts[num] = 0;
                }

                numberCounts[num]++;
            }

            foreach (var pair in numberCounts)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
