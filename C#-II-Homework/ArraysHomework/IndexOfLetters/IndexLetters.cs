//Problem 12. Index of letters

//Write a program that creates an array containing all letters from the alphabet (A-Z).
//Read a word from the console and print the index of each of its letters in the array.

using System;
using System.Linq;

class IndexLetters
{
    static void Main()
    {
        char[] alphabet = new char[26];
        for (int i = 0; i < alphabet.Length; i++)
        {
            alphabet[i] = (char)('A' + i);
        }

        Console.Write("Write a word: ");
        string inputWord = Console.ReadLine();
        char currentLetter = new char();
        string separate ="";
        foreach (char letter in inputWord)
        {
            currentLetter = new char();
            if (char.IsLetter(letter))
            {
                currentLetter = char.ToUpper(letter);
            }
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (currentLetter == alphabet[i])
                {
                    Console.Write("{0}{1}", separate, i);
                }
            }
            if (currentLetter == '\0')
            {
                Console.Write("{0}{1}", separate, letter);
            }
            separate = ", ";
        }
        Console.WriteLine();
    }
}

