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

        public Room(Vector2 coordinates, Vector2 size)
        {
            Pos = coordinates;

            Area = size.X * size.Y;
            Layout = new Layout(size, Settings.BedRoomKey);
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
        public void moveUp()
        {
            Pos.X = (Pos.X - 1);
        }

        public void moveDown()
        {
            Pos.X = (Pos.X + 1);
        }

        public void moveRight()
        {
            Pos.Y = (Pos.Y + 1);
        }

        public void moveLeft()
        {
            Pos.Y = (Pos.Y - 1);
        }
    }
}
