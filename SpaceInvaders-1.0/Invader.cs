using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    class Invader : Ship
    {
        private Parameters.InvaderTypes invaderType;

        public Invader(Point location, Parameters.InvaderTypes invaderType) : base(location)
        {
            Image = Properties.Resources.bug1;
            location.X = location.X - Image.Width / 2;
            //location.Y = location.Y - Image.Height;
            Location = location;
            this.invaderType = invaderType;
        }
    }
}
