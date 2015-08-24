//Problem 3. Decimal to hexadecimal

//Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Collections.Generic;

class DecToHex
{
    static void Main()
    {
        int number;
        do
        {
            Console.Write("Enter a non-sign number: ");
        } while (!(int.TryParse(Console.ReadLine(), out number) && number >= 0));

        int temp = number;
        int index = 0;
        char[] hexadecimal = { '0', '1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};
        List<char> hexadecimalNum = new List<char>();
        while (temp != 0)
        {
            index = temp % 16;
            hexadecimalNum.Add(hexadecimal[index]);
            temp /= 16;
        }

        hexadecimalNum.Reverse();
        Console.Clear();
        Console.WriteLine("{0} in hexadecimal {1}", number, string.Join("", hexadecimalNum));
    }
}

