//Problem 5. Workdays

//Write a method that calculates the number of workdays between today and given date, passed as parameter.
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified
//preliminary as array.

using System;
using System.Globalization;
using System.Linq;
class Work
{
    static DateTime now = DateTime.Now;
    static DateTime[] holydays = { new DateTime(2015, 1, 1), new DateTime(2015, 3, 3),
                                     new DateTime(2015, 5, 1), new DateTime(2015, 5, 6), 
                                     new DateTime(2015, 9, 22),new DateTime(2015, 12, 24),
                                     new DateTime(2015, 12, 25),new DateTime(2015, 12, 31) };
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CurrentCulture;
        Console.Write("Enter a date: ");
        DateTime futureDate = DateTime.Parse(Console.ReadLine());
        int workDays = CalcualteWorkDays(now, futureDate);
        Console.WriteLine("Work days is {0}", workDays);

    }

    static int CalcualteWorkDays(DateTime now, DateTime futureDate)
    {
        int count = 0;
        if (now <= futureDate)
        {
            while (now <= futureDate)
            {
                if (now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday && !holydays.Contains(now))
                {
                    ++count;
                }
                now = now.AddDays(1);
            }
        }
        else
        {
            while (futureDate <= now)
            {
                if (now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday && !holydays.Contains(now))
                {
                    ++count;
                }
                now = now.AddDays(-1);
            }
        }

        return count;
    }
}

