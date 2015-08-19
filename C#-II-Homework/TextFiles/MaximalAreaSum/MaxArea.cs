//Problem 5. Maximal area sum

//Write a program that reads a text file containing a square matrix of numbers.
//Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
//The first line in the input file contains the size of matrix N.
//Each of the next N lines contain N numbers separated by space.
//The output should be a single number in a separate text file.

using System;
using System.IO;
class MaxArea
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\Files\file.txt");
            using (reader)
            {
                int n = int.Parse(reader.ReadLine());
                int[,] matrix = new int[n, n];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    string[] lineArray = reader.ReadLine().Split(' ');
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = int.Parse(lineArray[j]);
                    }
                }
                MaxSumArea(matrix);
            }
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void MaxSumArea(int[,] matrix)
    {
        int tempSum = 0;
        int maxSum = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                tempSum += (matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1]);
                if (tempSum > maxSum)
                {
                    maxSum = tempSum;
                }
                tempSum = 0;
            }
        }
        WriteInFile(maxSum);
    }
    private static void WriteInFile(int maxSum)
    {
        StreamWriter writer = new StreamWriter(@"..\..\Files\maxSum.txt");
        using (writer)
        {
            writer.WriteLine(maxSum);
        }
    }
}

