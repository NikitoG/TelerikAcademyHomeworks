//Problem 13. Count words

//Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained 
//in another file test.txt.
//The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in 
//descending order.
//Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

class RemoveWordsSalution
{
    static void Main()
    {
        try
        {
            StreamReader getWords = new StreamReader(@"..\..\Files\words.txt");
            Dictionary<string, int> countWords = new Dictionary<string, int>();
            using (getWords)
            {
                string currentLine = getWords.ReadLine();
                while (currentLine != null)
                {
                    string[] removeWords = currentLine.Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in removeWords)
                    {
                        countWords.Add(word.ToString(), 0);
                    }
                    currentLine = getWords.ReadLine();
                }
            }
            StreamReader getText = new StreamReader(@"..\..\Files\test.txt");
            using (getText)
            {
                string currentLine = getText.ReadLine();
                while (currentLine != null)
                {
                    foreach (var word in Regex.Matches(currentLine, @"\w+"))
                    {
                        if (countWords.ContainsKey(word.ToString()))
                        {
                            ++countWords[word.ToString()];
                        }
                    }
                    currentLine = getText.ReadLine();
                }
            }
            var sorted = countWords.OrderBy(key => key.Value).Reverse();
            foreach (var letters in sorted)
            {
                StreamWriter result = new StreamWriter(@"..\..\Files\result.txt", true);
                using (result)
                {
                    result.WriteLine("{0} -> {1} times.", letters.Key, letters.Value);
                }
            }

        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

