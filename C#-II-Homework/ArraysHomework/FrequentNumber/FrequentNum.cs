//Problem 9. Frequent number

//Write a program that finds the most frequent number in an array.

using System;
using System.Linq;

class FrequentNum
{
    static void Main()
    {
        int N;
        do
        {
            Console.Write("Enter N: ");
        } while (!(int.TryParse(Console.ReadLine(), out N) && N >= 0));

        int[] numbers = new int[N];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(string.Join(", ", numbers));

        int sequence = 0;
        int maxSequence = 0;
        int num = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sequence = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    ++sequence;
                }
            }
            if (sequence > maxSequence)
            {
                maxSequence = sequence;
                num = numbers[i];
            }
        }
        Console.WriteLine("{0}({1} times)", num, maxSequence);
    }
}

