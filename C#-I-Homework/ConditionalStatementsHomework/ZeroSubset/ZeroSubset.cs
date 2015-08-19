using System;

class ZeroSubset
{
    static void Main()
    {
        Console.WriteLine("Write 5 ineger number(use \"Enter\" for separate them )!");
        int[] fiveNumbers = {
                                    int.Parse(Console.ReadLine()),
                                    int.Parse(Console.ReadLine()),
                                    int.Parse(Console.ReadLine()),
                                    int.Parse(Console.ReadLine()),
                                    int.Parse(Console.ReadLine())
                                };
        int count = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int k = i + 1; k < 5; k++)
            {
                if ((fiveNumbers[i] + fiveNumbers[k]) == 0)
                {
                    Console.WriteLine("{0} + {1} = 0", fiveNumbers[i], fiveNumbers[k]);
                    count++;
                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            for (int k = i + 1; k < 4; k++)
            {
                for (int n = k + 1; n < 5; n++)
                {
                    if ((fiveNumbers[i] + fiveNumbers[k] + fiveNumbers[n]) == 0)
                    {
                        Console.WriteLine("{0} + {1} + {2} = 0", fiveNumbers[i], fiveNumbers[k], fiveNumbers[n]);
                        count++;
                    }
                }
            }
        }
        for (int i = 0; i < 2; i++)
        {
            for (int k = i + 1; k < 3; k++)
            {
                for (int n = k + 1; n < 4; n++)
                {
                    for (int m = n + 1; m < 5; m++)
                    {
                        if ((fiveNumbers[i] + fiveNumbers[k] + fiveNumbers[n] + fiveNumbers[m]) == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} + {3} = 0", fiveNumbers[i], fiveNumbers[k], fiveNumbers[n], fiveNumbers[m]);
                            count++;
                        }
                    }
                }
            }
        }

        if ((fiveNumbers[0] + fiveNumbers[1] + fiveNumbers[2] + fiveNumbers[3] + fiveNumbers[3]) + fiveNumbers[4] == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} +{4} = 0", fiveNumbers[0], fiveNumbers[1], fiveNumbers[2], fiveNumbers[3], fiveNumbers[4]);
            count++;
        }

        if (count == 0)
        {
            Console.WriteLine("no zero subset");
        }
    }
}
