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
            Console.SetCursorPosition(0, 8);
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
    }
}
