//Problem 10. Extract text from XML

//Write a program that extracts from given XML file all the text without the tags..

using System;
using System.IO;

class ExtractText
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\Files\file.txt");
            using (reader)
            {
                string currentLine = reader.ReadLine();
                string word = string.Empty;
                while (currentLine != null)
                {
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        if (currentLine[i] == '<')
                        {
                            while (currentLine[i] != '>')
                            {
                                ++i;
                            }
                        }
                        else
                        {
                            word += currentLine[i];
                            if (currentLine[i+1] == '<')
                            {
                                Console.WriteLine(word);
                                word = string.Empty;
                            }
                        }
                    }
                    currentLine = reader.ReadLine();
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
    }
}

