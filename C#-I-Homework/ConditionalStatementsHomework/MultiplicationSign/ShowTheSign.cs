//Problem 4. Multiplication Sign

//Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
//Use a sequence of if operators.

using System;

class ShowTheSign
{
    static void Main()
    {
        Console.WriteLine("Enter a three real numbers.");
        double firstNum;
        do
        {
            Console.Write("Enter a: ");                        
        } while (!double.TryParse(Console.ReadLine(), out firstNum));

        double secondNum;
        do
        {
            Console.Write("Enter b: ");
        } while (!double.TryParse(Console.ReadLine(), out secondNum));

        double thirdNum;
        do
        {
            Console.Write("Enter c: ");
        } while (!double.TryParse(Console.ReadLine(), out thirdNum));

        if (firstNum == 0 || secondNum == 0 || thirdNum == 0)
        {
            Console.WriteLine("If a, b and c are multiplied result is: 0");
        }
        else if ((firstNum < 0 && secondNum < 0 && thirdNum < 0) || (firstNum < 0 && secondNum > 0 && thirdNum > 0))
        {
            Console.WriteLine("If a, b and c are multiplied result is: -");            
        }
        else if ((firstNum > 0 && secondNum < 0 && thirdNum > 0) || (firstNum > 0 && secondNum > 0 && thirdNum < 0))
        {
            Console.WriteLine("If a, b and c are multiplied result is: -");            
        }
        else
        {
            Console.WriteLine("If a, b and c are multiplied result is: +");            
        }
    }
}
