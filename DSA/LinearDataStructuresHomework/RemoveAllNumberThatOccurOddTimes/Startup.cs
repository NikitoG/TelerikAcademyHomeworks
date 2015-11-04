namespace RemoveAllNumberThatOccurOddTimes
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        // Write a program that removes from given sequence all numbers that occur odd number of times.

        public static void Main()
        {
            var sequence = new LinkedList<int>(new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 });

            Console.WriteLine(string.Join(", ", sequence));

            RemoveNumberThatOccurOddTimes(sequence);

            Console.WriteLine(string.Join(", ", sequence));
        }

        public static void RemoveNumberThatOccurOddTimes(LinkedList<int> sequence)
        {
            Dictionary<int, int> countNumbers = new Dictionary<int, int>();

            foreach (var number in sequence)
            {
                if (!countNumbers.ContainsKey(number))
                {
                    countNumbers[number] = 0;
                }

                countNumbers[number]++;
            }


            var currentNumber = sequence.First;
            while (currentNumber != null)
            {

                if (countNumbers[currentNumber.Value] % 2 != 0)
                {
                    var toRemove = currentNumber;
                    currentNumber = currentNumber.Next;
                    sequence.Remove(toRemove);
                }
                else
                {
                    currentNumber = currentNumber.Next;
                }
            }
        }
    }
}
