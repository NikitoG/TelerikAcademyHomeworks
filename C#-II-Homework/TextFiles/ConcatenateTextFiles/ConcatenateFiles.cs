//Problem 2. Concatenate text files

//Write a program that concatenates two text files into another text file.

using System;
using System.IO;

class ConcatenateFiles
{
    static void Main()
    {
        string firstFile = @"..\..\Files\firstFile.txt";
        string secondFile = @"..\..\Files\secondFile.txt";
        StreamWriter writer = new StreamWriter(@"..\..\Files\concFile.txt");
        try
        {
            using (writer)
            {
                writer.Write(GetTextfromFile(firstFile));
                writer.WriteLine("\n" + new string('*', 30));
                writer.Write(GetTextfromFile(secondFile));
            }
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    private static string GetTextfromFile(string file)
    {
        StreamReader reader = new StreamReader(file);
        string textFromFile = string.Empty;
        try
        {
            using (reader)
            {
                textFromFile = reader.ReadToEnd();
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

        return textFromFile;
    }
}

