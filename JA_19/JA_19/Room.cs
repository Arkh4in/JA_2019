using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    class Room
    {
        //Prop & Constructors//
        public Layout RoomLayout { get; set; }
        public int Area { get; set; }
        public int DoorNb { get; set; }
        public Vector2 Coordinates { get; set; }

        public Room(int doorNb, Vector2 coordinates, int length, int width)
        {
            DoorNb = doorNb;
            Coordinates = coordinates;

            Layout layout = new Layout(length, width);
            RoomLayout = layout;

            Area = length * width;
        }

    }
}
