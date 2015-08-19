//Problem 19.** Spiral Matrix

//Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below.

using System;

class Spiral
{
    static void Main()
    {
        byte n;
        do
        {
            Console.Write("enter a n: ");
        } while (!(byte.TryParse(Console.ReadLine(), out n)) && n > 0);

        int[,] matrix = new int[n,n];
        byte positionX = 0;
        byte positionY = 0;
        int direction = 0;
        byte countDirection = 0;
        byte check = n;
        byte changeDirection = 1;

        for (int i = 1; i <= n*n; i++)
        {
            if (changeDirection > 1)
            {
                check -= 1;
                changeDirection = 0;
            }
            matrix[positionX, positionY] = i;
            ++countDirection;
            if (countDirection == check)
            {
                countDirection = 0;
                ++direction;
                ++changeDirection;
                if (direction > 3)
                {
                    direction = direction % 4;
                }
            }
            switch (direction)
            {
                case 0:
                    positionX++;
                    break;
                case 1:
                    positionY++;
                    break;
                case 2:
                    positionX--;
                    break;
                case 3:
                    positionY--;
                    break;
            }
          
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                Console.Write("{0, 4}", matrix[x,y]);
            }
            Console.WriteLine();
        }

    }

}
