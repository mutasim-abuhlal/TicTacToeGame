using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeGame.Properties;

namespace TicTacToeGame
{
    public partial class Form1 : Form
    {
        enum enWinner : Byte
        {
            Player1,Player2,NoWinner
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        enWinner PlayerTurn;
        stGameStatus GameStatus;

        public Form1()
        {
            InitializeComponent();
        }

        void EndGame()
        {
            GameStatus.GameOver = true;
            GameStatus.Winner = PlayerTurn;
            lbWinner.Text = GameStatus.Winner.ToString();
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        bool CheckValues(Button btn1,Button btn2, Button btn3)
        {
            if(btn1.Tag.ToString() != "?" && btn2.Tag == btn1.Tag && btn3.Tag == btn1.Tag)
            {
                btn1.BackColor = Color.Green;
                btn2.BackColor = Color.Green;
                btn3.BackColor = Color.Green;
                EndGame();
                
                return true;
            }

            return false;
        }
        void CheckWinner()
        {
            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;
        }

        void UpdateImage(Button btn)
        {
            if(btn.Tag.ToString() == "?")
            {
                switch(PlayerTurn)
                {
                    case enWinner.Player1:
                        {
                            btn.Image = Resources.X;
                            btn.Tag = "X";
                            lbPlayerTurn.Text = "Player2";
                            lbPlayerTurn.Tag = "O";
                            GameStatus.PlayCount++;
                            PlayerTurn = enWinner.Player2;
                            CheckWinner();
                            break;
                        }

                    case enWinner.Player2:
                        {
                            btn.Image = Resources.O;
                            btn.Tag = "O";
                            lbPlayerTurn.Text = "Player1";
                            lbPlayerTurn.Tag = "X";
                            GameStatus.PlayCount++;
                            PlayerTurn = enWinner.Player1;
                            CheckWinner();
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Wrong Chooice", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(GameStatus.PlayCount == 9)
            {
                MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void ResetGame(Button button)
        {
            button.BackColor = Color.Black;
            button.Image = Resources.question_mark_96;
            button.Tag = "?";
            GameStatus.PlayCount = 0;
            PlayerTurn = enWinner.Player1;
            lbPlayerTurn.Text = "Player1";
            lbPlayerTurn.Tag = "X";
            lbWinner.Text = "No Winner";
            GameStatus.Winner = enWinner.NoWinner;
        }

        void RestartGame()
        {
            ResetGame(button1);
            ResetGame(button2);
            ResetGame(button3);
            ResetGame(button4);
            ResetGame(button5);
            ResetGame(button6);
            ResetGame(button7);
            ResetGame(button8);
            ResetGame(button9);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateImage((Button)sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlayerTurn = enWinner.Player1;
            lbPlayerTurn.Text = "Player1";
            lbPlayerTurn.Tag = "X";
            lbWinner.Text = "No Winner";
            GameStatus.Winner = enWinner.NoWinner;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color PenColor = Color.White;
            Pen whitePen = new Pen(PenColor);

            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.Width = 10;

            e.Graphics.DrawLine(whitePen, 450, 260, 1000, 260);
            e.Graphics.DrawLine(whitePen, 450, 410, 1000, 410);
            e.Graphics.DrawLine(whitePen, 635, 143, 635,535);
            e.Graphics.DrawLine(whitePen, 830, 143, 830, 535);

        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
