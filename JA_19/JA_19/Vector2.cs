using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class Vector2
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector2(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        public Vector2 Add(Vector2 vector2) 
        {
            int newX, newY;
            newX = this.X + vector2.X;
            newY = this.Y + vector2.Y;

            Vector2 v = new Vector2(newX, newY);
            return v;
        }

        public Vector2 Substract(Vector2 vector2)
        {
            int newX, newY;
            newX = this.X - vector2.X;
            newY = this.Y - vector2.Y;

            Vector2 v = new Vector2(newX, newY);
            return v;
        }

    }
}
