//Problem 14. Integer calculations

//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
//Use variable number of arguments.

using System;
using System.Collections.Generic;

class NumbersCalculation
{
    static void Main()
    {
        Calculation(1, 2, 3, 4, 5, 6, 7, 8, 9);
    }

    static void Calculation(params int[] numbers)
    {
        int min = numbers[0];
        int max = numbers[0];
        decimal average = 0;
        int sum = 0;
        int product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
            sum += numbers[i];
            product *= numbers[i];
        }
        average = (decimal)sum / numbers.Length;


        Console.WriteLine("Given set of integers number is: {0}", string.Join(", ", numbers) );
        Console.WriteLine("Minimum = {0}", min);
        Console.WriteLine("Maximum =  {0}", max);
        Console.WriteLine("Average = {0}", average);
        Console.WriteLine("Sum = {0}", sum);
        Console.WriteLine("Product = {0}", product);

    }
}

