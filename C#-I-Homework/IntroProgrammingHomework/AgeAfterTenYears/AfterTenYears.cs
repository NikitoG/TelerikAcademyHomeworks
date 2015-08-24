//Problem 15.* Age after 10 Years
//Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years.

using System;

class AfterTenYears
{
    static void Main()
    {
        DateTime dateNow = DateTime.Now;
        Console.WriteLine("Your birthday is:");

    CheckDate:

        string date = Console.ReadLine();
        DateTime birthDay;

        if (DateTime.TryParse(date, out birthDay))
        {

            if (dateNow.DayOfYear >= birthDay.DayOfYear)
            {
                int age = dateNow.Year - birthDay.Year;
                Console.WriteLine("You are " + age + " years old!");
                int ageLater = age + 10;
                Console.WriteLine("After ten years you will be aged " + ageLater);
            }
            else
            {
                int age = dateNow.Year - birthDay.Year - 1;
                Console.WriteLine("You are " + age + " years old!");
                int ageLater = age + 10;
                Console.WriteLine("After ten years you will be aged " + ageLater + "!");
            }
        }
        else
        {
            Console.WriteLine("Try again in dd/mm/yyyy format:");
            goto CheckDate;

        }
    }
}
