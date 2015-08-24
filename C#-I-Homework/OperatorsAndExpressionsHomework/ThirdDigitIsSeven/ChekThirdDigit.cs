//Problem 5. Third Digit is 7?

//Write an expression that checks for given integer if its third digit from right-to-left is 7.

using System;

class ChekThirdDigit
{
    static void Main()
    {
        int thirdDigit = 7;

        int givenInt;
        do
        {
            Console.WriteLine("Enter a integer:");
        } while (!(int.TryParse(Console.ReadLine(), out givenInt)));

        if ((givenInt / 100) % 10 == 7)
        {
            Console.WriteLine("Third digit {0}? -> true", thirdDigit);
        }
        else
        {
            Console.WriteLine("Third digit {0}? -> false", thirdDigit);
        }
    }
}
