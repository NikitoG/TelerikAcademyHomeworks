//Problem 7. Point in a Circle

//Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).

using System;

class ChekThePoint
{
    static void Main()
    {
        double radius = 2.0;
        double x;
        do
        {
            Console.WriteLine("Enter a x :");
        } while (!(double.TryParse(Console.ReadLine(), out x)));

        double y;
        do
        {
            Console.WriteLine("Enter a y:");
        } while (!(double.TryParse(Console.ReadLine(), out y)));

        bool chekPoint = radius >= Math.Sqrt(x * x + y * y);
        Console.WriteLine("Is point inside the circle? - > " + chekPoint);

    }
}
