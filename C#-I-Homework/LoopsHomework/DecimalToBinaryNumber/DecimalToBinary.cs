//Problem 14. Decimal to Binary Number

//Using loops write a program that converts an integer number to its binary representation.
//The input is entered as long. The output should be a variable of type string.
//Do not use the built-in .NET functionality.

using System;

class DecimalToBinary
{
    static void Main()
    {
        long input;
        do
        {
            Console.WriteLine("Write a number for convert: ");
        } while (!long.TryParse(Console.ReadLine(), out input));

        long check = Math.Abs(input);
        string output = "";

        do
        {

            if ((check % 2) == 0)
            {
                output = "0" + output;
            }
            else
            {
                output = "1" + output;
            }
            check /= 2;

        } while (check != 0);

        Console.WriteLine(output);
        


    }
}
