//Problem 14. Word dictionary

//A dictionary is stored as a sequence of text lines containing words and their explanations.
//Write a program that enters a word and translates it by using the dictionary.

using System;
using System.Collections.Generic;

    class DictionarySalution
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>() 
            {
                {".NET", "platform for applications from Microsoft"},
                {"CLR", "managed execution environment for .NET"},
                {"NAMESPACE", "hierarchical organization of classes"}
            };

            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine().ToUpper();
            if (dictionary.ContainsKey(word))
            {
                Console.WriteLine(dictionary[word]);
            }
            else
            {
                Console.WriteLine("No definition for {0}", word);
            }

        }
    }

