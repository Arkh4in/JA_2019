using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public enum MoveResult { None, Placed, GaveUp}

    public static class Controller
    {

        //Methods//
        public static void Move(Room selectedRoom, Layout background, out MoveResult result)
        {
            result = MoveResult.None;
            bool b = true;
            while (b)
            { 
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case 'z':
                        {
                            if(selectedRoom.Pos.X > 0)
                            {
                                selectedRoom.MoveUp();
                            }
                            b = false;
                            break;
                        }
                    case 's':
                        {
                            if (selectedRoom.Pos.X + selectedRoom.Layout.Size.X < background.Size.X)
                            {
                                selectedRoom.MoveDown();
                            }
                            b = false;
                            break;
                        }
                    case 'q':
                        {
                            if (selectedRoom.Pos.Y > 0)
                            {
                                selectedRoom.MoveLeft();
                            }
                            b = false;
                            break;
                        }
                    case 'd':
                        {
                            if (selectedRoom.Pos.Y + selectedRoom.Layout.Size.Y < background.Size.Y)
                            {
                                selectedRoom.MoveRight();
                            }
                            b = false;
                            break;
                        }
                    case 'a':
                        {
                            if (selectedRoom.Pos.Y + selectedRoom.Layout.Size.X < background.Size.Y &&
                                selectedRoom.Pos.X + selectedRoom.Layout.Size.Y < background.Size.X)
                            {
                                selectedRoom.RotateACW();
                            }
                            b = false;
                            break;
                        }
                    case 'e':
                        {
                            if (selectedRoom.Pos.Y + selectedRoom.Layout.Size.X < background.Size.Y &&
                                selectedRoom.Pos.X + selectedRoom.Layout.Size.Y < background.Size.X)
                            {
                                selectedRoom.RotateCW();
                            }
                            b = false;
                            break;
                        }
                    case ' ':
                        {
                            if (LayoutHelper.IsValid(background, selectedRoom))
                            {
                                LayoutHelper.MergeRoom(background, selectedRoom);
                                DisplayHelper.DisplayMoreSpace();
                                result = MoveResult.Placed;
                                return;
                            }
                            break;
                        }
                    case 'n':
                        {
                            result = MoveResult.GaveUp;
                            return;
                        }
                    default :
                        {
                            continue;
                        }
                }
            }
            return;
        }

        public static int SelectRoomIndex(int roomAmount, out MoveResult result)
        {
            bool b = true;
            result = MoveResult.None;
            while (b)
            {
                var content = Console.ReadKey();
                var c = content.KeyChar;
                if (c == '&')
                    c = '1';

                if (c == 'é')
                    c = '2';

                if (c == '"')
                    c = '3';

                if(c == 'n')
                {
                    result = MoveResult.GaveUp;
                    return 0;
                }

                int i = 0;
                if(Int32.TryParse(c.ToString(), out i))
                {
                    i--;
                    if (0 <= i && i < roomAmount)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        return i;
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
            }
            throw new InvalidOperationException();
        }

        public static int SelectMainMenuIndex()
        {
            bool b = true;
            while (b)
            {
                var content = Console.ReadKey();
                var c = content.KeyChar;
                if (c == '&')
                    c = '1';

                if (c == 'é')
                    c = '2';

                if (c == '"')
                    c = '3';

                int i = 0;
                if (Int32.TryParse(c.ToString(), out i))
                {
                    i--;
                    if (0 <= i && i < 3)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        return i;
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
            }
            throw new InvalidOperationException();
        }
    }
}
