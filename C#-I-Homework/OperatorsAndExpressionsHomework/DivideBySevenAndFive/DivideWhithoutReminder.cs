//Problem 3. Divide by 7 and 5

//Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 at the same time.

using System;

class DivideWhithoutReminder
{
    static void Main()
    {
        int divider1 = 7;
        int divider2 = 5;

        string strInteger;
        int intForCheck;
        do
        {
            Console.WriteLine("Enter an integer:");
            strInteger = Console.ReadLine();
        } while (!(int.TryParse(strInteger, out intForCheck)));

        if(intForCheck != 0 )
        {
            Console.WriteLine("Can {0} be divided by {1} and {2}? --> {3}",
                intForCheck, divider1,divider2, ((intForCheck % divider1 == 0) && (intForCheck % divider2 == 0)));
        }
        else
        {
            Console.WriteLine("Can {0} be divided by {1} and {2}? --> {3}, but in examples is false?!",
                intForCheck, divider1, divider2, ((intForCheck % divider1 == 0) && (intForCheck % divider2 == 0)));
        }
    }
}