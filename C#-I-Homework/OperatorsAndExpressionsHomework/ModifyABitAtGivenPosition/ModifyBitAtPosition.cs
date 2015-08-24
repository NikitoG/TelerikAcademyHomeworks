//Problem 14. Modify a Bit at Given Position

//We are given an integer number n, a bit value v (v=0 or 1) and a position p.
//Write a sequence of operators (a few lines of C# code) that modifies n to hold 
    //the value v at the position p from the binary representation of n while preserving all other bits in n.

using System;

class ModifyBitAtPosition
{
    static void Main()
    {
        uint integer;
        do
        {
            Console.WriteLine("Enter a unsigned integer:");
        } while (!(uint.TryParse(Console.ReadLine(), out integer) && integer >= 0));

        int bitPosition;
        do
        {
            Console.WriteLine("Enter a bit position:");
        } while (!(int.TryParse(Console.ReadLine(), out bitPosition) && bitPosition >=0));

        int bitValue;
        do
        {
            Console.WriteLine("Eneter a bit value (0 or 1):");
        } while (!(int.TryParse(Console.ReadLine(), out bitValue) && (bitValue == 0 || bitValue ==1)));

        long newInteger;
        if (bitValue == 1)
        {
            newInteger = (integer | Convert.ToInt32(Math.Pow(2, (bitPosition))));
            
        }
        else
        {
            newInteger = (integer & ~Convert.ToInt32(Math.Pow(2, (bitPosition))));

        }

        Console.WriteLine("\tn = ".PadRight(32) + integer);
        Console.WriteLine("\tbinary representation of n ".PadRight(32) + Convert.ToString(integer, 2).PadLeft(32, '0'));
        Console.WriteLine("\tp = ".PadRight(32) + bitPosition);
        Console.WriteLine("\tv = ".PadRight(32) + bitValue);
        Console.WriteLine("\tbinary result = ".PadRight(32) + Convert.ToString(newInteger, 2).PadLeft(32, '0'));
        Console.WriteLine("\tresult = ".PadRight(32) + newInteger);

    }
}
