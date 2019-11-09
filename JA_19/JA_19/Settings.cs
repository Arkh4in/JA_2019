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
        public static Vector2 BackgroundSize = new Vector2(24, 48);
        public static int RoomSelectionAmount = 3;
    }
}
