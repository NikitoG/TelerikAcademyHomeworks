namespace FindNumbersOccurences
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        //Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.

        public static void Main()
        {
            var numbers = new int[9] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            FindOccurances(numbers);
        }

        public static void FindOccurances(int[] numbers)
        {
            var occurances = new int[1000];

            foreach (var number in numbers)
            {
                occurances[number]++;
            }

            for (int i = 0; i < occurances.Length; i++)
            {
                if (occurances[i] != 0)
                {
                    Console.WriteLine("{0} -> {1} times", i, occurances[i]);
                }
            }
        }
    }
}
