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
        //Hero variables
        Rectangle hero = new Rectangle(280, 100, 10, 10);
        int heroSpeed = 10;

        //Ball variables
        int ballSize = 10;
        int ballSpeed = 8;

        //List of balls
        List<Rectangle> ballList = new List<Rectangle>();

        int score = 0;
        int time = 500;

        bool upPressed = false;
        bool downPressed = false;

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
            e.Graphics.FillRectangle(greenBrush, hero);
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
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move player 
            if (leftPressed == true && hero.X > 0)
            {
                hero.X = hero.X - heroSpeed;
            }
            if (rightPressed == true && hero.X < this.Width - hero.Width)
            {
                hero.X = hero.X + heroSpeed;
            }
            if (upPressed == true && hero.Y > 0)
            {
                hero.Y = hero.Y - heroSpeed;
            }
            if (downPressed == true && hero.Y < this.Height - hero.Height)
            {
                hero.Y = hero.Y + heroSpeed;
            }

            Refresh();
        }
    }
}
