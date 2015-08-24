//Problem 7. Replace sub-string

//Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file.
//Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
class RaplceSubstringSolution
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\Files\file.txt");
            StreamWriter writer = new StreamWriter(@"..\..\Files\result.txt");
            using (reader)
            {
                using (writer)
                {
                    string currentLine = reader.ReadLine();
                    while (currentLine != null)
                    {
                        string result = currentLine.Replace("start", "finish");
                        writer.WriteLine(result);
                        currentLine = reader.ReadLine();
                    }
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

