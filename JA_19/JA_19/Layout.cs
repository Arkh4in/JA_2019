using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class Layout
    {
        private bool _isDoorcoordinatesCached = false;

        private List<Vector2> _doorCoordinates = new List<Vector2>();

        public List<Vector2> DoorCoordinatesList
        {
            get
            {
                if(!_isDoorcoordinatesCached)
                {
                    for(int i = 0; i < Size.X; i++)
                    {
                        for(int j = 0; j < Size.Y; j++)
                        {
                            if(Content[i, j] == Settings.DoorKey)
                            {
                                _doorCoordinates.Add(new Vector2(i, j));
                            }
                        }
                    }
                    _isDoorcoordinatesCached = true;
                }
                return _doorCoordinates;
            }
        }

        public char[,] Content { get; private set; }

        public Vector2 Size { get; }

        public Layout(Layout copy)
        {
            Size = new Vector2(copy.Size.X, copy.Size.Y);
            Content = (char[,])copy.Content.Clone();
        }

        public Layout InvalidLayout(Layout copy)
        {
            Layout l = new Layout(copy);
            for(int i = 0; i < Size.X; i++)
            {
                for(int j = 0; j < Size.Y; j++)
                {
                    l.Content[i, j] = Settings.InvalidKey;
                }
            }
            return l;
        }

        public Layout(Vector2 size, int doorAmount)
        {
            Size = size;

            DoorCoordinatesList = new List<Vector2>();
            for(int i = 0; i < doorAmount; i++)
            {

                //TODO : set the coordinates
                RandomDoorCoordinates randomCoordinates = new RandomDoorCoordinates(size.X, size.Y);
                DoorCoordinatesList.Add(new Vector2(randomCoordinates.randomX, randomCoordinates.randomY));
            }

            char[,] cArray = new char[Size.X, Size.Y];

            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
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
