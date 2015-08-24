//Problem 4. Binary search

//Write a program, that reads from the console an array of N integers and an integer K, 
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.

using System;

class BinarySearch
{
    static void Main()
    {
        int N;
        do
        {
            Console.Write("N = ");
        } while (!(int.TryParse(Console.ReadLine(), out N) && N > 0));
        int[] numbers = new int[N];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        int K;
        do
        {
            Console.Write("K = ");
        } while (!int.TryParse(Console.ReadLine(), out K));
        Console.WriteLine(string.Join(", ", numbers));
        Array.Sort(numbers);
        Console.Write("Sorted array : ");
        Console.WriteLine(string.Join(", ", numbers));

        int myIndex=Array.BinarySearch(numbers, K);
        if (myIndex < 0)
        {
            if ((~myIndex) > (numbers.Length - 1))
            {
                Console.WriteLine("The largest number in the array which is ≤ K = {0}", numbers[numbers.Length - 1]);
            }
            else if ((~myIndex) > 0)
            {
                Console.WriteLine("The largest number in the array which is ≤ K = {0}", numbers[(~myIndex) - 1]);
            }
            else
            {
                Console.WriteLine("All numbers in the array are bigger than {0}", K);
            }
        }
        else
        {
            if (myIndex > 0)
            {
                Console.WriteLine("The largest number in the array which is ≤ K = {0}", numbers[myIndex - 1]);
            }
            else
            {
                Console.WriteLine("All numbers in the array are bigger than {0}", K);
            }
        }


    }
}

