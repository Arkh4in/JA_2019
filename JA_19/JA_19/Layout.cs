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

        public char[,] Content { get; private set; }

        public Vector2 Size { get; }

        public Layout(Layout copy)
        {
            Size = new Vector2(copy.Size.x, copy.Size.y);
            Content = (char[,])copy.Content.Clone();
        }

        public Layout InvalidLayout(Layout copy)
        {
            Layout l = new Layout(copy);
            for(int i = 0; i < Size.x; i++)
            {
                for(int j = 0; j < Size.y; j++)
                {
                    l.Content[i, j] = 'g';
                }
            }
            return l;
        }

        public Layout(Vector2 size, int doorAmount)
        {
            Size = new Vector2(size.x, size.y);

            DoorCoordinatesList = new List<Vector2>();
            for(int i = 0; i < doorAmount; i++)
            {
                //TODO : set the coordinates
                DoorCoordinatesList.Add(new Vector2(0, 0));
            }

            char[,] cArray = new char[Size.x, Size.y];

            for (int i = 0; i < Size.x; i++)
            {
                for (int j = 0; j < Size.y; j++)
                {
                    cArray[i, j] = 'a';
                }
            }

            Content = cArray;
        }

        // Display //
        //TODO : to remove, use display helper
        public void Display()
        {
            foreach (char c in Content)
            {
                Console.WriteLine(c);
            }
        }
    }
}
