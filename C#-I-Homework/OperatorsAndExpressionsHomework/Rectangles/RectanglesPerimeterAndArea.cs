//Problem 4. Rectangles

//Write an expression that calculates rectangle’s perimeter and area by given width and height.

using System;

class RectanglesPerimeterAndArea
{
    static void Main()
    {
        double widht;
        do
        {
            Console.WriteLine("Enter a widht:");
        } while (!(double.TryParse(Console.ReadLine(), out widht)));

        double height;
        do
        {
            Console.WriteLine("Enter a height:");
        } while (!(double.TryParse(Console.ReadLine(), out height)));

        Console.WriteLine("Perimeter is: {0}", 2 * widht + 2 * height);
        Console.WriteLine("Are is:       {0}", widht * height);
    }
}
