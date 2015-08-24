//Problem 15.* Bits Exchange

//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

using System;

class BitsExchenge
{
    static void Main()
    {
        uint number;
        do
        {
            Console.WriteLine("Enter a number: ");
        } while (!uint.TryParse(Console.ReadLine(), out number));

        byte p = 3;
        byte q = 24;
        int k = 3;

        long newNumber = number;
        for (int i = 0; i < k; i++)
        {
            
            uint checker = Convert.ToUInt32(Math.Pow(2, (p+i)));
            uint checker2 = Convert.ToUInt32(Math.Pow(2, (q+i)));
            long bit = (number & checker) >> p+i;
            long bit2 = (number & checker2) >> q+i;

            if (bit == 1)
            {
                newNumber = (newNumber | Convert.ToInt32(Math.Pow(2, (q+i))));
            }
            else
            {
                newNumber = (newNumber & ~Convert.ToInt32(Math.Pow(2, (q+i))));
            }
            if (bit2 == 1)
            {
                newNumber = (newNumber | Convert.ToInt32(Math.Pow(2, (p+i))));
            }
            else
            {
                newNumber = (newNumber & ~Convert.ToInt32(Math.Pow(2, (p+i))));
            }
        }
        Console.WriteLine("\n\t{0, -32} {1}", "n = ", number);
        Console.WriteLine("\t{0, -32} {1}", "binary representation of n is ",
            Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine("\t{0, -32} {1}", "binary result is ", Convert.ToString(newNumber, 2).PadLeft(32, '0'));
        Console.WriteLine("\t{0,-32} {1, 32}", "result -> ", newNumber);
        


    }
}