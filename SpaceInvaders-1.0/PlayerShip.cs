using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    class PlayerShip
    {
        private Point location;
        private Bitmap image;

        //Declare the properties for location and image here
        public PlayerShip(Point location)
        {
            this.image = new Bitmap(@"..\..\..\assets\images\player.png");
            location.X = location.X - this.image.Width / 2;
            location.Y = location.Y - this.image.Height;
            this.location = location;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(this.image, this.location);
        }

        // Study the use of the Enum Direction in the next method 
        public void Move(Parameters.Direction direction)
        {
            if (direction == Parameters.Direction.Left)
            {
                location.X -= Parameters.playerShipIncremeant;
            } else if (direction == Parameters.Direction.Right)
            {
                location.X += Parameters.playerShipIncremeant;
            }
        }

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
