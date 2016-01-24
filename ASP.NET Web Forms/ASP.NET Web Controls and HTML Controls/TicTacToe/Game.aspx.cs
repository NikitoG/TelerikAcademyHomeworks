using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicTacToe
{
    public partial class Game : System.Web.UI.Page
    {
        private const string PlayerSign = "X";
        private const string ComputerSign = "0";
        private int[,] board = new int[3, 3];
        private bool remmy = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.result.Text = "";

            var row = 0;
            var col = 0;
            foreach (Control c in Page.Controls)
            {
                foreach (Control item in c.Controls)
                {
                    if (item is Button && item.ID != "NewGame")
                    {
                        switch (((Button)item).Text)
                        {
                            case "-": board[row, col] = 0; remmy = false ; break;
                            case "X": board[row, col] = 1; break;
                            case "0": board[row, col] = 2; break;
                        }
                        if(col < 2)
                        {
                            col++;
                        }
                        else
                        {
                            row++;
                            col = 0;
                        }
                    }
                }
            }
        }

        void Page_PreRender(object sender, EventArgs e)
        {
            if (remmy)
            {
                this.result.Text = "Game over! Tie Game!";
                this.LabelTie.Text = (int.Parse(this.LabelTie.Text) + 1).ToString();
            }
        }

        protected void NewGame_Click(object sender, EventArgs e)
        {
            foreach (Control c in Page.Controls)
            {
                foreach (Control item in c.Controls)
                {
                    if (item is Button && item.ID != "NewGame")
                    {
                        ((Button)item).Text = "-";
                        ((Button)item).Enabled = true;
                    }
                }
            }

            this.result.Text = "";
        }

        private void ProcessGame()
        {
            if(this.HasWinner())
            {
                this.result.Text = "Game Over! You win, congratulations!";
                this.LabelWin.Text = (int.Parse(this.LabelWin.Text) + 1).ToString();
            }
            else
            {
                this.ComputerMove();
                if (this.HasWinner())
                {
                    this.result.Text = "Game Over! You loss, try again!";
                    this.LabelLoss.Text = (int.Parse(this.LabelLoss.Text) + 1).ToString();
                }
            }
        }

        private void ComputerMove()
        {
            var countComputers = 0;
            var countPlayers = 0;
            var lastFree = -1;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if(board[row, col] == 1)
                    {
                        countPlayers++;
                    } 
                    else if(board[row, col] == 2)
                    {
                        countComputers++;
                    } 
                    else
                    {
                        lastFree = col;
                    }
                }

                if(countComputers == 2 && lastFree != -1)
                {
                    this.RenderComputerMove(row, lastFree);
                    this.HasWinner();
                    return;
                }

                if(countPlayers == 2 && lastFree != -1)
                {
                    this.RenderComputerMove(row, lastFree);
                    return;
                }

                countComputers = 0;
                countPlayers = 0;
                lastFree = -1;
            }

            countComputers = 0;
            countPlayers = 0;
            lastFree = -1;

            for (int col = 0; col < board.GetLength(1); col++)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    if (board[row, col] == 1)
                    {
                        countPlayers++;
                    }
                    else if (board[row, col] == 2)
                    {
                        countComputers++;
                    }
                    else
                    {
                        lastFree = row;
                    }
                }

                if (countComputers == 2 && lastFree != -1)
                {
                    this.RenderComputerMove(lastFree, col);
                    this.HasWinner();
                    return;
                }

                if (countPlayers == 2 && lastFree != -1)
                {
                    this.RenderComputerMove(lastFree, col);
                    return;
                }

                countComputers = 0;
                countPlayers = 0;
                lastFree = -1;
            }

            var diagonal = new[] { board[0, 0], board[1, 1], board[2, 2] };
            countComputers = 0;
            countPlayers = 0;
            lastFree = -1;

            for (int i = 0; i < diagonal.Length; i++)
            {
                if (diagonal[i] == 1)
                {
                    countPlayers++;
                }
                else if (diagonal[i] == 2)
                {
                    countComputers++;
                }
                else
                {
                    lastFree = i;
                }
            }

            if (countComputers == 2 && lastFree != -1)
            {
                this.RenderComputerMove(lastFree, lastFree);
                this.HasWinner();
                return;
            }

            if (countPlayers == 2 && lastFree != -1)
            {
                this.RenderComputerMove(lastFree, lastFree);
                return;
            }

            diagonal = new[] { board[0, 2], board[1, 1], board[2, 0] };
            countComputers = 0;
            countPlayers = 0;
            lastFree = -1;

            for (int i = 0; i < diagonal.Length; i++)
            {
                if (diagonal[i] == 1)
                {
                    countPlayers++;
                }
                else if (diagonal[i] == 2)
                {
                    countComputers++;
                }
                else
                {
                    lastFree = i;
                }
            }

            if (countComputers == 2 && lastFree != -1)
            {
                this.RenderComputerMove(lastFree, 2 - lastFree);
                this.HasWinner();
                return;
            }

            if (countPlayers == 2 && lastFree != -1)
            {
                this.RenderComputerMove(lastFree, 2 - lastFree);
                return;
            }

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if(board[row, col] == 0)
                    {
                        this.RenderComputerMove(row, col);
                        return;
                    }
                }
            }
        }

        private void RenderComputerMove(int row, int col)
        {
            this.remmy = false;
            board[row, col] = 2;
            if(row == 0)
            {
                switch (col)
                {
                    case 0: this.Button00.Text = ComputerSign; this.Button00.Enabled = false; break;
                    case 1: this.Button01.Text = ComputerSign; this.Button01.Enabled = false; break;
                    case 2: this.Button02.Text = ComputerSign; this.Button02.Enabled = false; break;
                }
            }
            else if (row == 1)
            {
                switch (col)
                {
                    case 0: this.Button10.Text = ComputerSign; this.Button10.Enabled = false; break;
                    case 1: this.Button11.Text = ComputerSign; this.Button11.Enabled = false; break;
                    case 2: this.Button12.Text = ComputerSign; this.Button12.Enabled = false; break;
                }
            }
            else
            {
                switch (col)
                {
                    case 0: this.Button20.Text = ComputerSign; this.Button20.Enabled = false; break;
                    case 1: this.Button21.Text = ComputerSign; this.Button21.Enabled = false; break;
                    case 2: this.Button22.Text = ComputerSign; this.Button22.Enabled = false; break;
                }
            }
        }

        private bool HasWinner()
        {
            if(board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2] && board[0, 0] != 0 ||
                board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2] && board[1, 0] != 0 ||
                board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2] && board[2, 0] != 0 ||
                board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0] && board[0, 0] != 0 ||
                board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] && board[0, 1] != 0 ||
                board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2] && board[0, 2] != 0 ||
                board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] != 0 ||
                board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] != 0)
            {
                return true;
            }
            return false;
        }

        protected void Button00_Click(object sender, EventArgs e)
        {
            board[0, 0] = 1;
            this.Button00.Text = PlayerSign;
            this.Button00.Enabled = false;
            this.ProcessGame();
        }

        protected void Button01_Click(object sender, EventArgs e)
        {
            board[0, 1] = 1;
            this.Button01.Text = PlayerSign;
            this.Button01.Enabled = false;
            this.ProcessGame();
        }

        protected void Button02_Click(object sender, EventArgs e)
        {
            board[0, 2] = 1;
            this.Button02.Text = PlayerSign;
            this.Button02.Enabled = false;
            this.ProcessGame();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            board[1, 0] = 1;
            this.Button10.Text = PlayerSign;
            this.Button10.Enabled = false;
            this.ProcessGame();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            board[1, 1] = 1;
            this.Button11.Text = PlayerSign;
            this.Button11.Enabled = false;
            this.ProcessGame();
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            board[1, 2] = 1;
            this.Button12.Text = PlayerSign;
            this.Button12.Enabled = false;
            this.ProcessGame();
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            board[2, 0] = 1;
            this.Button20.Text = PlayerSign;
            this.Button20.Enabled = false;
            this.ProcessGame();
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            board[2, 1] = 1;
            this.Button21.Text = PlayerSign;
            this.Button21.Enabled = false;
            this.ProcessGame();
        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            board[2, 2] = 1;
            this.Button22.Text = PlayerSign;
            this.Button22.Enabled = false;
            this.ProcessGame();
        }
    }
}