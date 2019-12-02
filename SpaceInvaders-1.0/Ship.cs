using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    class Ship
    {
        protected Point location;
        protected Bitmap image;

        //Declare the properties for location and image here
        public Ship(Point location)
        {
            this.location = location;
        }

        // method to draw playership into graphics
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, location);
        }

        // method to move playership into positive and negative x and y direction
        public virtual void Move(Parameters.Direction direction)
        {
            if (direction == Parameters.Direction.Left)
            {
                location.X -= Parameters.playerShipIncremeant;
            }
            else if (direction == Parameters.Direction.Right)
            {
                location.X += Parameters.playerShipIncremeant;
            }
            else if (direction == Parameters.Direction.Up)
            {
                location.Y -= Parameters.playerShipIncremeant;
            }
            else if (direction == Parameters.Direction.Down)
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
