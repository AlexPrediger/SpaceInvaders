using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders_1._0
{
    class ListComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            int result;

            if (x > y)
                result = -1;
            else if (x < y)
                result = 1;
            else
                result = 0;

            return result;
        }
    }
}
