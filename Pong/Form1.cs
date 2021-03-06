﻿/*
 * Description:     A basic PONG simulator
 * Author:          Andrew Langford 
 * Date:            Feb 06 2020
 */

#region libraries

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

#endregion

namespace Pong
{
    public partial class Form1 : Form
    {
        #region global values

        Random rangen = new Random();
        int rando = 3;

        bool ai = false;
        //graphics objects for drawing
        SolidBrush drawBrush = new SolidBrush(Color.White);
        SolidBrush red = new SolidBrush(Color.Red);
        SolidBrush blue = new SolidBrush(Color.Blue);

        SolidBrush green = new SolidBrush(Color.Green);
        SolidBrush orange = new SolidBrush(Color.Orange);
        SolidBrush purple = new SolidBrush(Color.Purple);
        Font drawFont = new Font("Comic Sans Ms", 10);

        // Sounds for game
        SoundPlayer scoreSound = new SoundPlayer(Properties.Resources.score);
        SoundPlayer collisionSound = new SoundPlayer(Properties.Resources.collision);
        SoundPlayer wallB = new SoundPlayer(Properties.Resources.wallBounce);
        SoundPlayer paddleSound = new SoundPlayer(Properties.Resources.paddleHit);

        //determines whether a key is being pressed or not
        Boolean aKeyDown, zKeyDown, jKeyDown, mKeyDown;

        // check to see if a new game can be started
        Boolean newGameOk = false;

        //ball directions, speed, and rectangle
        Boolean ballMoveRight = true;
        Boolean ballMoveDown = false;
        int BALL_SPEED = 4;
        Rectangle ball;

        //paddle speeds and rectangles
        const int PADDLE_SPEED = 6;
        Rectangle p1, p2;

        //player and game scores
        int player1Score = 0;
        int player2Score = 0;
        int gameWinScore = 5;  // number of points needed to win game

        #endregion

        public Form1()
        {
            InitializeComponent();


        }
        // -- YOU DO NOT NEED TO MAKE CHANGES TO THIS METHOD
        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.Z:
                    zKeyDown = true;
                    break;
                case Keys.J:
                    jKeyDown = true;
                    break;
                case Keys.M:
                    mKeyDown = true;
                    break;
                case Keys.Y:
                    break;
                case Keys.N:
                    if (newGameOk)
                    {
                        Close();
                    }
                    break;
            }
        }

        // -- YOU DO NOT NEED TO MAKE CHANGES TO THIS METHOD
        public void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.Z:
                    zKeyDown = false;
                    break;
                case Keys.J:
                    jKeyDown = false;
                    break;
                case Keys.M:
                    mKeyDown = false;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void SetParameters()
        {
            if (newGameOk)
            {
                player1Score = player2Score = 0;
                newGameOk = false;
                startLabel.Visible = false;

                aiButton.Visible = false;
                twoP.Visible = false;

                gameUpdateLoop.Start();
                this.Focus();
            }


            aiButton.Visible = false;
            twoP.Visible = false;
            //set starting position for paddles on new game and point scored 
            const int PADDLE_EDGE = 20;  // buffer distance between screen edge and paddle            

            p1.Width = p2.Width = 10;    //height for both paddles set the same
            p1.Height = p2.Height = 60;  //width for both paddles set the same

            //p1 starting position
            p1.X = PADDLE_EDGE;
            p1.Y = this.Height / 2 - p1.Height / 2;

            //p2 starting position
            p2.X = this.Width - PADDLE_EDGE - p2.Width;
            p2.Y = this.Height / 2 - p2.Height / 2;

            // TODO set Width and Height of ball
            ball.Height = 100;
            ball.Width = 100;
            // TODO set starting X position for ball to middle of screen, (use this.Width and ball.Width)
            ball.X = (this.Width / 2) - ball.Width / 2;
            // TODO set starting Y position for ball to middle of screen, (use this.Height and ball.Height)
            ball.Y = (this.Height / 2) - ball.Height / 2;
            sizeGen();
            BALL_SPEED = 4;
        }

        public void AiButton_Click(object sender, EventArgs e)
        {
            
            ai = true;
            newGameOk = true;
            if (newGameOk)
            {
                SetParameters();


            }
        }

        public void TwoP_Click(object sender, EventArgs e)
        {
            
            ai = false;
            newGameOk = true;
            if (newGameOk)
            {
                SetParameters();

            }
        }

        /// <summary>
        /// This method is the game engine loop that updates the position of all elements
        ///
        /// and checks for collisions.
        /// </summary>
        /// 
        public void gameUpdateLoop_Tick(object sender, EventArgs e)
        {

            p1Score.Text = Convert.ToString(player1Score);
            p2Score.Text = Convert.ToString(player2Score);

            #region update ball position

            if (ballMoveRight == true)
            {
                ball.X = ball.X + BALL_SPEED;
            }
            else if (ballMoveRight == false)
            {
                ball.X = ball.X - BALL_SPEED;
            }

            if (ballMoveDown == true)
            {
                ball.Y = ball.Y + BALL_SPEED;
            }
            else if (ballMoveDown == false)
            {
                ball.Y = ball.Y - BALL_SPEED;
            }

            #endregion

            #region update paddle positions
            //ai code
            if(p2.Y + p2.Height/2 > ball.Y + ball.Height / 2 && ai == true)
            {
                p2.Y = p2.Y - PADDLE_SPEED;
            }
            else if (p2.Y + p2.Height / 2 < ball.Y + ball.Height / 2 && ai == true)
            {
                p2.Y = p2.Y + PADDLE_SPEED;
            }

            if (aKeyDown == true && p1.Y > 0)
            {
                p1.Y = p1.Y - PADDLE_SPEED;
            }

            if (zKeyDown == true && p1.Y < this.Height - p1.Height)
            {
                p1.Y = p1.Y + PADDLE_SPEED;
            }

            if (jKeyDown == true && p2.Y > 0 && ai == false)
            {
                p2.Y = p2.Y - PADDLE_SPEED;
            }

            if (mKeyDown == true && p2.Y < this.Height - p2.Height && ai == false)
            {
                p2.Y = p2.Y + PADDLE_SPEED;
            }

            #endregion

            #region ball collision with top and bottom lines

            if (ball.Y < 0) // if ball hits top line
            {
                ballMoveDown = true;
                collisionSound.Play();
            }

            else if (ball.Y > this.Height - ball.Width)
            {
                ballMoveDown = false;
                collisionSound.Play();

            }
            #endregion

            #region ball collision with paddles

            if (ball.IntersectsWith(p2))
            {
                ballMoveRight = false;
                collisionSound.Play();
                BALL_SPEED++;
                sizeGen();

            }
            if (ball.IntersectsWith(p1))
            {
                ballMoveRight = true;
                collisionSound.Play();
                BALL_SPEED++;
                sizeGen();

            }

            #endregion

            #region ball collision with side walls (point scored)

            if (ball.X < 0 - ball.Width)
            {
                scoreSound.Play();
                player2Score++;

                if (player2Score >= 5)
                {
                    GameOver(winner: "PLAYER 2");

                }
                else
                {
                    SetParameters();
                }

            }

            if (ball.X > this.Width)
            {
                scoreSound.Play();
                player1Score++;

                if (player1Score >= 5)
                {
                    GameOver(winner: "PLAYER 1");
                }
                else
                {
                    SetParameters();
                }
            }

            #endregion

            //refresh the screen, which causes the Form1_Paint method to run
            this.Refresh();
        }
        public void sizeGen()
        {

            rando = rangen.Next(1, 11);

            if (rando == 1 || rando == 2 || rando == 3 || rando == 4 || rando == 5 || rando == 6 || rando == 7 || rando == 8 || rando == 9)
            {
                ball.Width = 50;
                ball.Height = 50;
            }
            else if (rando == 10)
            {
                ball.Width = 10;
                ball.Height = 10;
            }
            
        }
        /// <param name="winner">The player name to be shown as the winner</param>
        private void GameOver(string winner)
        {
            


            gameUpdateLoop.Stop();
            startLabel.Visible = true;

            aiButton.Visible = true;
            twoP.Visible = true;

            startLabel.Text = winner + " WINS!!!";
            p1Score.Text = Convert.ToString(player1Score);
            p2Score.Text = Convert.ToString(player2Score);
            this.Refresh();
            // --- pause for two seconds 
            Thread.Sleep(2000);
            this.Refresh();
            sizeGen();
            BALL_SPEED = 4;

            newGameOk = true;
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            // TODO draw paddles using FillRectangle
            e.Graphics.FillRectangle(red, p1);
            e.Graphics.FillRectangle(blue, p2);
            // TODO draw ball using FillRectangle
            e.Graphics.FillRectangle(purple, ball);



        }

    }
}
