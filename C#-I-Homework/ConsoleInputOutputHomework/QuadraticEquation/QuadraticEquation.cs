//Problem 6. Quadratic Equation

//Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).

using System;

class QuadraticEquation
{
    static void Main()
    {
        double a;
        do
        {
            Console.Write("Enter coefficient a: ");
        } while (!double.TryParse(Console.ReadLine(), out a));

        double b;
        do
        {
            Console.Write("Enter coefficient b: ");
        } while (!double.TryParse(Console.ReadLine(), out b));

        double c;
        do
        {
            Console.Write("Enter coefficient c: ");
        } while (!double.TryParse(Console.ReadLine(), out c));

        double d = b * b - 4 * a * c;
        double x1 = (-b + Math.Sqrt(d)) / (2 * a);
        double x2 = (-b - Math.Sqrt(d)) / (2 * a);

        if(d < 0)
        {
            Console.WriteLine("roots: no real roots");
        }
        else if(d == 0)
        {
            Console.WriteLine("roots: x1 = x2 = {0}", x1);
        }
        else
        {
            Console.WriteLine("roots: x1 = {0}; x2 = {1}", x1, x2);
        }
    }
}