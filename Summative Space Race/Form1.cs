﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summative_Space_Race
{
    public partial class Form1 : Form
    {
        //Players variables
        Rectangle player1 = new Rectangle(600, 439, 10, 10);
        Rectangle player2 = new Rectangle(200, 439, 10, 10);
        int playersSpeed = 6;

        //List of balls
        List<Rectangle> ballLeft = new List<Rectangle>();
        List<int> meteoroidSpeeds = new List<int>();
        List<string> meteoroidColours = new List<string>();
        List<int> meteoroidSize = new List<int>();

        int player1Score = 0;
        int player2Score = 0;
        int time = 500;

        bool upPressed = false;
        bool downPressed = false;
        bool wPressed = false;
        bool sPressed = false;

        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush skyblueBrush = new SolidBrush(Color.SkyBlue);
        SolidBrush goldBrush = new SolidBrush(Color.Gold);

        Pen greenPen = new Pen(Color.Green, 6);

        Random randGen = new Random();
        int randValue;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Drawing Players
            e.Graphics.FillRectangle(greenBrush, player1);
            e.Graphics.FillRectangle(greenBrush, player2);

            for (int i = 0; i < ballLeft.Count(); i++)
            {
                e.Graphics.FillEllipse(whiteBrush, ballLeft[i]);
            }

            for (int i = 0; i < ballLeft.Count(); i++)
            {
                if (meteoroidColours[i] == "white")
                {
                    e.Graphics.FillEllipse(whiteBrush, ballLeft[i]);
                }
                else if (meteoroidColours[i] == "skyblue")
                {
                    e.Graphics.FillEllipse(skyblueBrush, ballLeft[i]);
                }
                else if (meteoroidColours[i] == "gold")
                {
                    e.Graphics.FillEllipse(goldBrush, ballLeft[i]);
                }
                e.Graphics.DrawLine(greenPen, 400, 450, 400, this.Height - time);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.W:
                    wPressed = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //All commands for Player 1
            //move player 1
            if (upPressed == true && player1.Y > 0)
            {
                player1.Y = player1.Y - playersSpeed;
            }
            if (downPressed == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y = player1.Y + playersSpeed;
            }

            //All commands for Player 2
            //move player 2
            if (wPressed == true && player2.Y > 0)
            {
                player2.Y = player2.Y - playersSpeed;
            }
            if (sPressed == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y = player2.Y + playersSpeed;
            }


            //create new ball if it is time and different colour ////

            //Make obstacles move left to right.
            for (int i = 0; i < ballLeft.Count; i++)
            {
                int x = ballLeft[i].X + meteoroidSpeeds[i];
                ballLeft[i] = new Rectangle(x, ballLeft[i].Y, meteoroidSize[i], meteoroidSize[i]);
            }

            //new asteroids
            randValue = randGen.Next(0, 100);

            if (randValue < 5)
            {
                randValue = randGen.Next(0, this.Height);

                Rectangle ball = new Rectangle(0, randValue, 0, 0);
                ballLeft.Add(ball);
                meteoroidColours.Add("skyblue");
                meteoroidSpeeds.Add(randGen.Next(5, 10));
                meteoroidSize.Add(randGen.Next(5, 13));
            }
            else if (randValue < 10)
            {
                randValue = randGen.Next(0, this.Height);

                Rectangle ball = new Rectangle(this.Width - 8, randValue, 0, 0);
                ballLeft.Add(ball);
                meteoroidColours.Add("skyblue");
                meteoroidSpeeds.Add(randGen.Next(-10, -5));
                meteoroidSize.Add(randGen.Next(5, 13));
            }
            else if (randValue < 15)
            {
                randValue = randGen.Next(0, this.Height);

                Rectangle ball = new Rectangle(this.Width - 8, randValue, 0, 0);
                ballLeft.Add(ball);
                meteoroidColours.Add("gold");
                meteoroidSpeeds.Add(randGen.Next(-10, -5));
                meteoroidSize.Add(randGen.Next(5, 13));
            }
            else if (randValue < 15)
            {
                randValue = randGen.Next(0, this.Height);

                Rectangle ball = new Rectangle(0, randValue, 0, 0);
                ballLeft.Add(ball);
                meteoroidColours.Add("gold");
                meteoroidSpeeds.Add(randGen.Next(5, -10));
                meteoroidSize.Add(randGen.Next(5, 13));
            }
            else if (randValue < 20)
            {
                randValue = randGen.Next(0, this.Height);

                Rectangle ball = new Rectangle(0, randValue, 0, 0);
                ballLeft.Add(ball);
                meteoroidColours.Add("white");
                meteoroidSpeeds.Add(randGen.Next(5, 10));
                meteoroidSize.Add(randGen.Next(5, 13));
            }
            else if (randValue < 20)
            {
                randValue = randGen.Next(0, this.Height);

                Rectangle ball = new Rectangle(this.Width - 8, randValue, 0, 0);
                ballLeft.Add(ball);
                meteoroidColours.Add("white");
                meteoroidSpeeds.Add(randGen.Next(-10, -5));
                meteoroidSize.Add(randGen.Next(5, 13));
            }

            //remove meteoroid from list when it goes off the screen
            for (int i = 0; i < ballLeft.Count; i++)
            {
                if (ballLeft[i].X > this.Width - 8 || ballLeft[i].X < 0)
                {
                    ballLeft.RemoveAt(i);
                    meteoroidColours.RemoveAt(i);
                    meteoroidSpeeds.RemoveAt(i);
                    meteoroidSize.RemoveAt(i);
                }
            }

            //Check if player 1 and player 2 interact with meteoroids
            for (int i = 0; i < ballLeft.Count; i++)
            {
                if (player1.IntersectsWith(ballLeft[i]))
                {
                    player1.X = 600;
                    player1.Y = 439;

                    ballLeft.RemoveAt(i);
                    meteoroidColours.RemoveAt(i);
                    meteoroidSpeeds.RemoveAt(i);
                    meteoroidSize.RemoveAt(i);
                }
                if (player2.IntersectsWith(ballLeft[i]))
                {
                    player2.X = 200;
                    player2.Y = 439;

                    ballLeft.RemoveAt(i);
                    meteoroidColours.RemoveAt(i);
                    meteoroidSpeeds.RemoveAt(i);
                    meteoroidSize.RemoveAt(i);
                }
            }

            if (player1.Y < 0)
            {
                player1Score++;
                player1ScoreLabel.Text = $"{player1Score}";

                player1.X = 600;
                player1.Y = 439;
            }
            if (player2.Y < 0)
            {
                player2Score++;
                player2ScoreLabel.Text = $"{player2Score}";

                player2.X = 200;
                player2.Y = 439;
            }

            if (player1Score == 3)
            {
                winLabel.Text = "Player1 Wins";

                gameTimer.Stop();
            }
            else if (player2Score == 3)
            {
                winLabel.Text = "Player2 Wins";

                gameTimer.Stop();
            }
            else
            {
                winLabel.Text = "Tie";

                gameTimer.Stop(); gameTimer.Stop();
            }

            time--;

            Refresh();
        }
    }
}

