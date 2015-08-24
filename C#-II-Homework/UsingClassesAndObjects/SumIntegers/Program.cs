//Problem 6. Sum integers

//You are given a sequence of positive integer values written into a string, separated by spaces.
//Write a function that reads these values from given string and calculates their sum.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumIntegers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a integers separated by a space: ");
            string input = Console.ReadLine();
            SumOfInteger(input);

        }
        static void SumOfInteger(string input)
        {
            string[] num = input.Split(' ').ToArray();
            int[] numbers = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                numbers[i] = int.Parse(num[i]);
            }
            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine("Sum = {0}", numbers.Sum());
        }
    }
}
