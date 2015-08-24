//Problem 3. English digit

//Write a method that returns the last digit of given integer as an English word.

using System;

class LastDigit
{
    static int ValidationOfInt()
    {
        int integer = 0;
        do
        {
            Console.Write("Enter a integer: ");
        } while (!int.TryParse(Console.ReadLine(), out integer));
        return integer;
    }
    static void Main()
    {
        int number = ValidationOfInt();
        string lastDigit = LastDigitAsAWord(Math.Abs(number));

        Console.WriteLine("Last digit of {0} is {1}!", number, lastDigit);
    }

    static string LastDigitAsAWord(int number)
    {
        int lastDigit = number % 10;
        string[] digitAsAWord = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        return digitAsAWord[lastDigit];
    }
}

