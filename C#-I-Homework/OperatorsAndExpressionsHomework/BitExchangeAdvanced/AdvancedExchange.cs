//Problem 16.** Bit Exchange (Advanced)

//Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
//The first and the second sequence of bits may not overlap.

using System;

class AdvancedExchange
{
    static void Main()
    {
        long number;
        do
        {
            Console.WriteLine("Enter a number: ");
        } while (!long.TryParse(Console.ReadLine(), out number));

        sbyte p;
        do
        {
            Console.WriteLine("Enter a p: ");
        } while (!(sbyte.TryParse(Console.ReadLine(), out p)));

        sbyte q;
        do
        {
            Console.WriteLine("Enter a q: ");
        } while (!(sbyte.TryParse(Console.ReadLine(), out q)));

        int k;
        do
        {
            Console.WriteLine("Enter a k: ");
        } while (!(int.TryParse(Console.ReadLine(), out k)));

        if( p + k >= q && q + k >= p && p >= 0 && q >= 0 && k >= 0)
        {
            Console.WriteLine("\n\t{0, -32} {1}","n = ", number);
            Console.WriteLine("\t{0, -32} {1}", "binary representation of n is ", 
                Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine("\tbinary result is");
            Console.WriteLine("\t{0,-32} {1, 32}", "result  ->", "overlapping");
        }
        else if (p + k > 32 || q + k > 32 || p < 0 || q < 0 || k < 0 || p > 32 || q > 32 || k > 31 || number > uint.MaxValue)
        {
            Console.WriteLine("\n\t{0, -32} {1}", "n = ", number);
            Console.WriteLine("\t{0, -32} {1}", "binary representation of n is ",
                Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine("\tbinary result is");
            Console.WriteLine("\t{0,-32} {1, 32}", "result  ->", "out of range");
        }
        else
        {
            long newNumber = number;
            for (int i = 0; i < k; i++)
            {

                uint checker = Convert.ToUInt32(Math.Pow(2, (p + i)));
                uint checker2 = Convert.ToUInt32(Math.Pow(2, (q + i)));
                long bit = (number & checker) >> p + i;
                long bit2 = (number & checker2) >> q + i;

                if (bit == 1)
                {
                    newNumber = (newNumber | Convert.ToInt64(Math.Pow(2, (q + i))));
                }
                else
                {
                    newNumber = (newNumber & ~Convert.ToInt64(Math.Pow(2, (q + i))));
                }
                if (bit2 == 1)
                {
                    newNumber = (newNumber | Convert.ToInt64(Math.Pow(2, (p + i))));
                }
                else
                {
                    newNumber = (newNumber & ~Convert.ToInt64(Math.Pow(2, (p + i))));
                }
            }
            Console.WriteLine("\n\t{0, -32} {1}", "n = ", number);
            Console.WriteLine("\t{0, -32} {1}", "binary representation of n is ",
                Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine("\t{0, -32} {1}", "binary result is ", Convert.ToString(newNumber, 2).PadLeft(32, '0'));
            Console.WriteLine("\t{0,-32} {1, 32}", "result -> ", newNumber);
        }
    }
}
