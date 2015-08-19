//Problem 8. Binary short

//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System;

class SignedInteger
{
    static void Main()
    {
        short number;
        do
        {
            Console.Write("Enter 16-bit signed integer number: ");
        } while (!short.TryParse(Console.ReadLine(), out number));
        int temp = number;
        int[] binaryNum = new int[16];
        if (number < 0)
        {
            binaryNum[0] = 1;
            temp = 32768 + number;
        }

        int index = 15;
        while (temp != 0)
        {
            binaryNum[index] = temp % 2;
            temp /= 2;
            --index;
        }

        Console.WriteLine("{0} in binary {1}", number, string.Join("", binaryNum));
    }
}

