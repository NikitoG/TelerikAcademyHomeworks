namespace CalculateSumAndAverageSequance
{
    using System;
    using System.Collections.Generic;

    //Write a program that reads from the console a sequence of positive integer numbers.

    //The sequence ends when empty line is entered.
    //Calculate and print the sum and average of the elements of the sequence.
    //Keep the sequence in List<int>.

    public class Startup
    {
        public static void Main()
        {
            var sequence = new List<int>();

            var sum = 0;
            while (true)
            {
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    var number = int.Parse(input);

                    sequence.Add(number);
                    sum += number;
                }
                else
                {
                    Console.WriteLine(string.Join(", ", sequence));
                    Console.WriteLine("Sum: {0}", sum);
                    Console.WriteLine("Average: {0}", sum / sequence.Count);
                    break;
                }
            }
        }
    }
}
