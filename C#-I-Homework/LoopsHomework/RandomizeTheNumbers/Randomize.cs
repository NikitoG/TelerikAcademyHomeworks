//Problem 12.* Randomize the Numbers 1…N

//Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.

using System;

class Randomize
{
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Enter n: ");
        } while (!int.TryParse(Console.ReadLine(), out n) && n > 0);

        Random rnd = new Random();
        int[] randomNum = new int[1];
        int[] numbers = new int[n];
        int check = 0;
        bool diferentNum = false;
        for (int i = 0; i < n; i++)
        {
            do
            {
                diferentNum = false;
                randomNum[0] = rnd.Next(1, (n+1));
                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] == randomNum[0])
                    {
                        diferentNum = true;
                        break;
                    }
                }

            } while (diferentNum);

            numbers[i] = randomNum[0];
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine();


    }
        
}
