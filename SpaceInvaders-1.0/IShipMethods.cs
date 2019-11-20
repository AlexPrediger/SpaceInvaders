using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    interface IShipMethods
    {
        void Draw(Graphics graphics);
        void Move(Parameters.Direction direction);
    }
}
