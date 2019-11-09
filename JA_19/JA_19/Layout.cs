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

        public char[,] Content { get; set; }

        public Vector2 Size { get; }

        public Layout(Layout copy)
        {
            Size = new Vector2(copy.Size);
            Content = (char[,])copy.Content.Clone();
        }

        public Layout(Vector2 size, char initChar = (char)97)
        {
            Size = new Vector2(size);
            Content = new char[size.X, size.Y];
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    Content[i, j] = initChar;
                }
            }
        }

        public static Layout AsInvalid(Layout l, char invalidKey)
        {
            Layout copy = new Layout(l);
            for (int i = 0; i < l.Size.X; i++)
            {
                for (int j = 0; j < l.Size.Y; j++)
                {
                    if(l.Content[i, j] == invalidKey)
                    {
                        copy.Content[i, j] = Settings.InvalidKey;
                    }
                }
            }
            return copy;
        }

        public void AddDoor(Vector2 vector)
        {
            Content[vector.X, vector.Y] = Settings.DoorKey;
        }
    }
}
