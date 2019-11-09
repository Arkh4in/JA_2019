﻿using System;
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
                    if (buffer != 'a')
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
                    if (room.Layout.Content[i, j] != 'a')
                    {
                        if (bg.Content[room.Pos.X + i, room.Pos.Y + j] != 'a')
                            return true;
                    }
                }
            }
            return false;
        }

        //Cryptic
        public static bool IsDoorValid(Layout bg, Room room)
        {
            var doors = room.Layout.DoorCoordinatesList;
            foreach (var v in doors)
            {
                int minX = Math.Max(0, v.X + -1 + room.Pos.X);
                int minY = Math.Max(0, v.Y + -1 + room.Pos.Y);

                int maxX = Math.Min(bg.Size.X - 1, v.X + 1 + room.Pos.X);
                int maxY = Math.Min(bg.Size.Y - 1, v.Y + 1 + room.Pos.Y);

                for (int i = minX; i <= maxX; i++)
                {
                    for (int j = minY; j <= maxY; j++)
                    {
                        if (bg.Content[i, j] == Settings.DoorKey)
                        {
                            return i == v.X + room.Pos.X || j == v.Y + room.Pos.Y;
                        }
                    }
                }
            }
            return false;
        }
    }
}
