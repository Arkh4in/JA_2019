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
                    ComputeDoorCoordinate();
                    _isDoorcoordinatesCached = true;
                }
                return _doorCoordinates;
            }
        }

        private void ComputeDoorCoordinate()
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    if (Content[i, j] == Settings.DoorKey)
                    {
                        _doorCoordinates.Add(new Vector2(i, j));
                    }
                }
            }
        }

        public void ResetDoorCoordinates()
        {
            _isDoorcoordinatesCached = false;
        }

        public char[,] Content { get; private set; }

        public Vector2 Size { get; }

        public Layout(Layout copy)
        {
            Size = new Vector2(copy.Size);
            Content = (char[,])copy.Content.Clone();
        }

        public Layout(Vector2 size)
        {
            Size = new Vector2(size);
            Content = new char[size.X, size.Y];
        }

        public static Layout InvalidLayout(Vector2 size)
        {
            Layout l = new Layout(size);
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    l.Content[i, j] = Settings.InvalidKey;
                }
            }
            return l;
        }

        public static Layout EmptyLayout(Vector2 size)
        {
            Layout l = new Layout(size);
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    l.Content[i, j] = Settings.EmptyKey;
                }
            }
            return l;
        }

        //public Layout(Vector2 size, char[,] content)
        //{
        //    Size = size;

        //    DoorCoordinatesList = new List<Vector2>();
        //    for(int i = 0; i < doorAmount; i++)
        //    {

        //        //TODO : set the coordinates
        //        RandomDoorCoordinates randomCoordinates = new RandomDoorCoordinates(size.X, size.Y);
        //        DoorCoordinatesList.Add(new Vector2(randomCoordinates.randomX, randomCoordinates.randomY));
        //    }

        //    char[,] cArray = new char[Size.X, Size.Y];

        //    for (int i = 0; i < Size.X; i++)
        //    {
        //        for (int j = 0; j < Size.Y; j++)
        //        {
        //            cArray[i, j] = 'a';
        //        }
        //    }

        //    Content = cArray;
        //}
    }
}
