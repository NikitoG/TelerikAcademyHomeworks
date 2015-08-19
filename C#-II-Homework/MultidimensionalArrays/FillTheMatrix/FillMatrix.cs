using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheMatrix
{
    class FillMatrix
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("enter n: ");
            } while (!(int.TryParse(Console.ReadLine(), out n) && n >= 0));


            // a)
            int[,] matrix = new int[n, n];
            int num = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = num;
                    ++num;
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,-5}", matrix[row, col]);
                }
                Console.WriteLine();
            }

            // b)
            Console.WriteLine("\n \n");
            num = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, col] = num;
                        ++num;
                    }
                }
                else
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        matrix[row, col] = num;
                        ++num;
                    }
                }

            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,-5}", matrix[row, col]);
                }
                Console.WriteLine();
            }

            // c))
            Console.WriteLine("\n \n");
            num = 1;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1) - row; col++)
                {
                    matrix[(row + col), col] = num;
                    ++num;
                }
            }
            int rowC = 0;
            for (int i = 0; i < n - 1; i++)
            {
                rowC = 0;
                for (int col = i + 1; col < n - i; col++)
                {
                    matrix[rowC, col] = num;
                    ++num;
                    ++rowC;
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,-5}", matrix[row, col]);
                }
                Console.WriteLine();
            }


            // d)
            Console.WriteLine("\n \n");
            int positionX = 0;
            int positionY = 0;
            int direction = 0;
            int countDirection = 0;
            int check = n;
            int changeDirection = 1;

            for (int i = 1; i <= n * n; i++)
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
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,-5}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
