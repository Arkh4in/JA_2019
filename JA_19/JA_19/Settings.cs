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
        public static Vector2 BackgroundSize = new Vector2(32, 32);
        public static int minSizeX = 3;
        public static int minSizeY = 3;
        public static int maxSizeX = 8;
        public static int maxSizeY = 12;
        public static int minDoorsAmount = 1;
        public static int maxDoorsAmount = 3;

    }
}
