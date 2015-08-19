//Problem 10. Find sum in array

//Write a program that finds in given array of integers a sequence of given sum S (if present).

using System;
using System.Linq;



class SumInArray
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

        int S;
        do
        {
            Console.Write("Enter S: ");
        } while (!(int.TryParse(Console.ReadLine(), out S)));
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("Sum = {0}", S);

        int sum = 0;
        string separator = "";
        int iteration = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum = 0;
            for (int j = i; j < numbers.Length; j++)
            {
                sum += numbers[j];
                if (sum == S)
                {
                    ++iteration;
                    separator = "";
                    for (int k = i; k <= j; k++)
                    {
                        //Console.Write("{0}, ", numbers[k]);
                        Console.Write(separator);
                        Console.Write(numbers[k]);
                        separator = ", ";
                    }
                    Console.WriteLine();
                    break;
                }
                
            }
        }
        if (iteration == 0)
        {
            Console.WriteLine("NOT FOUND");
        }

    }
}

