using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class Vector2
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Vector2(Vector2 cpy)
        {
            X = cpy.X;
            Y = cpy.Y;
        }

        public Vector2(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        public static Vector2 operator + (Vector2 v1, Vector2 v2) 
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator - (Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

    }
}
