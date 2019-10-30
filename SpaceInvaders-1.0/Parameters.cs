using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders_1._0
{
    static class Parameters
    {
        public enum Direction
        {
            Left = 1,
            Right = 2,
            Up = 3,
            Down = 4,
        };

        //Form1 Constants
        public const int   animationTimerInterval = 330;
        public const int   gameTimerInterval = 10;

        //Stars Constants
        public const int   starsInSky = 300;

        //PlayerShip constants
        public const int   playerShipIncremeant = 4;
    }
}
