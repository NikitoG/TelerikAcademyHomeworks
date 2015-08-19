//Problem 7. Sum of 5 Numbers

//Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.

using System;

class SumOfNumbers
{
    static void Main()
    {
        Console.Write("Enter a 5 numbers ina single line, separated by a space: ");
        string[] sequanceNum = Console.ReadLine().Split(' ');
        double sum = 0;
        for (int i = 0; i < sequanceNum.Length; i++)
        {
            sum += Convert.ToDouble(sequanceNum[i]);
        }
        Console.WriteLine("Sum is {0}", sum);
    }
}
