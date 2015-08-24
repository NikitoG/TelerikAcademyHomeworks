//Problem 4. Number Comparer

//Write a program that gets two numbers from the console and prints the greater of them.
//Try to implement this without if statements.

using System;

class Comparer
{
    static void Main()
    {
        double firstNumber;
        do
        {
            Console.Write("Enter first number a: ");
        } while (!(double.TryParse(Console.ReadLine(), out firstNumber)));

        double secondNumber;
        do
        {
            Console.Write("Enter second number b: ");
        } while (!(double.TryParse(Console.ReadLine(), out secondNumber)));

        Console.Write("greater: ");
        Console.WriteLine(firstNumber > secondNumber ? "{0}" : "{1}", firstNumber, secondNumber);
    }
}