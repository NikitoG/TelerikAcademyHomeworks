//Problem 3. Circle Perimeter and Area

//Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.

using System;

class CirclePerimeterArea
{
    static void Main()
    {
        double radius;
        do
        {
            Console.WriteLine("Enter a radius: ");
        } while (!(double.TryParse(Console.ReadLine(), out radius)));

        double perimeter = Math.PI * radius * 2;
        double area = Math.PI * radius * radius;
        Console.WriteLine("Perimeter: {0: 0.00}", perimeter);
        Console.WriteLine("Area: {0: 0.00}", area);
    }
}
