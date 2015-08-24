//Problem 8. Number as array

//Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] 
//contains a digit; the last digit is kept in arr[0]).
//Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Text;
using System.Numerics;

class NumberAsArray
{
    static void Main()
    {
        BigInteger firstNumber = Validation();
        BigInteger secondNumber = Validation();

        int[] firstNumArray = IntegerRepresentedAsArray(firstNumber);
        int[] secondNumArray = IntegerRepresentedAsArray(secondNumber);

        BigInteger sum = 0;
        if (firstNumArray.Length >= secondNumArray.Length)
        {
            sum = SumOfTwoNumbers(firstNumArray, secondNumArray);
        }
        else
        {
            sum = SumOfTwoNumbers(secondNumArray, firstNumArray);
        }
        Console.WriteLine(string.Join(", ", firstNumArray));
        Console.WriteLine(string.Join(", ", secondNumArray));
        Console.WriteLine("Sum = {0}", sum);
    }

    static BigInteger Validation()
    {
        BigInteger num = 0;
        do
        {
            Console.Write("Enter positive integer: ");
        } while (!(BigInteger.TryParse(Console.ReadLine(), out num) && num >= 0));

        return num;
    }
    static int[] IntegerRepresentedAsArray(BigInteger number)
    {
        int[] numArray = new int[number.ToString().Length];
        int index = 0;
        foreach (char num in number.ToString())
        {
            numArray[index] = (int)(number % 10);
            number /= 10;
            ++index;
        }

        return numArray;
    }

    static BigInteger SumOfTwoNumbers(int[] firstArray, int[] secondArray)
    {
        StringBuilder sumString = new StringBuilder();
        int reminder = 0;
        for (int i = 0; i < firstArray.Length; i++)
        {
            if (i == 0)
            {
                sumString.Insert(0, ((firstArray[i] + secondArray[i]) % 10));
                reminder = (firstArray[i] + secondArray[i]) / 10;
            }
            else if (i < secondArray.Length)
            {
                sumString.Insert(0, ((firstArray[i] + secondArray[i] + reminder) % 10));
                reminder = (firstArray[i] + secondArray[i] + reminder) / 10;
            }
            else
            {
                sumString.Insert(0, (firstArray[i] + reminder) % 10);
                reminder = (firstArray[i] + reminder) / 10;
            }
            if (i == firstArray.Length - 1)
            {
                sumString.Insert(0, (reminder));
            }
        }

        return BigInteger.Parse(sumString.ToString());

    }

}

