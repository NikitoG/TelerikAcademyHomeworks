//Problem 3. Read file contents

//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
//Find in MSDN how to use System.IO.File.ReadAllText(…).
//Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;

class ReadFile
{
    static void Main()
    {
        Console.WriteLine("Enter a full file path: ");
        string filePath = Console.ReadLine();
        try
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine(fileContent);
        }
        catch (ArgumentNullException ex)
        {

            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {

            Console.WriteLine(ex.Message);
        }
        catch (DirectoryNotFoundException ex)
        {

            Console.WriteLine(ex.Message);
        }
        catch (PathTooLongException ex)
        {

            Console.WriteLine(ex.Message);
        }
        catch (FileNotFoundException ex)
        {

            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {

            Console.WriteLine(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {

            Console.WriteLine(ex.Message);
        }
        catch (NotSupportedException ex)
        {

            Console.WriteLine(ex.Message);
        }

    }
}

