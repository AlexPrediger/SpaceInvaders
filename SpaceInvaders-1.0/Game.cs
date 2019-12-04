using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Media;

namespace SpaceInvaders_1._0
{
    class Game
    {
        // initialize variables in class
        private Rectangle boundaries;
        private Stars stars;
        private PlayerShip playerShip;
        private Random random;
        private List<Invader> invaders = new List<Invader>();
        private List<Shot> playerShots = new List<Shot>();
        private Parameters.Direction invaderDirection = Parameters.Direction.Right;
        private Parameters.Direction initialInvaderDirection;
        private int score;
        private List<int> scores = new List<int>();
        private int lives;
        private bool gameOver = true;
        private bool firstGame = true;
        private bool pause;

        // constructor of class Game
        public Game(Rectangle boundaries)
        {
            this.boundaries = boundaries;
            stars = new Stars(boundaries);
            random = new Random();
            initialInvaderDirection = invaderDirection;
            lives = 0;
            pause = false;
        }

        // method to start game
        public void StartGame()
        {
            firstGame = false;
            if (lives < 1)
            {
                lives = Parameters.startLives;
                score = 0;
                gameOver = false;
            }

            playerShots.Clear();
            ResetInvaders();
            playerShip = new PlayerShip(new Point(boundaries.Width / 2, boundaries.Height));
            GenerateInvaders();
        }

        // method to draw stars and playership
        public void Draw(Graphics graphics)
        {
            stars.Draw(graphics, boundaries);

            if (gameOver || pause)
            {
                DrawStartScreen(graphics);
                return;
            }

            foreach (Shot shot in playerShots)
            {
                shot.Draw(graphics);
            }

            playerShip.Draw(graphics);

            foreach (Invader invader in invaders)
            {
                invader.Draw(graphics);
            }
        }

        // method to use stars.Twinkle method
        public void Twinkle()
        {
            stars.Twinkle(this.boundaries);
        }

        // method to move playership into positive and negative x and y direction 
        public void MovePlayer(Parameters.Direction direction)
        {
            // if conditions to check if ship is out of boundaries
            if ((playerShip.Location.X < boundaries.Left + Parameters.playerShipIncremeant
                && direction == Parameters.Direction.Left)
                || (playerShip.Location.X >= boundaries.Right - Parameters.playerShipIncremeant - playerShip.Image.Width
                && direction == Parameters.Direction.Right)
                || (playerShip.Location.Y < boundaries.Top + Parameters.playerShipIncremeant
                && direction == Parameters.Direction.Up)
                || (playerShip.Location.Y >= boundaries.Bottom - Parameters.playerShipIncremeant - playerShip.Image.Height
                && direction == Parameters.Direction.Down))
            {
                return;
            }

            playerShip.Move(direction);
        }

        public void CreateOneShot()
        {
            if (playerShots.Count >= Parameters.maxShots)
            {
                return;
            }

            Shot playerShot = new Shot(boundaries, Parameters.Direction.Up, playerShip.CenteredLocation);
            playerShots.Add(playerShot);
        }

        public void FireShots()
        {
            List<Shot> newPlayerShots = new List<Shot>();
            foreach (Shot shot in playerShots)
            {
                shot.Move();
                if (shot.RemoveShotFlag == false)
                {
                    newPlayerShots.Add(shot);
                }
            }

            playerShots = newPlayerShots;
        }

        public void RemoveShots()
        {
            List<Shot> newPlayerShots = new List<Shot>();
            foreach (Shot shot in playerShots)
            {
                if (shot.RemoveShotFlag == false)
                {
                    newPlayerShots.Add(shot);
                }
            }

            playerShots = newPlayerShots;
        }

        public void GenerateInvaders()
        {
            Invader newInvader = new Invader(new Point(Parameters.invaderInitialLeft, Parameters.invaderInitialTop));

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < Parameters.invadersPerRow; j++)
                {
                    switch (i)
                    {
                        case 0:
                            newInvader.SetImage(Parameters.InvaderTypes.bug);
                            break;
                        case 1:
                            newInvader.SetImage(Parameters.InvaderTypes.saucer);
                            break;
                        case 2:
                            newInvader.SetImage(Parameters.InvaderTypes.satellite);
                            break;
                        case 3:
                            newInvader.SetImage(Parameters.InvaderTypes.spaceship);
                            break;
                        case 4:
                            newInvader.SetImage(Parameters.InvaderTypes.star);
                            break;
                        default: break;
                    }

                    invaders.Add(newInvader);
                    newInvader = new Invader(new Point (newInvader.Location.X + Parameters.invaderHorizontalSpacing, newInvader.Location.Y));
                }

                newInvader.Location = new Point(Parameters.invaderInitialLeft, newInvader.Location.Y + Parameters.invaderVerticalSpacing);
            }
        }

        public void MoveAllInvaders()
        {
            bool createNewInvaders = false;

            Invader maxWidthInvader = new Invader(new Point (boundaries.Left, 0));
            Invader minWidthInvader = new Invader(new Point(boundaries.Right), 0);

            foreach (Invader invader in invaders)
            {
                if (invader.Location.X <= minWidthInvader.Location.X)
                    minWidthInvader = invader;
                if (invader.Location.X >= maxWidthInvader.Location.X)
                    maxWidthInvader = invader;
            }

            foreach (Invader invader in invaders)
            {
                if (minWidthInvader.Location.X <= boundaries.Left)
                {
                    invader.Move(Parameters.Direction.Down);
                    invaderDirection = Parameters.Direction.Right;
                }
                else if (maxWidthInvader.Location.X + maxWidthInvader.Image.Width >= boundaries.Right)
                {
                    invader.Move(Parameters.Direction.Down);
                    invaderDirection = Parameters.Direction.Left;
                }

                if (invader.Location.Y + invader.Image.Height >= boundaries.Bottom)
                {
                    createNewInvaders = true;
                    break;
                } 
                else
                {
                    invader.Move(invaderDirection);
                }
            }

            if (createNewInvaders)
            {
                ResetInvaders();
                GenerateInvaders();
            }
        }

        public void ControlCollisionState()
        {
            foreach(Invader invader in invaders)
            {
                if (invader.Location.Y + invader.Image.Height >= playerShip.Location.Y &&
                    invader.Location.Y <= playerShip.Location.Y + playerShip.Image.Height &&
                    invader.Location.X - invader.Image.Width <= playerShip.Location.X &&
                    invader.Location.X + invader.Image.Width >= playerShip.Location.X)
                {
                    ReduceLife();
                }
            }
        }

        public void ReduceLife()
        {
            lives--;
            pause = true;

            if (lives <= 0)
            {
                gameOver = true;
                scores.Add(score);
            }
        }

        public void ResetInvaders()
        {
            invaders.Clear();
            invaderDirection = initialInvaderDirection;
        }

        public void CheckShotInvaderCollision()
        {
            if (playerShots.Count == 0)
            {
                return;
            }

            if (invaders.Count() <= 0)
            {
                ResetInvaders();
                GenerateInvaders();
            }

            for (int i = 0; i < playerShots.Count; i++)
            {
                for (int j = invaders.Count() - 1; j >= 0; j--) 
                {
                    if (invaders[j].Location.Y + invaders[j].Image.Height >= playerShots[i].Location.Y &&
                        invaders[j].Location.Y <= playerShots[i].Location.Y + Parameters.shotHeight &&
                        invaders[j].Location.X <= playerShots[i].Location.X + Parameters.shotWidth &&
                        invaders[j].Location.X + invaders[j].Image.Width >= playerShots[i].Location.X)
                    {
                        playerShots[i].RemoveShotFlag = true;
                        score += invaders[j].InvaderScore;
                        invaders.RemoveAt(j);
                    }
                }
            }
        }
        public void SaveData(string dataPath)
        {
            int scoreCount = 0;
            using (Stream ausgabe = File.Create(dataPath))
            {
                BinaryWriter writer = new BinaryWriter(ausgabe);
                scoreCount = scores.Count;
                writer.Write(scoreCount);
                foreach (int aScore in scores)
                {
                    writer.Write(aScore);
                }
            }
        }
        public void OpenData(string dataPath, Graphics g)
        {
            BinaryReader reader;
            int scoreCount = 0;
            int aScore;
            int i;
            scores.Clear();
            using (Stream eingabe = File.OpenRead(dataPath))
            {
                reader = new BinaryReader(eingabe);
                scoreCount = reader.ReadInt32();
                for (i = 0; i < scoreCount; i++)
                {
                    aScore = reader.ReadInt32();
                    scores.Add(aScore);
                }
            }
        }

        public void DrawStartScreen(Graphics g)
        {

            DrawLettersToScreen(g, "SPACE INVADERS", 30, 10f, Brushes.Red, true);
            DrawLettersToScreen(g, "Press 'S' to Start", 30, 50f, Brushes.Blue, false);
            if (firstGame)
                DrawLettersToScreen(g, "New game. Good Luck!", 30, 90f, Brushes.Red, true);
            else if (gameOver)
                DrawLettersToScreen(g, "Game Over", 30, 90f, Brushes.Red, true);
            else
                DrawLettersToScreen(g, lives + " live(s) left! Be careful", 30, 90f, Brushes.Red, true);
            DrawLettersToScreen(g, "you scored " + this.score.ToString() + " points", 30, 130f, Brushes.Blue, false);
            DrawLettersToScreen(g, "Press 'r' to read scores from disk", 20, 170f, Brushes.Red, true);
            if (scores.Count > 0)
            {
                DrawLettersToScreen(g, "Press 'w' to write scores to disk", 20, 200f, Brushes.Red, true);
                ListComparer lc = new ListComparer();
                scores.Sort(lc);
                for (int i = 0; i < scores.Count; i++)
                    DrawLettersToScreen(g, "Highscore " + (i + 1) + ": " + scores[i], 20, (float)(230 + (i * 30)), Brushes.YellowGreen, true);
            }
        }
        private void DrawLettersToScreen(Graphics g, string message, int fontSize, float
        topLocation, Brush bcolor, bool boldFlag)
        {
            Font drawFont;
            if (boldFlag)
                drawFont = new Font("Arial", fontSize, FontStyle.Bold);
            else
                drawFont = new Font("Arial", fontSize);
            SizeF stringWidth = g.MeasureString(message, drawFont);
            g.DrawString(message,
            drawFont,
            bcolor,
            (boundaries.Right / 2) - (stringWidth.Width / 2),
            topLocation);
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int Lives
        {
            get { return lives; }
        }

        public bool GameOver
        {
            get { return gameOver; }
            set { gameOver = value; }
        }

        public bool Pause
        {
            get { return pause; }
            set { pause = value; }
        }
    }
}
