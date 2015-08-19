//Problem 10. N Factorial

//Write a program to calculate n! for each n in the range [1..100].
//Hint: Implement first a method that multiplies a number represented as array of digits by given integer number.

using System;
using System.Text;
using System.Collections.Generic;

class Factorial
{
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Enter a positive integer in the range [1...100]: ");
        } while (!int.TryParse(Console.ReadLine(), out n));

        List<int> nFactorial = new List<int> { 1 };
        for (int i = 2; i <= n; i++)
        {
            nFactorial = MultiplicationOfTwoNumbers(nFactorial, IntegerRepresentedAsArray(i));
        }

        nFactorial.Reverse();
        while (nFactorial[0] == 0)
        {
            nFactorial.RemoveAt(0);
        }
        Console.WriteLine(string.Join("", nFactorial));
    }

    static List<int> IntegerRepresentedAsArray(int number)
    {
        List<int> numArray = new List<int>();
        foreach (char num in number.ToString())
        {
            numArray.Add((int)(number % 10));
            number /= 10;

        }

        return numArray;
    }

    static List<int> MultiplicationOfTwoNumbers(List<int> firstArray, List<int> secondArray)
    {
        List<int> result = new List<int>(firstArray.Count + secondArray.Count);
        for (int i = 0; i < firstArray.Count + secondArray.Count; i++)
        {
            result.Add(0);
        }
        int reminder = 0;

        for (int i = 0; i < firstArray.Count; i++)
        {
            for (int j = 0; j < secondArray.Count + 1; j++)
            {
                if (j < secondArray.Count)
                {
                    if (((result[i + j] + (firstArray[i] * secondArray[j] + reminder) % 10) / 10) > 0)
                    {
                        result[i + j + 1] += ((result[i + j] + (firstArray[i] * secondArray[j] + reminder) % 10) / 10);
                    }
                    result[i + j] = (result[i + j] + (firstArray[i] * secondArray[j] + reminder) % 10) % 10;
                    reminder = (firstArray[i] * secondArray[j] + reminder) / 10;
                }
                else
                {
                    result[i + j] += reminder;
                }

            }
            reminder = 0;
        }


        return result;

    }
}