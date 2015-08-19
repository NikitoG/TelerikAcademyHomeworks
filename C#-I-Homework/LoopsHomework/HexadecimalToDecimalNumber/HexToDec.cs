//Problem 15. Hexadecimal to Decimal Number

//Using loops write a program that converts a hexadecimal integer number to its decimal form.
//The input is entered as string. The output should be a variable of type long.
//Do not use the built-in .NET functionality.

using System;

class HexToDec
{

    static void Main()
    {
        Console.WriteLine("Write a number in hexadecimal format(use upper case)");
        string input = Console.ReadLine();
        char[] hex = input.ToCharArray();
        int n = input.Length;
        long output = 0;
        int count = 0;
        for (int i = (n-1); i >= 0; i--)
        {
            switch (hex[i])
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    count = ((Convert.ToInt32(hex[i]) - 48));
                    break;
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                    count = ((Convert.ToInt32(hex[i]) - 55));
                    break;
            }
            output += count * (long)Math.Pow(16, ((n - 1) - i));
        }
        Console.WriteLine(output);

    }
}
