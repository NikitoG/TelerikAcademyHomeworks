//Problem 4. Compare text files

//Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
//Assume the files have equal number of lines.

using System;
using System.IO;
class Program
{
    static void Main()
    {
        StreamReader firstFile = new StreamReader(@"..\..\Files\firstFile.txt");
        StreamReader secondFile = new StreamReader(@"..\..\Files\secondFile.txt");
        using (firstFile)
        {
            using (secondFile)
            {
                string firstFileLine = firstFile.ReadLine();
                string secondFileLine = secondFile.ReadLine();
                int equalLine = 0;
                int differnetLine = 0;
                while (firstFileLine != null && secondFileLine != null)
                {
                    if (firstFileLine.CompareTo(secondFileLine) == 0)
                    {
                        ++equalLine;
                    }
                    else
                    {
                        ++differnetLine;
                    }
                    firstFileLine = firstFile.ReadLine();
                    secondFileLine = secondFile.ReadLine();

                }

                Console.WriteLine("{0} line are equal", equalLine);
                Console.WriteLine("{0} line are differnet", differnetLine);
            }
        }
        
    }
}

