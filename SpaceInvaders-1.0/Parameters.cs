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
        public enum InvaderTypes
        {
            bug = 0,
            saucer = 1,
            satellite = 2,
            spaceship = 3,
            star = 4
        };

        //Form1 Constants
        public const int   animationTimerInterval = 330;
        public const int   gameTimerInterval = 10;

        //Game Constants
        public const int startLives = 3;

        //Stars Constants
        public const int   starsInSky = 300;

        //PlayerShip constants
        public const int   playerShipIncremeant = 4;

        //Shot constants 
        public const int   maxShots = 5;
        public const int   shotMoveInterval = 8;
        public const int   shotWidth = 1;
        public const int   shotHeight = 3;
        public const int   milliSecondsPerShot = 500;

        //Invader position/movment related constants 
        public const int invadersPerRow = 6;
        public const int invaderInitialLeft = 70;
        public const int invaderInitialTop = 20;
        public const int invaderHorizontalSpacing = 90;
        public const int invaderVerticalSpacing = 60;
        public const int invaderHorziontalIncreament = 3;
        public const int invaderVerticalIncreament = 25;
        public const int invaderEdgeOfScreen = 25;
        public const int invaderImageWidths = 50;

        //Invader scores
        public const int bugScore = 25;
        public const int saucerScore = 20;
        public const int satelliteScore = 15;
        public const int spaceshipScore = 10;
        public const int starScore = 5;
    }
}
