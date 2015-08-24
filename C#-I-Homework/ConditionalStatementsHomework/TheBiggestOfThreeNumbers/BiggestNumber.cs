//Problem 5. The Biggest of 3 Numbers

//Write a program that finds the biggest of three numbers.

using System;

class BiggestNumber
{
    static void Main()
    {
        double a;
        do
        {
            Console.Write("Write a number a:");
        }while(!double.TryParse(Console.ReadLine(), out a));

        double b;
        do
        {
            Console.Write("Write a number b:");
        }while(!double.TryParse(Console.ReadLine(), out b));

        double c;
        do
        {
        Console.Write("Write a number c:");
        }while(!double.TryParse(Console.ReadLine(), out c));

        if (a > b && a > c)
        {
            Console.WriteLine("From {0}, {1} and {2}, biggest number is: {0}", a, b, c);
        }
        if (b > c && b > a)
        {
            Console.WriteLine("From {0}, {1} and {2}, biggest number is: {1}", a, b, c);            
        }
        if (c > a && c > b)
        {
            Console.WriteLine("From {0}, {1} and {2}, biggest number is: {2}", a, b, c);            
        }
    }
}
