using System;

class BitAtGivenPosition
{
    static void Main()
    {
        uint intForCheck;
        do
        {
            Console.WriteLine("Enter a unsigned integer:");
        } while (!(uint.TryParse(Console.ReadLine(), out intForCheck) && intForCheck >= 0));

        int bitPosition;
        do
        {
            Console.WriteLine("Enter a bit position:");
        } while (!(int.TryParse(Console.ReadLine(), out bitPosition) && bitPosition >= 0));

        int checker = Convert.ToInt32(Math.Pow(2, (bitPosition)));

        string strIntForCheck = Convert.ToString(intForCheck, 2);
        Console.WriteLine("{0} binary representation -> \n{1}", intForCheck, strIntForCheck.PadLeft(32, '0'));
        
        int bitValue = 1;
        Console.WriteLine("{0}".PadLeft((32-bitPosition +2)), bitValue);
        bool checkBit = ((intForCheck & checker) >> bitPosition) == bitValue;
        Console.WriteLine("The integer {0} has bit at the position {1} equal to {2} --> {3}",
            intForCheck, bitPosition, bitValue, checkBit);
    }
}
