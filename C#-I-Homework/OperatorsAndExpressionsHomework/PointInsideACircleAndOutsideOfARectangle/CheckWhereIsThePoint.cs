//Problem 10. Point Inside a Circle & Outside of a Rectangle

//Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2)

using System;

class CheckWhereIsThePoint
{
    static void Main()
    {
        double radius = 1.5;
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

        double xC = 1.0;
        double yC = 1.0;
        bool checkCircle = radius >= Math.Sqrt((x-xC) * (x-xC) + (y-yC) * (y-yC));

        double top = 1.0;
        double left = -1.0;
        double widht = 6.0;
        double height = 2.0;
        bool checkRectangle;
        if (checkRectangle = (x < left) || (x > (left + widht)) )
        {
        }
        else if (checkRectangle = (y > top) || (y < (top - height)))
        {
        }
        else
        {
            checkRectangle = false;
        }

        Console.WriteLine("The point is inside circle & outside of rectangle: -> {0}", 
            checkCircle && checkRectangle?"YES":"NO");
    }
}