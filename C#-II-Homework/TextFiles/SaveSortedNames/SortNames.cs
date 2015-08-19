//Problem 6. Save sorted names

//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.

using System;
using System.IO;
using System.Collections.Generic;
class SortNames
{
    static void Main()
    {
        List<string> names = new List<string>();
        try
        {
            StreamReader reader = new StreamReader(@"..\..\Files\file.txt");
            using (reader)
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    names.Add(currentLine);
                    currentLine = reader.ReadLine();
                }
            }
            names.Sort();
            StreamWriter writer = new StreamWriter(@"..\..\Files\sortedNames.txt");
            using (writer)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    writer.WriteLine(names[i]);
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

