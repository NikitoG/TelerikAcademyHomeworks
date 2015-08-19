//Problem 6. Four-Digit Number

//Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
//Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
//Prints on the console the number in reversed order: dcba (in our example 1102).
//Puts the last digit in the first position: dabc (in our example 1201).
//Exchanges the second and the third digits: acbd (in our example 2101).
//The number has always exactly 4 digits and cannot start with 0.

using System;

class FourDigitNumber
{
    static void Main()
    {
        int fourDigitNumber;
        do
        {
            Console.WriteLine("Enter a four-digit number (The number has always exactly 4 digits and cannot start with 0.)");
        } while (!(int.TryParse(Console.ReadLine(), out fourDigitNumber) && 
            (fourDigitNumber >= 1000) && (fourDigitNumber <= 9999)));

        int d = fourDigitNumber % 10;
        int c = (fourDigitNumber / 10) % 10;
        int b = (fourDigitNumber / 100) % 10;
        int a = fourDigitNumber/1000;

        Console.WriteLine("The sum of digit is: -> {0}", a+b+c+d);
        Console.WriteLine("The number in reversed order: " + d + c + b + a);
        Console.WriteLine("The last digit in the first position: " + d + a + b + c);
        Console.WriteLine("Exchanges the second and the third digits: " + a + c + b + d);
    }
    
}
