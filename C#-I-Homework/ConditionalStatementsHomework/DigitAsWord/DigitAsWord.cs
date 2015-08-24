//Problem 8. Digit as Word

//Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
//Print “not a digit” in case of invalid input.
//Use a switch statement.

using System;

class DigitAsWord
{
    static void Main()
    {
        Console.Write("Enter a digit: ");
        string digit = Console.ReadLine();
        string word;

        switch (digit)
        {
            case "0":
                word = "zero";
                break;
            case "1":
                word = "one";
                break;
            case "2":
                word = "two";
                break;
            case "3":
                word = "three";
                break;
            case "4":
                word = "four";
                break;
            case "5":
                word = "five";
                break;
            case "6":
                word = "six";
                break;
            case "7":
                word = "seven";
                break;
            case "8":
                word = "eight";
                break;
            case "9":
                word = "nine";
                break;

            default:
                word = "not a digit";
                break;
        }

        Console.WriteLine("{0} -> {1}", digit, word);
    }
}
