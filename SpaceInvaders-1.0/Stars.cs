using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    class Stars
    {
        private List<Star> starList = new List<Star>();
        private Pen[] starColors = {Pens.Blue, Pens.White, Pens.Yellow, Pens.Red};
        private Random random = new Random();

        public Stars(Rectangle boundaries)
        {
            for (int i = 0; i < Parameters.starsInSky; i++)
            {
                Star star = GenerateRandomStar(boundaries);
                starList.Add(star);
            }
        }

        // Method to generate a Star with random coordinates at the boundaries
        public Star GenerateRandomStar (Rectangle boundaries)
        {
            int randomWidth = random.Next(boundaries.Left, boundaries.Right);
            int randomHeight = random.Next(boundaries.Top, boundaries.Bottom);

            Point randomPoint = new Point(randomWidth, randomHeight);

            Pen randomPen = starColors[random.Next(starColors.Length)];

            Star newStar = new Star(randomPoint, randomPen);

            return newStar;
        }

        // Method to draw all stars into graphics
        public void Draw(Graphics graphics, Rectangle boundaries)
        {

            graphics.FillRectangle(Brushes.Black, boundaries);

            foreach (Star star in starList)
            {
                graphics.DrawRectangle(star.Pen, star.Point.X, star.Point.Y, 5f, 5f);
            }
        }

        // Method to delete five stars and create five new
        public void Twinkle(Rectangle boundaries)
        {
            // if there is no List return 
            if (starList.Count < 1)
            {
                return;
            }

            for (int i = 0; i < 5; i++)
            {
                // for removing the five oldest stars use 
                // starList.RemoveAt(0);
                // for removing five random stars use 
                starList.RemoveAt(random.Next(starList.Count));
                starList.Add(GenerateRandomStar(boundaries));
            }
        }

    }
}
