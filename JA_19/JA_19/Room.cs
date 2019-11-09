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
        public Layout RoomLayout { get; set; }

        public int Area { get; set; }

        public int DoorAmount { get; set; }

        public Vector2 Coordinates { get; set; }

        public Room(int doorAmount, Vector2 coordinates, int sizeX, int sizeY)
        {
            DoorAmount = doorAmount;
            Coordinates = coordinates;

            Layout layout = new Layout(sizeX, sizeY, doorAmount);
            RoomLayout = layout;

            Area = sizeX * sizeY;
        }

    }
}
