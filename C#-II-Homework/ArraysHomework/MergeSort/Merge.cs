//Problem 13.* Merge sort

//Write a program that sorts an array of integers using the Merge sort algorithm.

using System;

namespace MergeSort
{
    class Merge
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
            int[] sorted = MergeSort(numbers);
            
            Console.WriteLine(string.Join(", ", sorted));
        }

        static int[] MergeSort(int[] unsorted)
        {
            if (unsorted.Length == 1)
            {
                return unsorted;
            }
            int middle = unsorted.Length / 2;
            int[] left = new int[middle];
            for (int i = 0; i < middle; i++)
            {
                left[i] = unsorted[i];
            }
            int[] right = new int[unsorted.Length - middle];
            for (int i = 0; i < unsorted.Length - middle; i++)
            {
                right[i] = unsorted[i + middle];
            }
            left = MergeSort(left);
            right = MergeSort(right);

            int leftptr = 0;
            int rightptr = 0;

            int[] sorted = new int[unsorted.Length];
            for(int k = 0 ; k < unsorted.Length; k++)
            {
                if ( rightptr == right.Length || ((leftptr < left.Length ) && (left[leftptr] <= right[rightptr])))
                {
                    sorted[ k ] = left[ leftptr ];
                    leftptr++;
                }
                else if( leftptr == left.Length || ((rightptr < right.Length ) && (right[rightptr] <= left[leftptr] )))
                {
                    sorted[k] = right[rightptr];
                    rightptr++;
                }
            }
            return sorted; 
        }
    }
}
