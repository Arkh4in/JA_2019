using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public static class RoomFactory
    {
        public static Room CreateRandomRoom()
        {
            Random r = new Random();
            return new Room(r.Next(0,5), new Vector2(0, 0), new Vector2(r.Next(3, 10), r.Next(3,10)));
        }
    }
}
