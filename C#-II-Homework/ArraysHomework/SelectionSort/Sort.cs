//Problem 7. Selection sort

//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
//Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

using System;
using System.Linq;

class Sort
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

        int minValue = int.MaxValue;
        int position = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            minValue = int.MaxValue;
            for (int j = i; j < numbers.Length; j++)
            {
                if (numbers[j] <= minValue)
                {
                    minValue = numbers[j];
                    position = j;
                }
            }
            numbers[position] = numbers[i];
            numbers[i] = minValue;
        }

        Console.WriteLine(string.Join(", ", numbers));
    }
}

