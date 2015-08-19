//Problem 3. Min, Max, Sum and Average of N Numbers

//Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
//The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
//The output is like in the examples below.

using System;

class MinMaxSumAndAverage
{
    static void Main()
    {
        uint seqLenght;
        do
        {
            Console.WriteLine("Enter a positive integer: ");
        } while (!uint.TryParse(Console.ReadLine(), out seqLenght));
        Console.WriteLine("Enter {0} integer numbers, use \"enter\" for saparate them", seqLenght);

        int number;
        int maxValue = int.MinValue;
        int minValue = int.MaxValue;
        int sum = 0;

        for (int i = 0; i < seqLenght; i++)
        {
            number = int.Parse(Console.ReadLine());

            if (number > maxValue)
            {
                maxValue = number;
            }
            if (number < minValue)
            {
                minValue = number;
            }

            sum += number;
        }

        Console.WriteLine("min = {0}",minValue);
        Console.WriteLine("max = {0}",maxValue);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("avg = {0: 0.00}", (double)sum/seqLenght);
    }
}