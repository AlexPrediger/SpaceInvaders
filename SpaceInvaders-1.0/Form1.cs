using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders_1._0
{
    public partial class Form1 : Form
    {
        // initialize variables
        private Game game;
        private List<Keys> keysPressed = new List<Keys>();
        private bool gameOver = true;
        private bool nextShot = true;
        private Bitmap bitmap;
        private Graphics graphics;
        private bool keyUp = false;
        private bool keyDown = false;
        private bool keyLeft = false;
        private bool keyRight = false;
        private bool keySpace = false;

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            // Use DoubleBuffered to stop flickering at Refresh method
            this.DoubleBuffered = true;

            // Declare new game, setting game boundaries
            game = new Game(this.DisplayRectangle);

            // Start the animation timer straight away - animate stars and sets refreshing interval
            bitmap = new Bitmap(this.Width, this.Height);
            graphics = Graphics.FromImage(bitmap);
            AnimationTimer.Interval = Parameters.animationTimerInterval;
            AnimationTimer.Start();
        }

        // method to start the game through starting gametime and method StartGame of class Game
        private void StartGame()
        {
            // Start game timer
            GameTimer.Interval = Parameters.gameTimerInterval;
            GameTimer.Start();

            // Start timer for delay between shots
            ShotDelayTimer.Interval = Parameters.milliSecondsPerShot;
            ShotDelayTimer.Start();

            // Begin the game
            gameOver = false;
            game.StartGame();
        }

        // Eventhandler for animation Timerevent
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            game.Twinkle();

            // Redraw Form1
            this.Refresh();
        }

        // Eventhandler for Paintevent
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(graphics, gameOver);

            // Copy bitmap image onto Form1 graphics
            e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
        }

        private void createShot()
        {
            // if nextShot is true create another one
            if (nextShot)
            {
                game.CreateOneShot();
                nextShot = false;
                ShotDelayTimer.Stop();
                ShotDelayTimer.Start();
            }
        }

        // Eventhandler for game Timerevent
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameOver)
            {
                return;
            }

            if (keyRight)
            {
                game.MovePlayer(Parameters.Direction.Right);
            }
            else if (keyLeft)
            {
                game.MovePlayer(Parameters.Direction.Left);
            }
            else if (keyDown)
            {
                game.MovePlayer(Parameters.Direction.Down);
            }
            else if (keyUp)
            {
                game.MovePlayer(Parameters.Direction.Up);
            } 

            if (keySpace)
            {
                createShot();
            }

            game.FireShots();

            //Redraw the form
            this.Refresh();
        }

        private void ShotDelayTimer_Tick(object sender, EventArgs e)
        {
            // if Parameters.milliSecondsPerShot time in ms has passed set bool true
            nextShot = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle scenario if user wants to quit 
            if (e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.S && gameOver)
            {
                StartGame();
            }

            if (gameOver)
            {
                return;
            }

            //User wishes to start a new game
            switch (e.KeyCode)
            {
                case Keys.Up:
                    keyUp = true;
                    break;
                case Keys.Down:
                    keyDown = true;
                    break;
                case Keys.Left:
                    keyLeft = true;
                    break;
                case Keys.Right:
                    keyRight = true;
                    break;
                case Keys.Space:
                    keySpace = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //User wishes to start a new game
            switch (e.KeyCode)
            {
                case Keys.Up:
                    keyUp = false;
                    break;
                case Keys.Down:
                    keyDown = false;
                    break;
                case Keys.Left:
                    keyLeft = false;
                    break;
                case Keys.Right:
                    keyRight = false;
                    break;
                case Keys.Space:
                    keySpace = false;
                    break;
            }
        }
    }
}
