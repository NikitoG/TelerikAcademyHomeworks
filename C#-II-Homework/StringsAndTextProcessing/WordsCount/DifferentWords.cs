//Problem 22. Words count

//Write a program that reads a string from the console and lists all different words in the string along with information
//how many times each word is found.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class DifferentWords
{
    static void Main()
    {
        //Console.WriteLine("Enter a text: ");
        //string inputText = Console.ReadLine().ToLower();

        string inputText = @"Word counter is a word count and a character count tool. 
                            Simply place your cursor into the box and begin typing. 
                            Word counter will automatically count the number of words and characters as you type.
                            You can also copy and paste a document you have already written into the word counter box and it
                            will display the word count and character numbers for that piece of writing.".ToLower();

        Dictionary<string, int> countWords = new Dictionary<string, int>();
        foreach (var word in Regex.Matches(inputText, @"\w+"))
        {
            if (countWords.ContainsKey(word.ToString()))
            {
                ++countWords[word.ToString()];
            }
            else
            {
                countWords.Add(word.ToString(), 1);
            }
        }
        foreach (var letters in countWords)
        {
            Console.WriteLine("{0} -> {1} times.", letters.Key, letters.Value);
        }
    }
}

