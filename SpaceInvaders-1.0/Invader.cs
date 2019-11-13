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
            this.invaderType = invaderType;
            SetImage(invaderType);
            //location.X = location.X - Image.Width / 2;
            //location.Y = location.Y - Image.Height;
            Location = location;
        }
        public Invader(Point location) : base(location)
        {
            Image = Properties.Resources.bug1;
            //location.X = location.X - Image.Width / 2;
            //location.Y = location.Y - Image.Height;
            Location = location;
        }

        public void SetImage(Parameters.InvaderTypes invaderType)
        {
            switch (invaderType)
            {
                case Parameters.InvaderTypes.bug:
                    Image = Properties.Resources.bug1;
                    break;
                case Parameters.InvaderTypes.satellite:
                    Image = Properties.Resources.satellite1;
                    break;
                case Parameters.InvaderTypes.saucer:
                    Image = Properties.Resources.flyingsaucer1;
                    break;
                case Parameters.InvaderTypes.spaceship:
                    Image = Properties.Resources.spaceship1;
                    break;
                case Parameters.InvaderTypes.star:
                    Image = Properties.Resources.star2;
                    break;
                default: break;
            }
        }
    }
}
