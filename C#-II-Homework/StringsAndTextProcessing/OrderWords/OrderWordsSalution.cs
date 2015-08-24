//Problem 24. Order words

//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter a words separated by a space: ");
        string inputText = Console.ReadLine();

        //string inputText = "pesho gosho ivan nikolay ivo peshov Ivanov";
        string[] words = inputText.Split(' ');

        Array.Sort(words);
        Console.Write("String in alphabetical order: ");
        Console.WriteLine(string.Join(", ",  words));

    }
}

