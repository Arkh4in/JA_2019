using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    class Program
    {
        //Prop & Constructors//
        static void Main(string[] args)
        {			
            Layout background = new Layout(32,32,8);
            background.Display();

            Vector2 roomCoordinates = new Vector2(5, 3);

            Room room = new Room(3, roomCoordinates, 3, 8);
        }
    }
}
