namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        public static void Main()
        {
            const int MaxFreeFields = 35;

            string command = string.Empty;
            char[,] gameBoard = CreateGameBoard();
            char[,] mine = PutMines();
            int moveCount = 0;
            bool steppedOnMine = false;
            List<Scores> topPlayers = new List<Scores>(6);
            int currentRow = 0;
            int currentCol = 0;
            bool isStartOfGame = true;
            bool isEndOfGame = false;

            do
            {
                if (isStartOfGame)
                {
                    Console.WriteLine("Let`s play  “Minesweeper”. Try to find fields without mines." +
                    " Command 'top' show the scores, 'restart' starts a new game, 'exit' exit the game!");
                    DrawGameBoard(gameBoard);
                    isStartOfGame = false;
                }

                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out currentRow) &&
                    int.TryParse(command[2].ToString(), out currentCol) &&
                        currentRow <= gameBoard.GetLength(0) && currentCol <= gameBoard.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                
                switch (command)
                {
                    case "top":
                        PrintResults(topPlayers);
                        break;
                    case "restart":
                        gameBoard = CreateGameBoard();
                        mine = PutMines();
                        DrawGameBoard(gameBoard);
                        steppedOnMine = false;
                        isStartOfGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Good bye!");
                        break;
                    case "turn":
                        if (mine[currentRow, currentCol] != '*')
                        {
                            if (mine[currentRow, currentCol] == '-')
                            {
                                SetFieldValue(gameBoard, mine, currentRow, currentCol);
                                moveCount++;
                            }

                            if (MaxFreeFields == moveCount)
                            {
                                isEndOfGame = true;
                            }
                            else
                            {
                                DrawGameBoard(gameBoard);
                            }
                        }
                        else
                        {
                            steppedOnMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInavlid command!\n");
                        break;
                }

                if (steppedOnMine)
                {
                    DrawGameBoard(mine);
                    Console.Write("\nThe End! You finished with {0} points. " + "Enter your name: ", moveCount);
                    string playerName = Console.ReadLine();
                    Scores finalResult = new Scores(playerName, moveCount);
                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(finalResult);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].PlayerPoints < finalResult.PlayerPoints)
                            {
                                topPlayers.Insert(i, finalResult);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((Scores firstResult, Scores secondResult) => secondResult.PlayerName.CompareTo(firstResult.PlayerName));
                    topPlayers.Sort((Scores firstResult, Scores secondResult) => secondResult.PlayerPoints.CompareTo(firstResult.PlayerPoints));
                    PrintResults(topPlayers);

                    gameBoard = CreateGameBoard();
                    mine = PutMines();
                    moveCount = 0;
                    steppedOnMine = false;
                    isStartOfGame = true;
                }

                if (isEndOfGame)
                {
                    Console.WriteLine("\nCongratulations! Well done genius!!!.");
                    DrawGameBoard(mine);
                    Console.WriteLine("Enter your name: ");
                    string playerName = Console.ReadLine();
                    Scores finalScores = new Scores(playerName, moveCount);
                    topPlayers.Add(finalScores);
                    PrintResults(topPlayers);
                    gameBoard = CreateGameBoard();
                    mine = PutMines();
                    moveCount = 0;
                    isEndOfGame = false;
                    isStartOfGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("All rights reserved!");
            Console.WriteLine("Press any key to exit!");
            Console.Read();
        }

        private static void PrintResults(List<Scores> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} open fields", i + 1, points[i].PlayerName, points[i].PlayerPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty highscore!\n");
            }
        }

        private static void SetFieldValue(char[,] playBoard, char[,] mines, int row, int col)
        {
            char neighboursMinesCount = GetNeighboursMines(mines, row, col);
            mines[row, col] = neighboursMinesCount;
            playBoard[row, col] = neighboursMinesCount;
        }

        private static void DrawGameBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] gameBoard = new char[boardRows, boardColumns];
            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    gameBoard[row, col] = '?';
                }
            }

            return gameBoard;
        }

        private static char[,] PutMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameBoard = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    gameBoard[row, col] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int randomCoordinates = random.Next(50);
                if (!mines.Contains(randomCoordinates))
                {
                    mines.Add(randomCoordinates);
                }
            }

            foreach (int mine in mines)
            {
                int row = mine / cols;
                int col = mine % cols;
                if (col == 0 && mine != 0)
                {
                    row--;
                    col = cols;
                }
                else
                {
                    col++;
                }

                gameBoard[row, col - 1] = '*';
            }

            return gameBoard;
        }

        private static void CalculateFieldValue(char[,] playBoard)
        {
            int rows = playBoard.GetLength(0);
            int cols = playBoard.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (playBoard[row, col] != '*')
                    {
                        char neighboursMines = GetNeighboursMines(playBoard, row, col);
                        playBoard[row, col] = neighboursMines;
                    }
                }
            }
        }

        private static char GetNeighboursMines(char[,] board, int currentRow, int currentCol)
        {
            int neighboursMinesCount = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (board[currentRow - 1, currentCol] == '*')
                {
                    neighboursMinesCount++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (board[currentRow + 1, currentCol] == '*')
                {
                    neighboursMinesCount++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (board[currentRow, currentCol - 1] == '*')
                {
                    neighboursMinesCount++;
                }
            }

            if (currentCol + 1 < cols)
            {
                if (board[currentRow, currentCol + 1] == '*')
                {
                    neighboursMinesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (board[currentRow - 1, currentCol - 1] == '*')
                {
                    neighboursMinesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (board[currentRow - 1, currentCol + 1] == '*')
                {
                    neighboursMinesCount++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
            {
                if (board[currentRow + 1, currentCol - 1] == '*')
                {
                    neighboursMinesCount++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
            {
                if (board[currentRow + 1, currentCol + 1] == '*')
                {
                    neighboursMinesCount++;
                }
            }

            return char.Parse(neighboursMinesCount.ToString());
        }
    }
}