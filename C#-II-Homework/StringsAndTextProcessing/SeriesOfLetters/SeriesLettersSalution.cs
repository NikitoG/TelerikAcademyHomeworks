//Problem 23. Series of letters

//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.

using System;
using System.Text;

class SeriesLettersSalution
{
    static void Main()
    {
        Console.WriteLine("Enter a text: ");
        string inputText = Console.ReadLine().ToLower();

        //string inputText = "aaaaabbbbbcdddeeeedssaa";
        StringBuilder text = new StringBuilder(inputText);
        for (int i = 1; i < text.Length; )
        {
            if (text[i] == text[i - 1])
            {
                text = text.Remove(i, 1);
            }
            else
            {
                ++i;
            }
        }

        Console.WriteLine(text.ToString());
    }
}

