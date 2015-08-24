//Problem 16. Date difference

//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

using System;

class DateDifferenceSalution
{
    static void Main()
    {
        Console.WriteLine("Write a two dates in forrmat day.month.year. ");
        Console.Write("First date: ");
        DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        Console.Write("Second date: ");
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine("Days between two days are {0}", (secondDate - firstDate).TotalDays);
    }
}

