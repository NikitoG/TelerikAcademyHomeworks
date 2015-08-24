//Problem 10. Unicode characters

//Write a program that converts a string to a sequence of C# Unicode character literals.
//Use format strings.

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        Console.Write("In Unicode character: ");
        foreach (var ch in input)
        {
            Console.Write("\\u{0:X4}", (int)ch);
        }
        Console.WriteLine();
    }
}

