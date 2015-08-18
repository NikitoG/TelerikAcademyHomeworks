using System;
using System.Numerics;

public class Maslan
{
    public static void Main()
    {
        long input = long.Parse(Console.ReadLine());

        BigInteger oddSum = 0;
        BigInteger product = 1;
        BigInteger number = 0;
        BigInteger checker = input;
        byte transformation = 0;

        while ((transformation < 10) && (checker > 9))
        {
            while (checker != 0)
            {
                checker /= 10;
                number = checker;
                int lenght = number.ToString().Length;
                if (lenght % 2 == 0)
                {
                    for (int i = 0; i < lenght; i++)
                    {
                        if (i % 2 == 0)
                        {
                            oddSum += number % 10;
                        }

                        number /= 10;
                    }

                    if (oddSum != 0)
                    {
                        product *= oddSum;
                    }

                    oddSum = 0;
                }
                else
                {
                    for (int i = 0; i < lenght; i++)
                    {
                        if (i % 2 != 0)
                        {
                            oddSum += number % 10;
                        }

                        number /= 10;
                    }

                    if (oddSum != 0)
                    {
                        product *= oddSum * oddSum;
                    }

                    checker /= 10;
                    oddSum = 0;
                }
            }

            ++transformation;
            checker = product;
            product = 1;
        }

        if (transformation < 10)
        {
            Console.WriteLine(transformation);
            Console.WriteLine(checker);
        }
        else
        {
            Console.WriteLine(checker);
        }
    }
}
