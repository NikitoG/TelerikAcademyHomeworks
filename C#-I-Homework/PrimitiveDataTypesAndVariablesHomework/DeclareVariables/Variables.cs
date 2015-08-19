//Problem 1. Declare Variables
//Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.
//Choose a large enough type for each number to ensure it will fit in it. Try to compile the code.

using System;

class Variables
{
    static void Main()
    {
        ushort firstVar = 52130;
        sbyte secondVar = -115;
        uint thirdVar = 4825932;
        byte fourthVar = 97;
        short fifthVar = -10000;

        Console.WriteLine("Variable of type ushort: " + firstVar);
        Console.WriteLine("Variable of type sbyte: " + secondVar);
        Console.WriteLine("Variable of type uint: " + thirdVar);
        Console.WriteLine("Variable of type byte: " + fourthVar);
        Console.WriteLine("Variable of type short: " + fifthVar);

    }
}
