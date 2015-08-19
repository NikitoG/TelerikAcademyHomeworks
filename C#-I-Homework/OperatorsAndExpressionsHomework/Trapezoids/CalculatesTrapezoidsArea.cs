//Problem 9. Trapezoids

//Write an expression that calculates trapezoid's area by given sides a and b and height h.

using System;

class CalculatesTrapezoidsArea
{
    static void Main()
    {
        double sidesA;
        do
        {
            Console.WriteLine("Enter a sides a:");
        } while (!(double.TryParse(Console.ReadLine(), out sidesA) && sidesA > 0));

        double sidesB;
        do
        {
            Console.WriteLine("Enter a sides b:");
        } while (!(double.TryParse(Console.ReadLine(), out sidesB) && sidesB > 0));

        double height;
        do
        {
            Console.WriteLine("Enter a height:");
        } while (!(double.TryParse(Console.ReadLine(), out height) && height > 0));

        double trapezoitsArea = (sidesA + sidesB) * height / 2;
        Console.WriteLine("Trapezoid's area is : " + trapezoitsArea);
    }
}
