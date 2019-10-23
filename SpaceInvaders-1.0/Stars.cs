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

        public List<Star> starList = new List<Star>();
        public Pen[] starColors = {Pens.Blue, Pens.White, Pens.Yellow, Pens.Red};
        public Random random = new Random();

        public Stars(Rectangle boundaries)
        {
            for (int i = 0; i < 300; i++)
            {
                Star star = GenerateRandomStar(boundaries);
                starList.Add(star);
            }
        }

        public Star GenerateRandomStar (Rectangle boundaries)
        {
            int randomWidth = random.Next(boundaries.Left, boundaries.Right);
            int randomHeight = random.Next(boundaries.Top, boundaries.Bottom);

            Point randomPoint = new Point(randomWidth, randomHeight);

            Pen randomPen = starColors[random.Next(starColors.Length)];

            Star newStar = new Star(randomPoint, randomPen);

            return newStar;
        }

        public void Draw(Graphics g, Rectangle boundaries)
        {

            g.FillRectangle(Brushes.Black, boundaries);

            foreach (Star star in starList)
            {
                g.DrawRectangle(star.pen, star.point.X, star.point.Y, 5f, 5f);
            }

        }

        public void Twinkle(Rectangle boundaries)
        {

        }

    }
}
