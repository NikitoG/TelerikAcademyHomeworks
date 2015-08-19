//Problem 4. Triangle surface

//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it;
//Three sides;
//Two sides and an angle between them;
//Use System.Math.

using System;

class SurfaceOfTriangle
{
    static void Main()
    {
        Console.WriteLine("Calculate the surface of a triangle: ");

        Console.WriteLine("By given - Side and an altitude - press 1");
        Console.WriteLine("By given - Three sides - press 2");
        Console.WriteLine("By given - Two sides and a angle betwwen them - press 3");

        int choice = (int)Validation();
        double firstSide = 0;
        double secondSide = 0;
        double thirdSide = 0;
        double angle = 0;
        double altitude = 0;

        switch (choice)
        {
            case 1:
                Console.Write("Enter a side: ");
                firstSide = Validation();
                Console.Write("Enter an altitude: ");
                altitude = Validation();
                Console.WriteLine("Area = {0:F3}", SideAndAltitude(firstSide, altitude));
                break;
            case 2:
                Console.Write("Enter a first side: ");
                firstSide = Validation();
                Console.Write("Enter a second side: ");
                secondSide = Validation();
                Console.Write("Enter a third side: ");
                thirdSide = Validation();
                Console.WriteLine("Area = {0:F3}", ThreeSides(firstSide, secondSide, thirdSide));
                break;
            case 3:
                Console.Write("Enter a first side: ");
                firstSide = Validation();
                Console.Write("Enter a second side: ");
                secondSide = Validation();
                Console.Write("Enter a angle betwwen them: ");
                angle = Validation();
                Console.WriteLine("Area = {0:F3}", TwoSidesAndAngleBetween(firstSide, secondSide, Math.PI * angle / 180));
                break;
            default:
                Console.WriteLine("Wrong input!");
                break;
        }
    }

    static double Validation()
    {
        double val;
        while (!(double.TryParse(Console.ReadLine(), out val) && val > 0))
        {
            Console.Write("Try again: ");
        }

        return val;
    }

    static double SideAndAltitude(double side, double altitude)
    {
        double surface = 0;
        surface = side * altitude / 2;
        return surface;
    }

    static double ThreeSides(double firstSide, double secondSide, double thirdSide)
    {
        double semiPerimeter = (firstSide + secondSide + thirdSide) / 2;
        double surface = 0;
        surface = Math.Sqrt(semiPerimeter * (semiPerimeter - firstSide)
                                          * (semiPerimeter - secondSide)
                                          * (semiPerimeter - thirdSide));
        return surface;
    }

    static double TwoSidesAndAngleBetween(double firstSide, double secondSide, double angle)
    {
        double surface = 0;
        surface = firstSide * secondSide * Math.Sin(angle) / 2;
        return surface;
    }
}

