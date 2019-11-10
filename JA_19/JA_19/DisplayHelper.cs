using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public static class DisplayHelper
    {
        public static void DisplayGameState(Layout background, Room room)
        {
            Layout graphicLayout = GraphicMerge(background, room);
            DisplayLayout(graphicLayout);
        }

        private static void DisplayLayout(Layout layout)
        {
            Console.SetCursorPosition(0, 0);
            int currentColor = layout.Content[0, 0];
            Console.BackgroundColor = (ConsoleColor)(currentColor - 97);
            for (int i = 0; i < layout.Size.X; i++)
            {
                for (int j = 0; j < layout.Size.Y; j++)
                {
                    if (currentColor != layout.Content[i, j])
                    {
                        currentColor = layout.Content[i, j];
                        Console.BackgroundColor = (ConsoleColor)(currentColor - 97);
                    }
                    Console.Write("  ");
                }
                Console.Write("\n");
            }
            PostBoardDisplay();
        }

        public static void PostBoardDisplay()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                ");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static Layout GraphicMerge(Layout bg, Room room)
        {
            if(LayoutHelper.IsColliding(bg, room))
            {
                return LayoutHelper.MergeLayouts(bg, Layout.AsInvalid(room.Layout, Settings.WallKey), room.Pos, room.Layout.Size);
            }
            else if(!LayoutHelper.IsDoorValid(bg, room))
            {
                return LayoutHelper.MergeLayouts(bg, Layout.AsInvalid(room.Layout, Settings.DoorKey), room.Pos, room.Layout.Size);
            }
            return LayoutHelper.MergeLayouts(bg, room.Layout, room.Pos, room.Layout.Size);
        }

        public static void DisplayMoreSpace()
        {
            Console.SetCursorPosition(0, Settings.BackgroundSize.X / 2 - 5);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                ");
            Console.WriteLine("         __  __   ___   ___  ___   ___  ___   _    ___  ___     ");
            Console.WriteLine("        |  \\/  | / _ \\ | _ \\| __| / __|| _ \\ /_\\  / __|| __|    ");
            Console.WriteLine("        | |\\/| || (_) ||   /| _|  \\__ \\|  _// _ \\| (__ | _|     ");
            Console.WriteLine("        |_|  |_| \\___/ |_|_\\|___| |___/|_| /_/ \\_\\\\___||___|    ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                ");


            var time = DateTime.Now.AddSeconds(1);
            while(DateTime.Now < time) { }
        }

        public enum CommandType { Select, Move}

        public static void DisplayBottom(CommandType commandType)
        {
            Console.WriteLine("");

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("     BedRoom     ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

            DisplayCommand(commandType);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private static void DisplayCommand(CommandType commandType)
        {
            if(commandType == CommandType.Move)
            {
                Console.WriteLine("Z,Q,S,D  : Move current room");
                Console.WriteLine("E, A     : Rotate Room");
                Console.WriteLine("Space    : Drop current room");
                Console.WriteLine("N        : /!\\ NOMORESPACE /!\\");
            }
        }
    }
}
