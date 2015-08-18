namespace Problem03Loverof3
{
    using System;

    /// <summary>
    /// Game of Pesho - lover of 3.
    /// </summary>
    public class LoverOf3
    {
        private static int[,] matrix;
        private static int updateRow;
        private static int updateCol;

        /// <summary>
        /// Play a game.
        /// </summary>
        public static void Main()
        {
            string[] currentLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(currentLine[0]);
            int cols = int.Parse(currentLine[1]);
            int lines = int.Parse(Console.ReadLine());

            FillMatrix(rows, cols);

            long result = CalculateSumOfVisitedSell(lines);
            Console.WriteLine(result);
        }

        /// <summary>
        /// The method fill the board of game.
        /// </summary>
        /// <param name="rows">Integer - number of rows.</param>
        /// <param name="cols">Integer - number of cols.</param>
        public static void FillMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];
            int currentField = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == 0)
                    {
                        matrix[row, col] = currentField;
                    }
                    else
                    {
                        matrix[row, col] = matrix[row, col - 1] + 3;
                    }
                }

                currentField += 3;
            }
        }

        /// <summary>
        /// The method calculate direction and number of moves.
        /// </summary>
        /// <param name="direct">String - command.</param>
        public static void GetDirection(string direct)
        {
            if (direct.CompareTo("RU") == 0 || direct.CompareTo("UR") == 0)
            {
                updateRow = -1;
                updateCol = 1;
            }
            else if (direct.CompareTo("LU") == 0 || direct.CompareTo("UL") == 0)
            {
                updateRow = -1;
                updateCol = -1;
            }
            else if (direct.CompareTo("LD") == 0 || direct.CompareTo("DL") == 0)
            {
                updateRow = 1;
                updateCol = -1;
            }
            else if (direct.CompareTo("RD") == 0 || direct.CompareTo("DR") == 0)
            {
                updateRow = 1;
                updateCol = 1;
            }
        }

        /// <summary>
        /// Calculate sum of visited cells.
        /// </summary>
        /// <param name="numberOfMOves">Integer - number of moves.</param>
        /// <returns>Long integer - sum of cells.</returns>
        public static long CalculateSumOfVisitedSell(int numberOfMOves)
        {
            string[] currentLine;
            long result = 0;
            int currentRow = matrix.GetLength(0) - 1;
            int currentCol = 0;

            for (int row = 0; row < numberOfMOves; row++)
            {
                currentLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                GetDirection(currentLine[0]);
                for (int col = 0; col < int.Parse(currentLine[1]) - 1; col++)
                {
                    currentRow += updateRow;
                    currentCol += updateCol;

                    if (currentRow < matrix.GetLength(0) && currentCol < matrix.GetLength(1) && currentRow >= 0 && currentCol >= 0)
                    {
                        result += matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = 0;
                    }
                    else
                    {
                        currentRow -= updateRow;
                        currentCol -= updateCol;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
