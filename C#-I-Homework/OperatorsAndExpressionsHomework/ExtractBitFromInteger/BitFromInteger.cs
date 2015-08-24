//Problem 12. Extract Bit from Integer

//Write an expression that extracts from given integer n the value of given bit at index p.

using System;

class BitFromInteger
{
    static void Main()
    {
        uint intForCheck;
        do
        {
            Console.WriteLine("Enter a unsigned integer:");
        } while (!(uint.TryParse(Console.ReadLine(), out intForCheck) && intForCheck >= 0));

        int bitNumber;
        do
        {
            Console.WriteLine("Enter a bit number:");
        } while (!(int.TryParse(Console.ReadLine(), out bitNumber) && bitNumber >= 0));

        int checker = Convert.ToInt32(Math.Pow(2, (bitNumber)));

        string strIntForCheck = Convert.ToString(intForCheck, 2);
        Console.WriteLine("{0} binary representation -> {1}", intForCheck, strIntForCheck);
        Console.WriteLine("The value of bit {0} is: {1}",
            bitNumber, (intForCheck & checker) >> bitNumber);
    }
}
