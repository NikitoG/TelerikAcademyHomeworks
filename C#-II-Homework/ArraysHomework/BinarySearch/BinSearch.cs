//Problem 11. Binary search

//Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm.

using System;
using System.Linq;

class BinSearch
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
        Console.Write("Enter element: ");
        int element = int.Parse(Console.ReadLine());

        int index = (numbers.Length - 1)/2;
        int left = 0;
        int right = numbers.Length - 1;
        while (numbers[index] != element)
        {
            if (element<numbers[0] || element>numbers[numbers.Length - 1])
            {
                Console.WriteLine("NOT FOUND");
                break;
            }
            if (numbers[index] > element)
            {
                right = index;
                index -= ((right - left)/2);
            }
            else
            {
                left = index;
                index += ((right-left)/2); 
            }
            if (((right - left)<=1) && (numbers[index]!=element) && (numbers[left]!=element) && (numbers[right]!=element))
            {
                Console.WriteLine("NOT FOUND");
                break;
            }
        }

        if (numbers[index] == element)
        {
            Console.WriteLine("position = {0}", index);
        }
    }
}

