//Problem 18. Extract e-mails

//Write a program for extracting all email addresses from given text.
//All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
    class ExtractMailsSalution
    {
        static void Main()
        {
            //Console.WriteLine("Enter a text:");
            //string inputText = Console.ReadLine();

            string inputText = "firstmail: pesho@gmail.com; second mail: gosho_ivanov@abv.bg; third mail: @ivan.petkan";

            foreach (var item in Regex.Matches(inputText, @"\w+\@\w+\.\w+"))
            {
                Console.WriteLine(item);
            }
        }
    }

