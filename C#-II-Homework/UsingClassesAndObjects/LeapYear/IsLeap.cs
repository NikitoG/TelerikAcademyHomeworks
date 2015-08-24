//Problem 1. Leap year

//Write a program that reads a year from the console and checks whether it is a leap one.
//Use System.DateTime.

using System;


class IsLeap
{
    static void Main()
    {
        Console.Write("Enter a year: ");
        DateTime year = new DateTime(int.Parse(Console.ReadLine()), 1, 1);
        bool isLeap = DateTime.IsLeapYear(year.Year);
        if (isLeap)
        {
            Console.WriteLine("{0} is leap year!", year.Year);
        }
        else
        {
            Console.WriteLine("{0} is not leap year!", year.Year);
        }
    }
}

