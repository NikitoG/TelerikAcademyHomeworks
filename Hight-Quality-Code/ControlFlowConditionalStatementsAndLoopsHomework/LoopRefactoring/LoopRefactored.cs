namespace LoopRefactoring
{
    using System;

    public class LoopRefactored
    {
        public static void FoundValue(int[] numbers, int expectedValue)
        {
            /*
            int i = 0;
            for (i = 0; i < 100; )
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(numbers[i]);
                    if (numbers[i] == expectedValue)
                    {
                        i = 666;
                    }
                    i++;
                }
                else
                {
                    Console.WriteLine(numbers[i]);
                    i++;
                }
            }
            // More code here
            if (i == 666)
            {
                Console.WriteLine("Value Found");
            }   */

            for (int index = 0; index < numbers.Length; index++)
            {
                Console.WriteLine(numbers[index]);
                if (index % 10 == 0)
                {
                    if (numbers[index] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }
                }
            }
        }
    }
}