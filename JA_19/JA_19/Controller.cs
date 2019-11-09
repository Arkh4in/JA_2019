using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class Controller
    {
        //Prop & Constructors//
        public char Input { get; private set; }

        public Controller() { }

        //Methods//
        public void Move(Room selectedRoom)
        {
            char input = Console.ReadKey().KeyChar;
            bool b = true;

            while (b)
            { 
                switch (input)
                {
                    case 'z':
                        {
                            selectedRoom.moveUp();
                            b = false;
                            break;
                        }
                    case 's':
                        {
                            selectedRoom.moveDown();
                            b = false;
                            break;
                        }
                    case 'q':
                        {
                            selectedRoom.moveLeft();
                            b = false;
                            break;
                        }
                    case 'd':
                        {
                            selectedRoom.moveRight();
                            b = false;
                            break;
                        }
                    default :
                        {
                            Console.WriteLine("Vous devez utiliser Z, Q, S et D pour bouger la salle.");
                            break;
                        }
                }
            }
        }
    }
}
