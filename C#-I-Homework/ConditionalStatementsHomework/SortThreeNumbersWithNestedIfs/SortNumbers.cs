//Problem 7. Sort 3 Numbers with Nested Ifs

//Write a program that enters 3 real numbers and prints them sorted in descending order.
//Use nested if statements.

using System;

class SortNumbers
{
    static void Main()
    {
        Console.WriteLine("Write three real numbers.");
        double a;
        do
        {
            Console.Write("Enter first number: ");
        } while (!double.TryParse(Console.ReadLine(), out a));

        double b;
        do
        {
            Console.Write("Enter second number: ");
        } while (!double.TryParse(Console.ReadLine(), out b));

        double c;
        do
        {
            Console.Write("Enter third number: ");
        } while (!double.TryParse(Console.ReadLine(), out c));

        if (a > b)
        {
            if (a > c)
            {
                if (b > c)
                {
                    Console.WriteLine("Sorted in descending order {0} {1} {2}", a, b, c);
                }
                else
                {
                    Console.WriteLine("Sorted in descending order {0} {1} {2}", a, c, b);
                }
            }
            else
            {
                Console.WriteLine("Sorted in descending order {0} {1} {2}", c, a, b);
            }
        }
        else
        {
            if (b > c)
            {
                if (a > c)
                {
                    Console.WriteLine("Sorted in descending order {0} {1} {2}", b, a, c);
                }
                else
                {
                    Console.WriteLine("Sorted in descending order {0} {1} {2}", b, c, a);
                }

            }
            else
            {
                Console.WriteLine("Sorted in descending order {0} {1} {2}", c, b, a);
            }
        }
    }


}