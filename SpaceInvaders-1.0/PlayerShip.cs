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

        // method to draw playership into graphics
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(this.image, this.location);
        }

        // method to move playership into positive and negative x and y direction
        public void Move(Parameters.Direction direction)
        {
            if (direction == Parameters.Direction.Left)
            {
                location.X -= Parameters.playerShipIncremeant;
            } else if (direction == Parameters.Direction.Right)
            {
                location.X += Parameters.playerShipIncremeant;
            } else if (direction == Parameters.Direction.Up)
            {
                location.Y -= Parameters.playerShipIncremeant;
            } else if (direction == Parameters.Direction.Down)
            {
                location.Y += Parameters.playerShipIncremeant;
            }
        }

        // set and get methods for variables of class

        public Point CenteredLocation
        {
            get { return new Point(location.X + image.Width / 2, location.Y); }
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
