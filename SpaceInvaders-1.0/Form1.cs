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

        private Game game;
        private List<Keys> keysPressed = new List<Keys>();
        private bool gameOver = true;

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            // Use DoubleBuffered to stop flickering at Refresh method
            this.DoubleBuffered = true;

            // Declare new game, setting game boundaries
            game = new Game(this.DisplayRectangle);

            // Start the animation timer straight away - animate stars and sets refreshing interval
            AnimationTimer.Interval = Parameters.animationTimerInterval;
            AnimationTimer.Start();
        }

        private void StartGame()
        {
            // Start game timer
            GameTimer.Interval = Parameters.gameTimerInterval;
            GameTimer.Start();

            // Begin the game
            gameOver = false;
            game.StartGame();

        }

        // Eventhandler for Timerevent
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            game.Twinkle();

            // Redraw Form1
            this.Refresh();
        }

        // Eventhandler for Paintevent
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            game.Draw(graphics, gameOver);

            // Copy bitmap image onto Form1 graphics
            e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (keysPressed.Count >= 1)
                {
                    switch (keysPressed[0])
                    {
                        case Keys.Left:game.MovePlayer(Parameters.Direction.Left);
                            break;
                        case Keys.Right:game.MovePlayer(Parameters.Direction.Right);
                            break;
                        case Keys.Space:
                            // game.Fire(); 
                            break;
                    }
                }
            }

            //Redraw the form
            this.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Handel scenario if user wants to quit 
            if (e.KeyCode == Keys.Q)
                Application.Exit();

            //User wishes to start a new game
            if (gameOver && e.KeyCode == Keys.S)
            {
                StartGame();
            }
            /*    
             * Game key presses.
             * The keysPressed list contains key presses the game must deal with
             */
            if  (keysPressed.Contains(e.KeyCode))
            {
                // If key is pressed and it's already on the list then remove 
                // it and re-add it to make it next item to get processed. 
                keysPressed.Remove(e.KeyCode);
            }

            keysPressed.Add(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //When key is released, remove it from list 
            if (keysPressed.Contains(e.KeyCode))
            {
                keysPressed.Remove(e.KeyCode);
            }
        }
    }
}
