using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class Settings
    {
        public static char EmptyKey = (char)(ConsoleColor.Black + 97);
        public static char DoorKey = (char)(ConsoleColor.White + 97);
        public static char WallKey = (char)(ConsoleColor.DarkGray + 97);
        public static char InvalidKey = (char)(ConsoleColor.Red + 97);

        public static char BedroomKey = (char)(ConsoleColor.Cyan + 97);
        public static char BathroomKey = (char)(ConsoleColor.DarkGreen + 97);
        public static char LivingroomKey = (char)(ConsoleColor.DarkBlue + 97);
        public static char KitchenKey = (char)(ConsoleColor.DarkYellow + 97);
        public static char GardenKey = (char)(ConsoleColor.Green + 97);
        public static char CorridorKey = (char)(ConsoleColor.Gray + 97);
        public static char ToiletsKey = (char)(ConsoleColor.DarkCyan + 97);
        public static char OfficeroomKey = (char)(ConsoleColor.DarkRed + 97);
        public static char BaseRoomKey = (char)(ConsoleColor.DarkMagenta + 97);

        public static char TestRoomKey = (char)(ConsoleColor.Yellow + 97);
        
        public static Vector2 BackgroundSize = new Vector2(32, 32);
        public static int RoomSelectionAmount = 3;
    }
}
