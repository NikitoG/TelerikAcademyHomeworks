namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Startup
    {

        //We are given numbers N and M and the following operations:

        //N = N+1
        //N = N+2
        //N = N*2

        //Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.

        //Hint: use a queue.
        //Example: N = 5, M = 16
        //Sequence: 5 → 7 → 8 → 16

        public static void Main()
        {
            Console.Write("Enter sequence start: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Enter sequence end: ");
            int end = int.Parse(Console.ReadLine());

            FindShortestSequenceOfOperations(start, end);
        }

        public static void FindShortestSequenceOfOperations(int start, int end)
        {
            Stack<int> sequance = new Stack<int>();
            int currentNumber = end;
            sequance.Push(currentNumber);
            if(currentNumber % 2 != 0 && currentNumber / 2 > start && currentNumber - 2 != start)
            {
                currentNumber--;
                sequance.Push(currentNumber);
            }

            while (currentNumber > start)
            {
                if (currentNumber % 2 == 0 && currentNumber / 2 >= start)
                {
                    currentNumber /= 2;
                    sequance.Push(currentNumber);
                }
                else if (currentNumber % 2 == 1 && currentNumber / 2 >= start)
                {
                    currentNumber -= 1;
                    sequance.Push(currentNumber);
                }
                else if (currentNumber - 2 >= start)
                {
                    currentNumber -= 2;
                    sequance.Push(currentNumber);
                }
                else if (currentNumber - 1 >= start)
                {
                    currentNumber -= 1;
                    sequance.Push(currentNumber);
                }
            }

            Console.WriteLine(string.Join(", ", sequance));
        }
    }
}
