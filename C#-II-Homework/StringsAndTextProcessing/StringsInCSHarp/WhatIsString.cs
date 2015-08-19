//Problem 1. Strings in C#.

//Describe the strings in C#.
//What is typical for the string data type?
//Describe the most important methods of the String class.

using System;

class WhatIsString
{
    static void Main()
    {
        Console.WriteLine("Describe the strings in C#.");
        Console.WriteLine("- A string is a sequence of characters stored in a certain address in memory.");
        Console.WriteLine("- Each character has a serial number form the Unicode table.");
        Console.WriteLine("- Strings are immutable.");

        Console.WriteLine("\nWhat is typical for the string data type?");
        Console.WriteLine("- strings are very similar to rhe char array, but they can not be modify.");
        Console.WriteLine("- Its values are stored in the dynamic memory (managed heap)");
        Console.WriteLine("- The usage of System.String is not the ideal and universal solution");

        Console.WriteLine("\nDescribe the most important methods of the String class.");
        Console.WriteLine("- string.Join -> Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member.");
        Console.WriteLine("- string.Compare -> Compares two specified String objects and returns an integer that indicates their relative position in the sort order.");
        Console.WriteLine("- Split method -> Returns a string array that contains the substrings in this instance that are delimited by elements of a specified string or Unicode character array.");
    }
}

