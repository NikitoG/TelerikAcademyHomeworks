//Problem 19. Dates from text in Canada

//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
//Display them in the standard date format for Canada.

using System;
using System.Text.RegularExpressions;
using System.Globalization;

class DatesInCanada
{
    static void Main()
    {
        //Console.WriteLine("Enter a text: ");
        //string inputText = Console.ReadLine();
        string inputText = @"Text with many dates: 10.14.2014 and 1.14.2014 and 14.10.2014 and 1.1.2015";

        DateTime currentDate = new DateTime();
        foreach (var date in Regex.Matches(inputText, @"\d{1,2}\.\d{1,2}\.\d{2,4}"))
        {
            if (DateTime.TryParseExact(date.ToString(), "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out currentDate))
            {
                Console.WriteLine(currentDate.ToString(CultureInfo.GetCultureInfo("fr-CA")));
            }
        }
    }
}

