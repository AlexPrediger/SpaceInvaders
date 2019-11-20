using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    class PlayerShip : Ship, IShipMethods
    {
        //Declare the properties for location and image here
        public PlayerShip(Point location) :base(location)
        {
            Image = new Bitmap(@"..\..\..\assets\images\player.png");
            location.X = location.X - Image.Width / 2;
            location.Y = location.Y - Image.Height;
            Location = location;
        }
    }
}
