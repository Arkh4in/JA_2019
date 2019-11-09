using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public static class Controller
    {
        //Methods//
        public static bool Move(Room selectedRoom, Layout background)
        {
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
                                selectedRoom.moveUp();
                            }
                            b = false;
                            break;
                        }
                    case 's':
                        {
                            if (selectedRoom.Pos.X + selectedRoom.Layout.Size.X < background.Size.X)
                            {
                                selectedRoom.moveDown();
                            }
                            b = false;
                            break;
                        }
                    case 'q':
                        {
                            if (selectedRoom.Pos.Y > 0)
                            {
                                selectedRoom.moveLeft();
                            }
                            b = false;
                            break;
                        }
                    case 'd':
                        {
                            if (selectedRoom.Pos.Y + selectedRoom.Layout.Size.Y < background.Size.Y)
                            {
                                selectedRoom.moveRight();
                            }
                            b = false;
                            break;
                        }
                    case ' ':
                        {
                            if (DisplayHelper.IsValid(background, selectedRoom))
                            {
                                DisplayHelper.MergeRoom(background, selectedRoom);
                                return true;
                            }
                            break;
                        }
                    default :
                        {
                            Console.WriteLine("Vous devez utiliser Z, Q, S et D pour bouger la salle.");
                            break;
                        }
                }
            }
            return false;
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
