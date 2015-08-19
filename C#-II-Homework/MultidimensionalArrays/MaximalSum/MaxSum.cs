//Problem 2. Maximal sum

//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class MaxSum
{
    static void Main()
    {
        int N;
        do
        {
            Console.Write("Enter N: ");
        } while (!(int.TryParse(Console.ReadLine(), out N)));

        int M;
        do
        {
            Console.Write("Enter M: ");
        } while (!(int.TryParse(Console.ReadLine(), out M)));

        int[,] matrix = new int[N, M];
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < M; col++)
            {
                Console.Write("matrix[{0}, {1}] = ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        //int[,] matrix = { 
        //                    {1000, 7, 9, 15, 100, 100},
        //                    {5, 11, 1, 2, 200, 200},
        //                    {10, 4, 5, 6, 100, 100},
        //                    {4, 11, 12, 13, 100, 100},
        //                };

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, -5}", matrix[row, col]);
            }
            Console.WriteLine();
        }

        int a = 3;
        if (a > N || a > M)
        {
            Console.WriteLine("Wrong input!!!");
        }
        else
        {
            int bestSum = int.MinValue;
            int sum = 0;
            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row <= matrix.GetLength(0) - a; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - a; col++)
                {
                    sum = 0;
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < a; j++)
                        {
                            sum += matrix[row + i, col + j];
                        }
                    }
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine("\n");
            for (int row = startRow; row < startRow + a; row++)
            {
                for (int col = startCol; col < startCol + a; col++)
                {
                    Console.Write("{0, -5}", matrix[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Sum = {0}", bestSum);
        }

    }
}