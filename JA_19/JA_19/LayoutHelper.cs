using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public static class LayoutHelper
    {
        public static bool IsValid(Layout bg, Room room)
        {
            return !IsColliding(bg, room) && IsDoorValid(bg, room);
        }

        public static void MergeRoom(Layout bg, Room r)
        {
            bg.Content = MergeLayouts(bg, r.Layout, r.Pos, r.Layout.Size).Content;
        }

        public static Layout MergeLayouts(Layout bg, Layout room, Vector2 pos, Vector2 size)
        {
            Layout l = new Layout(bg);
            char buffer;
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    buffer = room.Content[i, j];
                    if (buffer != Settings.EmptyKey)
                    {
                        l.Content[pos.X + i, pos.Y + j] = buffer;
                    }
                }
            }
            return l;
        }

        public static bool IsColliding(Layout bg, Room room)
        {
            for (int i = 0; i < room.Layout.Size.X; i++)
            {
                for (int j = 0; j < room.Layout.Size.Y; j++)
                {
                    var content = room.Layout.Content[i, j];
                    if (content != Settings.EmptyKey &&
                        content != Settings.DoorKey &&
                        content != Settings.WallKey)
                    {
                        if (bg.Content[room.Pos.X + i, room.Pos.Y + j] != Settings.EmptyKey)
                            return true;
                    }
                }
            }
            return false;
        }

        public static bool IsDoorValid(Layout bg, Room room)
        {
            var doorsPos = room.Layout.DoorCoordinatesList;
            foreach (var p in doorsPos)
            {
                if (bg.Content[p.X + room.Pos.X, p.Y + room.Pos.Y] == Settings.DoorKey)
                    return true;
            }
            return false;
        }
    }
}
