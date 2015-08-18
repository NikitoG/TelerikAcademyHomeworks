namespace Minesweeper
{
    using System;

    public class Scores
    {
        public Scores(string name, int points)
        {
            this.PlayerName = name;
            this.PlayerPoints = points;
        }

        public string PlayerName { get; set; }

        public int PlayerPoints { get; set; }
    }
}
