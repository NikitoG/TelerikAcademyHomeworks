//Problem 6. String length

//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with *.
//Print the result string into the console.

using System;
using System.Text;

class Padleft
{
    static void Main()
    {
        StringBuilder inputSb = new StringBuilder();
        do
        {
            char inputKey = Console.ReadKey().KeyChar;
            if (inputKey == '\r')
            {
                break;
            }
            inputSb.Append(inputKey);
        } while (inputSb.Length < 20);

        Console.WriteLine();
        string inputString = inputSb.ToString();

        Console.WriteLine(inputString.PadRight(20, '*'));
    }
}

