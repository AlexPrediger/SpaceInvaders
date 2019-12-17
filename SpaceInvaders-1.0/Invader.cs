using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    class Invader : AbstractMove, IShipMethods
    {
        private Parameters.InvaderTypes invaderType;
        private int invaderScore;

        public Invader(Point location, Parameters.InvaderTypes invaderType) : base(location)
        {
            this.invaderType = invaderType;
            SetImage(invaderType);
            Location = location;
        }
        public Invader(Point location) : base(location)
        {
            Image = Properties.Resources.mother;
            Image = new Bitmap(Image, new Size(40, 40));
            invaderScore = Parameters.motherScore;
            Location = location;
        }

        public void SetImage(Parameters.InvaderTypes invaderType)
        {
            switch (invaderType)
            {
                case Parameters.InvaderTypes.bug:
                    Image = Properties.Resources.bug1;
                    invaderScore = Parameters.bugScore;
                    break;
                case Parameters.InvaderTypes.satellite:
                    Image = Properties.Resources.satellite1;
                    invaderScore = Parameters.satelliteScore;
                    break;
                case Parameters.InvaderTypes.saucer:
                    Image = Properties.Resources.flyingsaucer1;
                    invaderScore = Parameters.saucerScore;
                    break;
                case Parameters.InvaderTypes.spaceship:
                    Image = Properties.Resources.spaceship1;
                    invaderScore = Parameters.spaceshipScore;
                    break;
                case Parameters.InvaderTypes.star:
                    Image = Properties.Resources.star2;
                    invaderScore = Parameters.starScore;
                    break;
                default: break;
            }
        }

        public override void Move(Parameters.Direction direction, int level)
        {
            if (direction == Parameters.Direction.Left)
            {
                location.X -= Parameters.invaderHorziontalIncreament + level / 2;
            }
            else if (direction == Parameters.Direction.Right)
            {
                location.X += Parameters.invaderHorziontalIncreament + level / 2;
            }
            else if (direction == Parameters.Direction.Down)
            {
                location.Y += Parameters.invaderVerticalIncreament + level;
            }
        }

        public int InvaderScore
        {
            get { return invaderScore; }
        }
    }
}
