using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summative_Space_Race
{
    public partial class Form1 : Form
    {
        //Players variables
        Rectangle player1 = new Rectangle(380, 200, 10, 10);
        Rectangle player2 = new Rectangle(80, 200, 10, 10);
        int playersSpeed = 5;

        //Ball variables
        int ballSize = 10;
        int ballSpeed = 8;

        //List of balls
        List<Rectangle> ballLeft = new List<Rectangle>();
        List<Rectangle> ballright = new List<Rectangle>();

        int score = 0;
        int time = 500;

        bool upPressed = false;
        bool downPressed = false;
        bool wPressed = false;
        bool sPressed = false;

        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

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

            for (int i = 0; i < ballLeft.Count; i ++)
            {
                e.Graphics.FillEllipse(whiteBrush, ballLeft[i]);
            }
            for (int i = 0; i < ballright.Count; i++)
            {
                e.Graphics.FillEllipse(whiteBrush, ballright[i]);
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

            //All commands for ballleft 
            //create new ball if it is time and different colour //////reword
            randValue = randGen.Next(0, 100);

            if (randValue < 30)
            {
                if (randValue < 25)
                {
                    randValue = randGen.Next(0, this.Height);

                    Rectangle ball = new Rectangle(0, randValue, ballSize, ballSize);
                    ballLeft.Add(ball);
                }
            }

            //Make obstacles move left to right.
            for (int i = 0; i < ballLeft.Count; i++)
            {
                int x = ballLeft[i].X + ballSpeed;
                ballLeft[i] = new Rectangle(x, ballLeft[i].Y, ballSize, ballSize);
            }

            //All commands for ballright
            if (randValue < 30)
            {
                if (randValue < 25)
                {
                    randValue = randGen.Next(0, this.Height);

                    Rectangle ball = new Rectangle(0, randValue, ballSize, ballSize);
                    ballright.Add(ball);
                }
            }

            //Make obstacles move left to right.
            for (int i = 0; i < ballright.Count; i++ )
            {
                int x = ballright[i].X - ballSpeed;
                ballright[i] = new Rectangle(x, ballright[i].Y, ballSize, ballSize);
            }

            Refresh();
        }
    }
}
