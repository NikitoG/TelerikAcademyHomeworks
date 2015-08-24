//Problem 12. Remove words

//Write a program that removes from a text file all words listed in given another text file.
//Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class RemoveWordsSalution
{
    static void Main()
    {
        try
        {
            StreamReader getWords = new StreamReader(@"..\..\Files\words.txt");
            List<string> words = new List<string>();
            using (getWords)
            {
                string currentLine = getWords.ReadLine();
                while (currentLine != null)
                {
                    string[] removeWords = currentLine.Split(new char[]{' ', ',', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                    words.AddRange(removeWords);
                    currentLine = getWords.ReadLine();
                }
            }
            StreamReader getText = new StreamReader(@"..\..\Files\test.txt");
            using (getText)
            {
                string currentLine = getText.ReadLine();
                while (currentLine != null)
                {
                    for (int i = 0; i < words.Count; i++)
                    {
                       currentLine =  currentLine.Replace(words[i], string.Empty);
                    }
                    StreamWriter result = new StreamWriter(@"..\..\Files\result.txt", true);
                    using (result)
                    {
                        result.WriteLine(currentLine);
                    }
                    currentLine = getText.ReadLine();
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

