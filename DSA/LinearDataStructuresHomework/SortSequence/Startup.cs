namespace SortSequence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        // Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.

        public static void Main()
        {
            var sequence = new List<int>();

            var sum = 0;
            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                var number = int.Parse(input);

                sequence.Add(number);
            }

            sequence.Sort();

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
