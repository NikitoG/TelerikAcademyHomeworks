//Problem 1. Odd or Even Integers

//Write an expression that checks if given integer is odd or even.

using System;

class ChekOddOrEven
{
    static void Main()
    {
        Console.WriteLine("Enter integer:");
        int wholeNumber;
    Again:
        string strNumber = Console.ReadLine();

        if (int.TryParse(strNumber, out wholeNumber))
        {
            bool chekNumber = wholeNumber % 2 == 0;
            Console.WriteLine("Odd? -> " + !chekNumber);
        }
        else
        {
            Console.WriteLine("Try again.\nYou must eneter whole number:");
            goto Again;
        }
    }
}
