using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        // constructor of class Game
        public Game(Rectangle boundaries)
        {
            this.boundaries = boundaries;
            stars = new Stars(boundaries);
            random = new Random();
            initialInvaderDirection = invaderDirection;
        }

        // method to start game
        public void StartGame()
        {
            ResetInvaders();
            playerShip = new PlayerShip(new Point(boundaries.Width / 2, boundaries.Height));
            GenerateInvaders();
        }

        // method to draw stars and playership
        public void Draw(Graphics graphics, Boolean gameOver)
        {
            stars.Draw(graphics, boundaries);

            if (gameOver)
            {
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
            if (playerShots.Count > Parameters.maxShots)
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

            foreach(Invader invader in invaders)
            {
                if (invaders[0].Location.X <= boundaries.Left)
                {
                    invader.Move(Parameters.Direction.Down);
                    invaderDirection = Parameters.Direction.Right;
                }
                else if (invaders[Parameters.invadersPerRow - 1].Location.X + invaders[Parameters.invadersPerRow - 1].Image.Width >= boundaries.Right)
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

        public bool ControlCollisionState()
        {
            foreach(Invader invader in invaders)
            {
                if (invader.Location.Y + invader.Image.Height >= playerShip.Location.Y && 
                    (invader.Location.X - invader.Image.Width == playerShip.Location.X ||
                    invader.Location.X + invader.Image.Width == playerShip.Location.X))
                {
                    return true;
                }
            }

            return false;
        }

        public void ResetInvaders()
        {
            invaders.Clear();
            invaderDirection = initialInvaderDirection;
        }
    }
}
