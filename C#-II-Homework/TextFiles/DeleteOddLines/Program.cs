//Problem 9. Delete odd lines

//Write a program that deletes from given text file all odd lines.
//The result should be in the same file.

using System;
using System.IO;
using System.Text;
class Program
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\Files\file.txt");
            StringBuilder result = new StringBuilder();
            int counLine = 1;
            using (reader)
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    if (counLine % 2 == 0)
                    {
                        result.Append(counLine + ". ");
                        result.AppendLine(currentLine);
                    }
                    ++counLine;
                    currentLine = reader.ReadLine();
                }
            }
            StreamWriter write = new StreamWriter(@"..\..\Files\file.txt");
            using (write)
            {
                write.WriteLine(result);
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

