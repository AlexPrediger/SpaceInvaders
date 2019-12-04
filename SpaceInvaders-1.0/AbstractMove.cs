using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    abstract class AbstractMove : Ship
    {
        public AbstractMove(Point location) : base(location)
        {

        }

        public abstract void Move(Parameters.Direction direction, int level);
    }
}
