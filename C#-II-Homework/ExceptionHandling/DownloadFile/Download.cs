//Problem 4. Download file

//Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
//Find in Google how to download files in C#.
//Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.IO;
using System.Net;

class Download
{
    static void Main()
    {
        string address = @"http://telerikacademy.com/Content/Images/news-img01.png";
        string fileName = "ninja.png";
        using (WebClient web = new WebClient())
        {
            try
            {
                web.DownloadFile(address, fileName);
                Console.WriteLine("Picture was download succesfully in: \n{0}", Directory.GetCurrentDirectory());
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }
    }
}

