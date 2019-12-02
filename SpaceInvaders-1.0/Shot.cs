using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    class Shot
    {
        private Rectangle boundaries;
        private Parameters.Direction direction;
        private Point location;
        private bool removeShotFlag;

        public Shot(Rectangle boundaries, Parameters.Direction direction, Point location)
        {
            this.boundaries = boundaries;
            this.direction = direction;
            this.location = location;
            removeShotFlag = false;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.White, location.X, location.Y, Parameters.shotWidth, Parameters.shotHeight);
        }

        public void Move()
        {
            if (direction == Parameters.Direction.Left)
            {
                location.X -= Parameters.shotMoveInterval;
            }
            else if (direction == Parameters.Direction.Right)
            {
                location.X += Parameters.shotMoveInterval;
            }
            else if (direction == Parameters.Direction.Up)
            {
                location.Y -= Parameters.shotMoveInterval;
            }
            else if (direction == Parameters.Direction.Down)
            {
                location.Y += Parameters.shotMoveInterval;
            }

            if (!boundaries.Contains(location))
            {
                removeShotFlag = true;
            }
        }

        public bool RemoveShotFlag
        {
            get { return removeShotFlag; }
            set { removeShotFlag = value; }
        }

        public Point Location
        {
            get { return location; }
        }
    }
}
