//Problem 15.* Number calculations

//Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
//Use generic method (read in Internet about generic methods in C#).

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumbersCalculation
{
    static void Main()
    {
        Calculation(-1.23, 2, 3, 4, 5.236, -6, 7, 8, 9);
    }

    static void Calculation<T>(params T[] numbers) where T : IComparable
    {
        T min = numbers[0];
        T max = numbers[0];
        decimal average = 0;
        dynamic sum = 0;
        dynamic product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i].CompareTo(min) < 0)
            {
                min = numbers[i];
            }
            if (numbers[i].CompareTo(min) > 0)
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

