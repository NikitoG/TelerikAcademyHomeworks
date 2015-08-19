//Problem 17. Date in Bulgarian

//Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
//and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Globalization;
class BulgaraneDate
{
    static void Main()
    {
        Console.Write("Enter a sate in format day.month.year hour:minute:second: ");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy H:m:s", CultureInfo.GetCultureInfo("bg-BG"));
        DateTime dateAfterPeriod = date.AddHours(6).AddMinutes(30);
        Console.WriteLine("{0} -> {1}", date, dateAfterPeriod);
    }
}

