namespace ReverseGivenSequence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        //Write a program that reads N integers from the console and reverses them using a stack.

        //Use the Stack<int> class.

        public static void Main()
        {
            Console.WriteLine("Enter n: ");
            var n = int.Parse(Console.ReadLine());
            var sequence = new Stack<int>();

            Console.WriteLine("Enter {0} numbers: ", n);

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sequence.Push(number);
            }
            
            Console.WriteLine("Reversed: {0}", string.Join(", ", sequence));
        }
    }
}
