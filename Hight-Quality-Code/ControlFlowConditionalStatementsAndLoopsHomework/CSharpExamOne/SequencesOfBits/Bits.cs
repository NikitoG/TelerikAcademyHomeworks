using System;

public class Bits
{
    public static void Main()
    {
        long numbers = long.Parse(Console.ReadLine());
        long number = 0;
        long zeroes = 0;
        long ones = 0;
        long sequence0 = -1;
        long sequence1 = -1;
        long symbol = 0;
        long lastSymmbol = 0;
        for (int i = 0; i < numbers; i++)
        {
                number = long.Parse(Console.ReadLine());
                for (int j = 29; j >= 0; j--)
                {
                    long mask = 1 << j;
                    long cheker = number & mask;
                    if (cheker != 0)
                    {
                        symbol = 1;
                    }
                    else
                    {
                       symbol = 0;
                    }

                    if (symbol != lastSymmbol)
                    {
                        if (ones > sequence1)
                        {
                            sequence1 = ones;
                        }

                        if (zeroes > sequence0)
                        {
                            sequence0 = zeroes;
                        }

                        ones = 0;
                        zeroes = 0;
                    }

                    if (cheker != 0)
                    {
                        ++ones;
                        lastSymmbol = 1;
                    }
                    else
                    {
                        ++zeroes;
                        lastSymmbol = 0;
                    }
                }
        }

        Console.WriteLine(sequence1);
        Console.WriteLine(sequence0);
    }
}
