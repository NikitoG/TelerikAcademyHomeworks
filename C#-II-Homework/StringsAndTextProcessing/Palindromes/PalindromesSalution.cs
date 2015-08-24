//Problem 20. Palindromes

//Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.

using System;
using System.Text.RegularExpressions;

class PalindromesSalution
{
    static void Main()
    {
        //Console.WriteLine("Enter a text: ");
        //string inputText = Console.ReadLine();

        string inputText = "Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.";

        string[] words = Regex.Split(inputText, @"\W+");

        foreach (var word in words)
        {
            bool isPalindrome = true;
            if (word.Length > 1)
            {
                for (int i = 0; i < word.Length / 2; i++)
                {
                    if (word[i] != word[word.Length - 1 - i])
                    {
                        isPalindrome = false;
                        break;
                    }
                }
                if (isPalindrome)
                {
                    Console.WriteLine(word);
                }
            }

        }
    }
}

