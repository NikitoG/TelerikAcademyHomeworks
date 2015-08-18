namespace RotatingWalkInMatrix
{
    using System;

    public class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public static Cell operator +(Cell firstCell, Cell secondCell)
        {
            return new Cell(firstCell.Row + secondCell.Row, firstCell.Col + secondCell.Col);
        }
    }
}
