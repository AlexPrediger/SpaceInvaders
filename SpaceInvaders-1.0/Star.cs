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

        // TODO: private mit get() und set()

        public Point point;
        public Pen pen;

        public Star(Point point, Pen pen)
        {
            this.point = point;
            this.pen = pen;
        }
    }
}
