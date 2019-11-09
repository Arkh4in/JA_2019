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
            Console.SetWindowSize(Settings.BackgroundSize.Y+1, Settings.BackgroundSize.X +1);
            Layout background = Layout.EmptyLayout(Settings.BackgroundSize);
            background.Content[0, 0] = Settings.WallKey;
            background.Content[2, 9] = Settings.DoorKey;
            Room room = new Room(3, new Vector2(0, 0), new Vector2(3, 8));
            room.Layout.Content[0, 0] = Settings.DoorKey;
            room.Layout.Content[2, 7] = Settings.DoorKey;

            DisplayHelper.DisplayGameState(background, room);
            for(int i = 0; i < 10; i++)
            {
                room.Pos.Y++;
                var v = DateTime.Now;
                DisplayHelper.DisplayGameState(background, room);
                var d = (DateTime.Now - v).TotalMilliseconds;
            }
        }
    }
}
