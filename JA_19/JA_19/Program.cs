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
            Console.SetWindowSize(33, 33);
            Layout background = Layout.EmptyLayout(new Vector2(32, 32));
            background.Content[0, 0] = Settings.WallKey;
            Room room = RoomFactory.CreateRandomRoom();

            DisplayHelper.DisplayGameState(background, room);
        }
    }
}
