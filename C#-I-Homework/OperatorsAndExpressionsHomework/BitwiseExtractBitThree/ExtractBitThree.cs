//Problem 11. Bitwise: Extract Bit #3

//Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
//The bits are counted from right to left, starting from bit #0.
//The result of the expression should be either 1 or 0.

using System;

class ExtractBitThree
{
    static void Main()
    {
        
        uint intForCheck;
        do
        {
            Console.WriteLine("Enter a unsigned integer:");
        } while (!(uint.TryParse(Console.ReadLine(), out intForCheck) && intForCheck >= 0));

        int bitNumber = 3;

        int checker = Convert.ToInt32(Math.Pow(2, (bitNumber)));

        string strIntForCheck = Convert.ToString(intForCheck, 2);
        Console.WriteLine("{0} binary representation -> {1}", intForCheck, strIntForCheck);
        Console.WriteLine( "The value of bit {0} is: {1}", 
            bitNumber, (intForCheck & checker) >> bitNumber );
    }
}
