using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool xTurn = true;
        bool hasWinner = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This functions is for settling the behaviour of the tictactoe buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_player_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);

            if (button.Text != "" || hasWinner)
                return;

            button.Text = (xTurn) ? "X" : "O";
            button.ForeColor = (xTurn) ? Color.Blue : Color.Red;
            xTurn = !xTurn;
            hasWinner = IsWinner();

            if (hasWinner)
            {
                MessageBox.Show("The player " + button.Text + " is the winner");
            }
        }

        private bool IsWinner()
        {
            return false;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            hasWinner = false;
            xTurn = true;
            foreach (Control c in this.Controls)
            {
                if (c is Button button)
                {
                    button.Text = "";
                    button.BackColor = Color.White;
                }
            }
        }
    }
}
