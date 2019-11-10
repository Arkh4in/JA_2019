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
            Layout graphicLayout = background;
            if (room != null)
            {
                graphicLayout = GraphicMerge(background, room);
            }
            DisplayLayout(graphicLayout, new Vector2(0,0));
        }

        private static void DisplayLayout(Layout layout, Vector2 v)
        {
            Console.SetCursorPosition(v.X, v.Y);
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
        }

        private static Layout GraphicMerge(Layout bg, Room room)
        {
            if(LayoutHelper.IsColliding(bg, room))
            {
                return LayoutHelper.MergeLayouts(bg, Layout.AsInvalid(room.Layout, InvalidType.Pos), room.Pos, room.Layout.Size);
            }
            else if(!LayoutHelper.IsDoorValid(bg, room))
            {
                return LayoutHelper.MergeLayouts(bg, Layout.AsInvalid(room.Layout, InvalidType.Door), room.Pos, room.Layout.Size);
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

        public static void DisplayBottom(CommandType commandType, List<Room> roomList = null)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                           ROOMS                                ");
            Console.BackgroundColor = ConsoleColor.Black;

            DisplayLegend(commandType, roomList);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                            ");

            DisplayCommand(commandType);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

        }

        private static void DisplayLegend(CommandType commandType, List<Room> roomList)
        {
            if(commandType == CommandType.Move)
            {
                Console.WriteLine("                                                                ");
                Console.ForegroundColor = ConsoleColor.Black;

                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine("                           Bedroom                              ");

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("                           Bathroom                             ");

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("                           Livingroom                           ");

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("                           Kitchen                              ");

                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("                           Garden                               ");

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.WriteLine("                           Corridor                             ");

                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("                           Toilets                              ");

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                           Officeroom                           ");

                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("                           BaseRoom                             ");
            }
            else if(commandType == CommandType.Select)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("  1:                    2:                   3:                 ");
                Console.WriteLine("                                                            ");
                Layout l = new Layout(new Vector2(10, 32));
                for(int i = 0; i < roomList.Count; i++)
                {
                    l = LayoutHelper.MergeLayouts(l, roomList[i].Layout, new Vector2(0, i * 11), roomList[i].Layout.Size);
                }
                DisplayLayout(l, new Vector2(0, Console.CursorTop));
            }
        }

        private static void DisplayCommand(CommandType commandType)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("                           COMMANDS                             ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                            ");

            if (commandType == CommandType.Move)
            {
                Console.WriteLine("Z,Q,S,D  : Move current room                                ");
                Console.WriteLine("E, A     : Rotate Room                                      ");
                Console.WriteLine("Space    : Drop current room                                ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("N        : NO MORE SPACE                                    ");

            }
            else if( commandType == CommandType.Select)
            {
                Console.WriteLine($"Select room using number from 1 to {Settings.RoomSelectionAmount}");
                Console.WriteLine("                                                            ");
            }
        }

        public static void DisplayMainMenu()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;          
            Console.WriteLine("                                                                ");
            Console.WriteLine("  ___  ___   _    ___  ___  ___  _   _  _     _                 ");
            Console.WriteLine(" / __|| _ \\ /_\\  / __|| __|| __|| | | || |   | |                ");
            Console.WriteLine(" \\__ \\|  _// _ \\| (__ | _| | _| | |_| || |__ | |__  _  _  _     ");
            Console.WriteLine(" |___/|_| /_/ \\_\\\\___||___||_|   \\___/ |____||____|(_)(_)(_)    ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                      ___ ___        ");
            Console.WriteLine("                                                     | __|| _ \\ ");
            Console.WriteLine("                                             _  _  _ | _| |   / ");
            Console.WriteLine("                                            (_)(_)(_)|___||_|_\\ ");   

            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("     _ __    _  _                 ___                           ");
            Console.WriteLine("    / |\\ \\  | \\| | ___ __ __ __  / __| __ _  _ __   ___         ");
            Console.WriteLine("    | | | | | .` |/ -_)\\ V  V / | (_ |/ _` || '  \\ / -_)        ");
            Console.WriteLine("    |_| | | |_|\\_|\\___| \\_/\\_/   \\___|\\__,_||_|_|_|\\___|        ");
            Console.WriteLine("       /_/                                                      ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("     ___ __     ___               _  _  _                       ");
            Console.WriteLine("    |_  )\\ \\   / __| _ _  ___  __| |(_)| |_  ___                ");
            Console.WriteLine("     / /  | | | (__ | '_|/ -_)/ _` || ||  _|(_-<                ");
            Console.WriteLine("    /___| | |  \\___||_|  \\___|\\__,_||_| \\__|/__/                ");
            Console.WriteLine("         /_/                                                    ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("     ______    ___       _  _                                   ");
            Console.WriteLine("    |__ /\\ \\  | __|__ __(_)| |_                                 ");
            Console.WriteLine("     |_ \\ | | | _| \\ \\ /| ||  _|                                ");
            Console.WriteLine("    |___/ | | |___|/_\\_\\|_| \\__|                                ");
            Console.WriteLine("         /_/                                                    ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");

        }

        public static void DisplayCredit()
        {
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                     SPACE                                      ");
            Console.WriteLine("                                                      SPACE     ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("            SPACE                                               ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                   Prog : Melissa Sadouki       ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                              SPACE                             ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("               SPACE                                            ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                    SPACE                                       ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                        MORE          SPACE     ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                    SPACE                                       ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("     Prog : Thomas Falcone                                      ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                 SPACE                          ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                       SPACE                    ");
            Console.WriteLine("                               MORE SPACE                       ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("         SPACE                                                  ");
            Console.WriteLine("                                                        SPACE   ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("        SPACE                                                   ");
            Console.WriteLine("                                 SPACE                          ");
            Console.WriteLine("                                                                ");
            Console.ReadKey();
        }
    }
}
