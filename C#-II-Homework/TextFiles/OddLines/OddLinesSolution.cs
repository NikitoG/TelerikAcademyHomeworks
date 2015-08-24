//Problem 1. Odd lines

//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class OddLinesSolution
{
    static void Main()
    {
        var reader = new StreamReader(@"..\..\Files\file.txt");
        using (reader)
        {
            try
            {
                string currentLine = reader.ReadLine();
                int count = 1;
                while (currentLine != null)
                {
                    if (count % 2 != 0)
                    {
                        Console.WriteLine("{0:D2}. {1}", count, currentLine);
                    }
                    ++count;
                    currentLine = reader.ReadLine();
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
}

