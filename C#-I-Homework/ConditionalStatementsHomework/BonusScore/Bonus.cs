//Problem 2. Bonus Score

//Write a program that applies bonus score to given score in the range [1…9] by the following rules:
//If the score is between 1 and 3, the program multiplies it by 10.
//If the score is between 4 and 6, the program multiplies it by 100.
//If the score is between 7 and 9, the program multiplies it by 1000.
//If the score is 0 or more than 9, the program prints “invalid score”.

using System;

class Bonus
{
    static void Main()
    {
        int score;
        do
        {
            Console.Write("Enter a score in the range (1....9): ");
        } while (!int.TryParse(Console.ReadLine(), out score));

        if (0 < score && score < 4)
        {
            Console.WriteLine("Score {0} -> after bonus result is: {1}", score, score * 10);
        }
        else if (3 < score && score < 7)
        {
            Console.WriteLine("Score {0} -> after bonus result is: {1}", score, score * 100);
        }
        else if (6 < score && score < 10)
        {
            Console.WriteLine("Score {0} -> after bonus result is: {1}", score, score * 1000);
        }
        else
        {
            Console.WriteLine("Invalid score!");
        }
    }
}
