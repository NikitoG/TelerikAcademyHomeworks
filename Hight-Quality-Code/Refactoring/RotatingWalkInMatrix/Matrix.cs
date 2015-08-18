namespace RotatingWalkInMatrix
{
    using System;
    using System.Text;

    public class Matrix
    {
        private readonly Cell[] target;

        private int cellIndex;
        private int size;

        public Matrix(int size)
        {
            this.Size = size;
            this.Field = new int[this.Size, this.Size];
            this.cellIndex = 0;
            this.target = new[]
                                  {
                                      new Cell(1, 1), new Cell(1, 0), new Cell(1, -1), new Cell(0, -1), new Cell(-1, -1),
                                      new Cell(-1, 0), new Cell(-1, 1), new Cell(0, 1)
                                  };

            this.FillMatrix();
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Size must be greater than zero!");
                }

                this.size = value;
            }
        }

        public int[,] Field { get; private set; }

        private void FillMatrix()
        {
            var currentCell = new Cell(0, 0);
            var currentCellValue = 1;

            while (currentCell != null)
            {
                this.Field[currentCell.Row, currentCell.Col] = currentCellValue;
                currentCell = this.GetNextCell(currentCell) ?? this.FindFirstPossibleCell();

                currentCellValue++;
            }
        }

        private Cell GetNextCell(Cell cell)
        {
            for (int ind = this.cellIndex; ind < this.target.Length + this.cellIndex; ind++)
            {
                Cell nextCell = cell + this.target[ind % this.target.Length];
                if (this.IsValidDestination(nextCell))
                {
                    this.cellIndex = ind % this.target.Length;
                    return nextCell;
                }
            }

            return null;
        }


        private Cell FindFirstPossibleCell()
        {
            Cell possibleCell = new Cell(0, 0);

            for (int row = 0; row < this.Field.GetLength(0); row++)
            {
                for (int col = 0; col < this.Field.GetLength(0); col++)
                {
                    if (this.Field[row, col] == 0)
                    {
                        this.cellIndex = 0;
                        possibleCell.Row = row;
                        possibleCell.Col = col;
                        return possibleCell;
                    }
                }
            }

            return null;
        }

        private bool IsValidDestination(Cell cell)
        {
            var isValidRow = cell.Row >= 0 && cell.Row < this.Field.GetLength(0);
            var isValidCol = cell.Col >= 0 && cell.Col < this.Field.GetLength(1);
            var isValidDestination = isValidCol && isValidRow;

            if (isValidDestination)
            {
                isValidDestination = this.Field[cell.Row, cell.Col] == 0;
            }

            return isValidDestination;
        }

        public override string ToString()
        {
            var matrixToString = new StringBuilder();
            for (int row = 0; row < this.Field.GetLength(0); row++)
            {
                for (int col = 0; col < this.Field.GetLength(1); col++)
                {
                    matrixToString.AppendFormat("{0,3}", this.Field[row, col]);
                }

                matrixToString.Append("\r\n");
            }

            return matrixToString.ToString();
        }
    }
}
