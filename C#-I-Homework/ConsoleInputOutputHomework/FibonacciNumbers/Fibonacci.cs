//Problem 10. Fibonacci Numbers

//Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….

using System;

class Fibonacci
{
    static void Main()
    {
        uint nMembers;
        do
        {
            Console.Write("Enter an integer number: ");
        } while (!uint.TryParse(Console.ReadLine(), out nMembers));

        ulong firstNum = 0u;
        ulong secondNum = 1u;
        ulong sum = 0u;
        for (int i = 0; i < nMembers; i++)
        {
            if (i == 94)
            {
                Console.WriteLine("overflow");
                break;
            }
            Console.Write("{0}, ", firstNum);
            sum = firstNum + secondNum;
            firstNum = secondNum;
            secondNum = sum;
        }
    }
}
