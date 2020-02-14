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
        int counter = 0;

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
            counter++;
            hasWinner = IsWinner(button.Name);

            if (hasWinner)
            {
                DialogResult dialogRes = MessageBox.Show("The player " + button.Text + " is the winner");
                if(dialogRes == DialogResult.OK)
                {
                    ResetGame();
                }
            }
            else if (counter == 9)
            {
                MessageBox.Show("Draw!");
            }
        }

        private bool IsWinner(string buttonName)
        {
            switch (buttonName)
            {
                case "A1":
                    if (CheckRow1() || CheckColumn1() || CheckDiagonal1())
                    {
                        return true;
                    }
                    return false;
                case "A2":
                    if (CheckRow1() || CheckColumn2())
                    {
                        return true;
                    }
                    return false;
                case "A3":
                    if (CheckRow1() || CheckColumn3() || CheckDiagonal2())
                    {
                        return true;
                    }
                    return false;
                case "B1":
                    if (CheckRow2() || CheckColumn1())
                    {
                        return true;
                    }
                    return false;
                case "B2":
                    if (CheckRow2() || CheckColumn2() || CheckDiagonal1() || CheckDiagonal2())
                    {
                        return true;
                    }
                    return false;
                case "B3":
                    if (CheckRow2() || CheckColumn3())
                    {
                        return true;
                    }
                    return false;
                case "C1":
                    if (CheckRow3() || CheckColumn1() || CheckDiagonal2())
                    {
                        return true;
                    }
                    return false;
                case "C2":
                    if (CheckRow3() || CheckColumn2())
                    {
                        return true;
                    }
                    return false;
                case "C3":
                    if (CheckRow3() || CheckColumn3() || CheckDiagonal1())
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
            ResetGame();
        }

        private void ResetGame()
        {
            counter = 0;
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

        private void btn_info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic-Tac-Toe made by Jin Chen");
        }

        private void PaintButton(Button b1, Button b2, Button b3)
        {
            b1.BackColor = Color.Green;
            b2.BackColor = Color.Green;
            b3.BackColor = Color.Green;
        }

        private bool CheckRow1()
        {
            if (A1.Text == A2.Text && A1.Text == A3.Text && !string.IsNullOrEmpty(A1.Text) && !string.IsNullOrEmpty(A2.Text) && !string.IsNullOrEmpty(A3.Text))
            {
                PaintButton(A1, A2, A3);
                return true;
            }
            return false;
        }

        private bool CheckRow2()
        {
            if (B1.Text == B2.Text && B1.Text == B3.Text && !string.IsNullOrEmpty(B1.Text) && !string.IsNullOrEmpty(B2.Text) && !string.IsNullOrEmpty(B3.Text))
            {
                PaintButton(B1, B2, B3);
                return true;
            }
            return false;
        }

        private bool CheckRow3()
        {
            if (C1.Text == C2.Text && C1.Text == C3.Text && !string.IsNullOrEmpty(C1.Text) && !string.IsNullOrEmpty(C2.Text) && !string.IsNullOrEmpty(C3.Text))
            {
                PaintButton(C1, C2, C3);
                return true;
            }
            return false;
        }

        private bool CheckColumn1()
        {
            if (A1.Text == C1.Text && A1.Text == B1.Text && !string.IsNullOrEmpty(A1.Text) && !string.IsNullOrEmpty(C1.Text) && !string.IsNullOrEmpty(B1.Text))
            {
                PaintButton(A1, C1, B1);
                return true;
            }
            return false;
        }

        private bool CheckColumn2()
        {
            if (A2.Text == C2.Text && A2.Text == B2.Text && !string.IsNullOrEmpty(A2.Text) && !string.IsNullOrEmpty(C2.Text) && !string.IsNullOrEmpty(B2.Text))
            {
                PaintButton(A2, C2, B2);
                return true;
            }
            return false;
        }

        private bool CheckColumn3()
        {
            if (A3.Text == C3.Text && A3.Text == B3.Text && !string.IsNullOrEmpty(A3.Text) && !string.IsNullOrEmpty(C3.Text) && !string.IsNullOrEmpty(B3.Text))
            {
                PaintButton(A3, C3, B3);
                return true;
            }
            return false;
        }

        private bool CheckDiagonal1()
        {
            if (A1.Text == C2.Text && A1.Text == B3.Text && !string.IsNullOrEmpty(A1.Text) && !string.IsNullOrEmpty(C2.Text) && !string.IsNullOrEmpty(B3.Text))
            {
                PaintButton(A1, C2, B3);
                return true;
            }
            return false;
        }

        private bool CheckDiagonal2()
        {
            if (A3.Text == C2.Text && A3.Text == B1.Text && !string.IsNullOrEmpty(A3.Text) && !string.IsNullOrEmpty(C2.Text) && !string.IsNullOrEmpty(B1.Text))
            {
                PaintButton(A3, C2, B1);
                return true;
            }
            return false;
        }
    }
}
