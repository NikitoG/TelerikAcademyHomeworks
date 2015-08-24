//Problem 4. Sub-string in text

//Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).

using System;


class FindSubstring
{
    static void Main()
    {
        Console.WriteLine("Write a text: ");
        string inputText = Console.ReadLine();
        Console.WriteLine("Enter a sub-string: ");
        string subString = Console.ReadLine();
        int count = 0;
        int compare = -1;
        for (int i = 0; i <= inputText.Length - subString.Length; i++)
        {
            compare = string.Compare(inputText.Substring(i, subString.Length), subString, true);
            if (compare == 0)
            {
                ++count;
            }
        }
        Console.WriteLine(count);
    }
}

