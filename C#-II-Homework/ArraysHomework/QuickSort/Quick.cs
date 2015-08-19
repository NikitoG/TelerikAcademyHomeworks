//Problem 14. Quick sort

//Write a program that sorts an array of integers using the Quick sort algorithm.

using System;

namespace QuickSort
{
    class Quick
    {
        static void Main()
        {
            int[] numbers = { 20, 1, 15, 8, 4, 13, 11, 1, 2, 3, 19, 11, 65, 23, 0, 25 };
            Console.WriteLine(string.Join(", ", numbers));

            //int N;
            //do
            //{
            //    Console.Write("Enter N: ");
            //} while (!(int.TryParse(Console.ReadLine(), out N) && N >= 0));

            //int[] numbers = new int[N];
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.Write("numbers[{0}] = ", i);
            //    numbers[i] = int.Parse(Console.ReadLine());
            //}

            QuickSort(numbers, 0, numbers.Length - 1);
            Console.WriteLine(string.Join(", ", numbers));

        }

        static void QuickSort(int[] numbers, int left, int right)
        {
            int leftPart = left;
            int rightPart = right;
            int pivot = numbers[(left + right) / 2];

            while (leftPart <= rightPart)
            {
                while (numbers[leftPart] < pivot)
                {
                    ++leftPart;
                }
                while (numbers[rightPart] > pivot)
                {
                    --rightPart;
                }
                if (leftPart <= rightPart)
                {
                    int temp = numbers[leftPart];
                    numbers[leftPart] = numbers[rightPart];
                    numbers[rightPart] = temp;
                    ++leftPart;
                    --rightPart;
                }

            }
            if (left < rightPart)
            {
                QuickSort(numbers, left, rightPart);
            }
            if (leftPart < right)
            {
                QuickSort(numbers, leftPart, right);
            }
        }
    }
}
