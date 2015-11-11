namespace FindAllPaths
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static char[,] lab = 
                            {
                                {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                {'*', '*', ' ', '*', ' ', '*', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                {' ', '*', '*', '*', '*', '*', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
                            };

        private static Stack<int[]> path = new Stack<int[]>();

        public static void Main()
        {
            FindPathToExit(0, 0);
        }

        private static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        private static void FindPathToExit(int row, int col)
        {
            if (!InRange(row, col))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }

            // Check if we have found the exit
            if (lab[row, col] == 'e')
            {
                PrintPath(row, col);
            }

            if (lab[row, col] != ' ')
            {
                // The current cell is not free -> can't find a path
                return;
            }

            // Temporary mark the current cell as visited to avoid cycles
            lab[row, col] = 's';
            path.Push(new int[2] {row, col});

            // Invoke recursion the explore all possible directions
            FindPathToExit(row, col - 1); // left
            FindPathToExit(row - 1, col); // up
            FindPathToExit(row, col + 1); // right
            FindPathToExit(row + 1, col); // down

            // Mark back the current cell as free
            // Comment the below line to visit each cell at most once
            lab[row, col] = ' ';
            path.Peek();
        }

        private static void PrintPath(int finalRow, int finalCol)
        {
            Console.Write("Found the exit: ");
            foreach (var cell in path)
            {
                Console.Write("({0},{1}) -> ", cell[0], cell[1]);
            }
            Console.WriteLine("({0},{1})", finalRow, finalCol);
            Console.WriteLine();
        }
    }
}
