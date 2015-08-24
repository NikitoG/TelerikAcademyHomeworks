//Problem 5. Formatting Numbers

//Write a program that reads 3 numbers:
//integer a (0 <= a <= 500)
//floating-point b
//floating-point c
//The program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters.
//The number a should be printed in hexadecimal, left aligned
//Then the number a should be printed in binary form, padded with zeroes
//The number b should be printed with 2 digits after the decimal point, right aligned
//The number c should be printed with 3 digits after the decimal point, left aligned.

using System;

class Formatting
{
    static void Main()
    {
        ushort firstNum;
        do
        {
            Console.Write("Enter integer 0 <= a <= 500: ");
        } while (!(ushort.TryParse(Console.ReadLine(), out firstNum) && firstNum <= 500));

        double secondNum;
        do
        {
            Console.Write("Enter integer floating-point b: ");
        } while (!(double.TryParse(Console.ReadLine(), out secondNum)));

        double thirdNum;
        do
        {
            Console.Write("Enter integer floating-point c: ");
        } while (!(double.TryParse(Console.ReadLine(), out thirdNum)));

        Console.WriteLine("|{0}|{1}|{2,10:F2}|{3,-10:0.000}|", 
            firstNum.ToString("X").PadRight(10), Convert.ToString(firstNum, 2).PadLeft(10, '0'), secondNum, thirdNum);
    }
}
