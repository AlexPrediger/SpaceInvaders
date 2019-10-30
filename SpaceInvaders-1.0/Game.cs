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
        private Rectangle boundaries;
        private Stars stars;
        private PlayerShip playerShip;
        private Random random;


        public Game(Rectangle boundaries)
        {
            this.boundaries = boundaries;
            stars = new Stars(boundaries);
            random = new Random();
        }

        public void StartGame()
        {
            playerShip = new PlayerShip(new Point(boundaries.Width/2, boundaries.Height));
        }

        public void Draw(Graphics graphics, Boolean gameOver)
        {
            stars.Draw(graphics, boundaries);

            if (gameOver)
            {
                return;
            }

            playerShip.Draw(graphics);
        }

        public void Twinkle()
        {
            stars.Twinkle(this.boundaries);
        }

        public void MovePlayer(Parameters.Direction direction)
        {
            // Move, first checking that the ship does not go outside the  
            // boundaries with the move 
            // Implement this method on your own.

            if ((playerShip.Location.X < boundaries.Left + Parameters.playerShipIncremeant 
                && direction == Parameters.Direction.Left)
                || (playerShip.Location.X >= boundaries.Right - Parameters.playerShipIncremeant - playerShip.Image.Width
                && direction == Parameters.Direction.Right))
            {
                return;
            }

            playerShip.Move(direction);
        }
    }
}
