//Problem 13. Binary to Decimal Number

//Using loops write a program that converts a binary integer number to its decimal form.
//The input is entered as string. The output should be a variable of type long.
//Do not use the built-in .NET functionality.

using System;

class BinDec
{
    static void Main()
    {
        Console.WriteLine("Enter a number in binary format: ");
        string input = Console.ReadLine();

        char[] binary = input.ToCharArray();
        int n = input.Length;
        long number = 0;

        for (int i = (n-1); i >= 0; i--)
        {
            number += ((Convert.ToInt64(binary[i]) - 48) * (long)Math.Pow(2, ((n - 1) - i)));
        }
        Console.WriteLine(number);
    }
}
