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
                            Console.WriteLine("Vous devez utiliser Z, Q, S et D pour bouger la salle.");
                            break;
                        }
                }
            }
            return;
        }

        public static int SelectRoomIndex(int roomAmount)
        {
            Console.WriteLine("Quelle pièce souhaitez-vous sélectionner ?");

            bool b = true;
            int answer;

            while (b)
            {
                answer = Convert.ToInt32(Console.ReadLine());
                if (0 <= answer && answer < roomAmount)
                {
                    return answer;
                }
            }
            throw new InvalidOperationException();
        }
    }
}
