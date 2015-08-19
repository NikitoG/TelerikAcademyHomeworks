//Problem 2. Binary to decimal

//Write a program to convert binary numbers to their decimal representation.

using System;

class BinToDec
{
    static void Main()
    {
        Console.Write("Enter a binary number: ");
        string binaryNum = Console.ReadLine();
        double decimalNum = 0;
        double power = binaryNum.Length - 1;

        foreach (char bit in binaryNum)
        {
            decimalNum += (bit - '0') * Math.Pow(2, power);
            --power;
        }

        Console.WriteLine("{0} in decimal {1}", binaryNum, decimalNum);
    }
}

