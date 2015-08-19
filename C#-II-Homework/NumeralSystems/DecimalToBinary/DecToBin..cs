//Problem 1. Decimal to binary

//Write a program to convert decimal numbers to their binary representation.

using System;
using System.Collections.Generic;

class DecToBin
{
    static void Main()
    {
        int number;
        do
        {
            Console.Write("Enter a non-sign number: ");
        } while (!(int.TryParse(Console.ReadLine(), out number) && number >= 0));

        int temp = number;
        List<int> binaryNum = new List<int>();
        while (temp != 0)
        {
            binaryNum.Add(temp % 2);
            temp /= 2;
        }

        binaryNum.Reverse();
        Console.Clear();
        Console.WriteLine("{0} in binary {1}", number, string.Join("", binaryNum));
    }
}
