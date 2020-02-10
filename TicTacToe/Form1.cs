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
            hasWinner = IsWinner(button.Name);

            if (hasWinner)
            {
                MessageBox.Show("The player " + button.Text + " is the winner");
            }
        }

        private bool IsWinner(string buttonName)
        {
            switch (buttonName)
            {
                case "A1":
                    if((A1.Text == A2.Text && A1.Text == A3.Text) || (A1.Text == B2.Text && A1.Text == C2.Text) || (A1.Text == B1.Text && A1.Text == C1.Text))
                    {
                        return true;
                    }
                    return false;
                case "A2":
                    if ((A2.Text == A1.Text && A2.Text == A3.Text) || (A2.Text == B2.Text && A2.Text == C2.Text))
                    {
                        return true;
                    }
                    return false;
                case "A3":
                    if ((A3.Text == A1.Text && A3.Text == A2.Text) || (A3.Text == B3.Text && A3.Text == C3.Text) || (A3.Text == B2.Text && A3.Text == C1.Text))
                    {
                        return true;
                    }
                    return false;
                case "B1":
                    if ((B1.Text == A1.Text && B1.Text == C1.Text) || (B1.Text == B2.Text && B1.Text == B3.Text))
                    {
                        return true;
                    }
                    return false;
                case "B2":
                    if ((B1.Text == B2.Text && B2.Text == B3.Text) || (B2.Text == A2.Text && B2.Text == C2.Text) || (B2.Text == A1.Text && B2.Text == C3.Text) || (B2.Text == A3.Text && B2.Text == C1.Text))
                    {
                        return true;
                    }
                    return false;
                case "B3":
                    if ((B3.Text == B1.Text && B3.Text == B2.Text) || (B3.Text == A3.Text && B3.Text == C3.Text))
                    {
                        return true;
                    }
                    return false;
                case "C1":
                    if ((C1.Text == C2.Text && C1.Text == C3.Text) || (C1.Text == B1.Text && C1.Text == A1.Text) || (C1.Text == B2.Text && C1.Text == A3.Text))
                    {
                        return true;
                    }
                    return false;
                case "C2":
                    if ((C1.Text == C2.Text && C2.Text == C3.Text) || (C2.Text == B2.Text && C2.Text == A2.Text))
                    {
                        return true;
                    }
                    return false;
                case "C3":
                    if ((C3.Text == C2.Text && C3.Text == C1.Text) || (C3.Text == B3.Text && C3.Text == A3.Text) || (C3.Text == B2.Text && C3.Text == A1.Text))
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }            
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
