//Problem 1. Square root

//Write a program that reads an integer number and calculates and prints its square root.
//If the number is invalid or negative, print Invalid number.
//In all cases finally print Good bye.
//Use try-catch-finally block.

using System;

class SquareRootSalution
{
    static int GetNumber()
    {

        Console.Write("Enter a number: ");
        try
        {
            int number = int.Parse(Console.ReadLine());
            return number;
        }
        catch (Exception)
        {
            throw new ArithmeticException();
        }
    }
    static void Main()
    {
        try
        {
            int number = GetNumber();
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Sqrt for negative numbers is undefined.");
            }
            Console.WriteLine("Square root from {0} is {1}", number, Math.Sqrt(number));
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("Invalid number!");
        }    
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid number!");
        }
        finally
        {
            Console.WriteLine("Good bye.");
        }
    }
}

