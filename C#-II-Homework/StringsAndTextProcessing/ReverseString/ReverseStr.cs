//Problem 2. Reverse string

//Write a program that reads a string, reverses it and prints the result at the console.

using System;

class ReverseStr
{
    static void Main()
    {
        Console.WriteLine("Write a string: ");
        string str = Console.ReadLine();
        string reverse = string.Empty;
        for (int i = 0; i < str.Length; i++)
        {
            reverse += str[str.Length - 1 - i];
        }
        Console.WriteLine("{0} -> {1}", str, reverse);
    }
}

