namespace PrintSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //We are given the following sequence:

    //S1 = N;
    //S2 = S1 + 1;
    //S3 = 2*S1 + 1;
    //S4 = S1 + 2;
    //S5 = S2 + 1;
    //S6 = 2*S2 + 1;
    //S7 = S2 + 2;
    //...
    //Using the Queue<T> class write a program to print its first 50 members for given N.
    //Example: N=2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

    public class Startup
    {
        private const int firstNNumbers = 50;

        public static void Main()
        {
            Console.WriteLine("Enter a number: ");
            int n = int.Parse(Console.ReadLine());

            PrintSequence(n);
        }

        public static void PrintSequence(int n)
        {
            var sequence = new Queue<int>();

            sequence.Enqueue(n);
            for (int i = 0; i < firstNNumbers; i++)
            {
                sequence.Enqueue(sequence.First() + 1);
                sequence.Enqueue(sequence.First() * 2 + 1);
                sequence.Enqueue(sequence.First() + 2);
                Console.WriteLine(sequence.Dequeue());
            }
        }
    }
}
