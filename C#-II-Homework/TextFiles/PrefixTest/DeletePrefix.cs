using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
class DeletePrefix
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\Files\file.txt");
            using (reader)
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    List<string> words = new List<string>(currentLine.Split(' '));
                    for (int i = 0; i < words.Count; )
                    {
                        if (words[i].IndexOf("test") == 0)
                        {
                            words.RemoveAt(i);
                        }
                        else
                        {
                            ++i;
                        }
                    }
                    StreamWriter writer = new StreamWriter(@"..\..\Files\result.txt");
                    using (writer)
                    {
                        writer.WriteLine(string.Join(" ", words));
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

