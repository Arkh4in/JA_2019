using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class Room
    {
        //Prop & Constructors//
        public Layout Layout { get; set; }

        public int Area { get; set; }

        public int DoorAmount { get; private set; }

        public Vector2 Pos { get; set; }

        public Room(Vector2 coordinates, Vector2 size, char typeKey)
        {
            Pos = coordinates;

            Area = size.X * size.Y;
            Layout = new Layout(size, typeKey);
            for(int i = 0; i < size.X; i++)
            {
                Layout.Content[i, 0] = Settings.WallKey;
                Layout.Content[i, size.Y-1] = Settings.WallKey;
            }
            for (int i = 0; i < size.Y; i++)
            {
                Layout.Content[0, i] = Settings.WallKey;
                Layout.Content[size.X-1, i] = Settings.WallKey;
            }

        }

        public void AddDoor(Vector2 vector)
        {
            Layout.AddDoor(vector);
            DoorAmount++;
        }

        // Moving Methods //
        public void MoveUp()
        {
            Pos.X = (Pos.X - 1);
        }

        public void MoveDown()
        {
            Pos.X = (Pos.X + 1);
        }

        public void MoveRight()
        {
            Pos.Y = (Pos.Y + 1);
        }

        public void MoveLeft()
        {
            Pos.Y = (Pos.Y - 1);
        }

        public void RotateCW()
        {
            Layout l = new Layout(new Vector2(Layout.Size.Y, Layout.Size.X));

            BaseRotation(l);

            for (int i = 0; i < l.Size.X; i++)
            {
                for(int j = 0; j < l.Size.Y / 2; j++)
                {
                    var buffer = l.Content[i, j];
                    l.Content[i, j] = l.Content[i, l.Size.Y - 1 - j];
                    l.Content[i, l.Size.Y - 1 - j] = buffer;
                }
            }

            Layout = l;
        }
        public void RotateACW()
        {
            Layout l = new Layout(new Vector2(Layout.Size.Y, Layout.Size.X));

            BaseRotation(l);

            for (int i = 0; i < l.Size.X / 2; i++)
            {
                for (int j = 0; j < l.Size.Y ; j++)
                {
                    var buffer = l.Content[i, j];
                    l.Content[i, j] = l.Content[l.Size.X - 1 - i, j];
                    l.Content[l.Size.X - 1 - i, j] = buffer;
                }
            }

            Layout = l;
        }

        private void BaseRotation(Layout l)
        {
            for (int i = 0; i < Layout.Size.X; i++)
            {
                for (int j = 0; j < Layout.Size.Y; j++)
                {
                    l.Content[j, i] = Layout.Content[i, j];
                }
            }
        }

    }
}
