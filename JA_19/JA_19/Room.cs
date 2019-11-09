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

        public int DoorAmount { get; set; }

        public Vector2 Pos { get; set; }

        public Room(int doorAmount, Vector2 coordinates, Vector2 size)
        {
            DoorAmount = doorAmount;
            Pos = coordinates;

            Area = size.X * size.Y;
            Layout = Layout.EmptyLayout(size);
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

            //TODO add door
        }
    }
}
