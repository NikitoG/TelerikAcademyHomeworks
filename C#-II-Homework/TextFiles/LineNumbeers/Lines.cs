//Problem 3. Line numbers

//Write a program that reads a text file and inserts line numbers in front of each of its lines.
//The result should be written to another text file.

using System;
using System.IO;
class Lines
{
    static void Main()
    {
        
        try
        {
            StreamReader reader = new StreamReader(@"..\..\Files\file.txt");
            using (reader)
            {
                StreamWriter writer = new StreamWriter(@"..\..\Files\result.txt");
                string currentLine = reader.ReadLine();
                int count = 1;
                using (writer)
                {
                    while (currentLine != null)
                    {
                        writer.WriteLine("{0:D2}. {1}", count, currentLine);
                        ++count;
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

