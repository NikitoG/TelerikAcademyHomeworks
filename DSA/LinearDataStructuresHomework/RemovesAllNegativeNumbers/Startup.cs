namespace RemovesAllNegativeNumbers
{
    using System;
    using System.Collections.Generic;


    public class Startup
    {
        // Write a program that removes from given sequence all negative numbers.


        public static void Main()
        {
            var sequence = new LinkedList<int> (new int[] {1, -1, -2, 2, -5, 5, 5, -5, 5, -3, 5, 5});

            Console.WriteLine(string.Join(", ", sequence));

            RemovesNegativeNumbers(sequence);

            Console.WriteLine(string.Join(", ", sequence));
        }

        public static  void RemovesNegativeNumbers(LinkedList<int> sequence)
        {
            var currentNumber = sequence.First;
            while(currentNumber != null)
            {

                if (currentNumber.Value < 0)
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
