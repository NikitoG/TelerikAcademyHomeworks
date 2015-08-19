//Problem 3. Sequence n matrix

//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix.

using System;
using System.Linq;

class BestSequence
{
    static int sequence = 0;
    static void Main()
    {
        //int N;
        //do
        //{
        //    Console.Write("Enter N: ");
        //} while (!(int.TryParse(Console.ReadLine(), out N)));

        //int M;
        //do
        //{
        //    Console.Write("Enter M: ");
        //} while (!(int.TryParse(Console.ReadLine(), out M)));

        //string[,] matrix = new string [N, M];
        //for (int row = 0; row < N; row++)
        //{
        //    for (int col = 0; col < M; col++)
        //    {
        //        Console.Write("matrix[{0}, {1}] = ", row, col);
        //        matrix[row, col] = Console.ReadLine();
        //    }
        //}

        string[,] matrix = { 
                            {"a",  "b",  "nik",  "a",    "b",   "c"},
                            {"a",  "b",   "c",   "nik",  "b",   "c"},
                            {"b",  "b",   "c",    "a",   "nik", "c"},
                            {"ha", "ha",  "a",    "ha",  "nik", "nik"},
                        };

        int bestSeq = 0;
        string currString = "";
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                // check row
                int checkRight = 0;
                for (int i = col; i < matrix.GetLength(1); i++)
                {
                    if (matrix[row, i] == matrix[row, col])
                    {
                        ++checkRight;
                    }
                    else
                    {
                        break;
                    }
                }
                if (checkRight > bestSeq)
                {
                    bestSeq = checkRight;
                    currString = matrix[row, col];
                }

                //check column
                int checkDown = 0;
                for (int i = row; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, col] == matrix[row, col])
                    {
                        ++checkDown;
                    }
                    else
                    {
                        break;
                    }
                }
                if (checkDown > bestSeq)
                {
                    bestSeq = checkDown;
                    currString = matrix[row, col];
                }

                //check diagonal
                int checkDiagonal = 0;
                int rowDiagonal = row;
                int colDiagonal = col;
                while (rowDiagonal < matrix.GetLength(0) && colDiagonal < matrix.GetLength(1))
                {
                    if (matrix[rowDiagonal, colDiagonal] == matrix[row, col])
                    {
                        ++checkDiagonal;
                        ++rowDiagonal;
                        ++colDiagonal;
                    }
                    else
                    {
                        break;
                    }
                }
                if (checkDiagonal > bestSeq)
                {
                    bestSeq = checkDiagonal;
                    currString = matrix[row, col];
                }

            }
        }
        string separator = "";
        for (int i = 0; i < bestSeq; i++)
        {
            Console.Write(separator);
            Console.Write(currString);
            separator = ", ";
        }
        Console.WriteLine();
    }
}
