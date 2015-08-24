//Problem 1. Exchange If Greater

//Write an if-statement that takes two double variables a and b and exchanges their values if the first one is greater than the second one. As a result print the values a and b, separated by a space.

using System;

class ExchangeIfGreater
{
    static void Main()
    {
        double firstNum;
        do
        {
            Console.Write("Enter number a: ");
        } while (!double.TryParse(Console.ReadLine(), out firstNum));

        double secondNum;
        do
        {
            Console.Write("Enter number b: ");
        } while (!double.TryParse(Console.ReadLine(), out secondNum));

        if (firstNum > secondNum)
        {
            Console.WriteLine("Result: " + secondNum + " " + firstNum);
        }
        else
        {
            Console.WriteLine("Result: " + firstNum + " " + secondNum);
        }
    }
}
