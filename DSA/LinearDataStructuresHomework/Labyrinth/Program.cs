namespace Labyrinth
{
    using System;
    using System.Text;

    class Program
    {
        private static string[,] matrix = 
        { 
            { "0", "0", "0", "x", "0", "x" },
            { "0", "x", "0", "x", "0", "x" },
            { "0", "*", "x", "0", "x", "0" },
            { "0", "x", "0", "0", "0", "0" },
            { "0", "0", "0", "x", "x", "0" },
            { "0", "0", "0", "x", "0", "x" } 
        };

        static void Main(string[] args)
        {
            CheckCell(2, 0, "0");
            FillUnreachableCell(matrix);
            Console.WriteLine(PrintMatrix(matrix));
        }

        public static string PrintMatrix(string[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.AppendFormat("{0,3}", matrix[row, col]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private static void CheckCell(int row, int col, string symbol)
        {
            if (row >= matrix.GetLength(0) || row < 0 || col >= matrix.GetLength(1) || col < 0)
            {
                return;
            }

            if (symbol == "x" || symbol == "*" || matrix[row, col] != "0")
            {
                return;
            }

            int currentSymbol = int.Parse(symbol);
            currentSymbol++;
            matrix[row, col] = currentSymbol.ToString();

            CheckCell(row, col + 1, matrix[row, col]);
            CheckCell(row + 1, col, matrix[row, col]);
            CheckCell(row, col - 1, matrix[row, col]);
            CheckCell(row - 1, col, matrix[row, col]);
        }

        private static void FillUnreachableCell(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "0")
                    {
                        matrix[row, col] = "u";
                    }
                }
            }
        }
    }
}
