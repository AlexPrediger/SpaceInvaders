﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    class Game
    {
        public Rectangle boundaries;
        public Stars stars;
        public Random random;

        public Game(Rectangle boundaries)
        {
            this.boundaries = boundaries;
            stars = new Stars(boundaries);
        }

        public void Draw(Graphics g)
        {
            stars.Draw(g, boundaries);
        }

        public void Twinkle()
        {

        }
    }
}
