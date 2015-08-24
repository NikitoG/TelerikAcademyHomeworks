//Problem 2. Gravitation on the Moon

//The gravitational field of the Moon is approximately 17% of that on the Earth.
//Write a program that calculates the weight of a man on the moon by a given weight on the Earth.

using System;

class WeightOnTheMoon
{
    static void Main()
    {
        Console.WriteLine("Eneter your weight in kg.:");
        double weight;
    Again:
        string strWeight = Console.ReadLine();

        if (double.TryParse(strWeight, out weight))
        {
            double weightMoon = weight * 17 / 100;
            Console.WriteLine("On the moon you will weight {0:0.000} killograms.", weightMoon);
        }
        else
        {
            Console.WriteLine("Enter your weight in killograms.");
            goto Again;
        }
                
    }
}
