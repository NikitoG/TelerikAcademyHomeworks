//Problem 10.* Beer Time

//A beer time is after 1:00 PM and before 3:00 AM.
//Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator) and prints beer time or non-beer time according to the definition above or invalid time if the time cannot be parsed. Note: You may need to learn how to parse dates and times.

using System;
using System.Globalization;

class TimeForBeer
{
    static void Main()
    {
        Console.WriteLine("Are you ready for beer?");
        Console.Write("What time is it? ");
        string strTime = Console.ReadLine();
        DateTime start = DateTime.Parse("1:00 PM");
        DateTime end = DateTime.Parse("3:00 AM");

        DateTime beerTime;
        if (DateTime.TryParseExact (strTime, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out beerTime))
        {
            if ((beerTime > start) || (beerTime < end))
            {
                    Console.WriteLine("Beer Time !");                    
            }
            else
            {
                Console.WriteLine("non-beer time :(");
            }
        }
        else
        {
            Console.WriteLine("Invalid Time!");
        }

    }
}
