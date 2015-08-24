//Problem 11. Format number

//Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
//Format the output aligned right in 15 symbols.

using System;

class FormatNumberSalution
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("{0,15:N2}", number);
        Console.WriteLine("\\u{0:X6}".PadLeft(15,'*'), number);
        Console.WriteLine("{0,15:P2}", number/100.00);
        Console.WriteLine("{0,15:E0}", number);
    }
}

