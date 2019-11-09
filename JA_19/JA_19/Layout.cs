using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class Layout
    {
        // Prop & Constructors //
        public List<Vector2> DoorCoordinatesList { get; private set; }
        public char[,] LayoutArray { get; private set;  }

        public Layout(int a, int b)
        {
            List<Vector2> doorCoordinatesList = new List<Vector2>();
            DoorCoordinatesList = doorCoordinatesList;

            char[,] cArray = new char[a, b];

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    cArray[i, j] = '0';
                }
            }

            LayoutArray = cArray;
        }

        // Display //

        public void Display()
        {
            foreach (char c in LayoutArray)
            {
                Console.WriteLine(c);
            }
        }
    }
}
