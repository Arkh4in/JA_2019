using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class Vector2
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Vector2(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
