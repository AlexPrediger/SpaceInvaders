using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders_1._0
{
    class Star
    {
        private Point point;
        private Pen pen;

        public Star(Point point, Pen pen)
        {
            this.point = point;
            this.pen = pen;
        }

        public Point Point
        {
            get { return point; }
            set { point = value; }
        }

        public Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }
    }
}
