//Problem 8. Replace whole word

//Modify the solution of the previous problem to replace only whole words (not strings).

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
                        
                        currentLine = Regex.Replace(currentLine, @"\bstart\b", "finish");
                        writer.WriteLine(currentLine);
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

