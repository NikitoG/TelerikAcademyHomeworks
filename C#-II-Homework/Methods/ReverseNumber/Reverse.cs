//Problem 7. Reverse number

//Write a method that reverses the digits of given decimal number.

using System;

class Reverse
{
    static void Main()
    {
        decimal number = 0;
        do
        {
            Console.Write("Enter decimal number: ");
        } while (!(decimal.TryParse(Console.ReadLine(), out number)));

        decimal reverse = RevesreNumber(number);
        Console.WriteLine("{0} -> reverse -> {1}", number, reverse);

    }

    static decimal RevesreNumber(decimal number)
    {

        string inputNumber = number.ToString();
        char[] charNumber = inputNumber.ToCharArray();
        char[] charReverse = new char[charNumber.Length];
        for (int i = 0; i < charNumber.Length; i++)
        {
            charReverse[charReverse.Length - 1 - i] = charNumber[i];
        }
        string stringReverse = new string(charReverse);
        decimal reverse = decimal.Parse(stringReverse);
        return reverse;
    }
}

