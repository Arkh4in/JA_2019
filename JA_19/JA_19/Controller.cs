using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    class Controller
    {
        public char Input { get; private set; }

        public Controller() { }

        public void Move(Vector2 fromCoordinates)
        {
            char input = Console.ReadKey().KeyChar;
            bool b = true;

            while (b)
            { 
                switch (input)
                {
                    case 'z':
                        {
                            moveUp(fromCoordinates);
                            b = false;
                            break;
                        }
                    case 's':
                        {
                            moveDown(fromCoordinates);
                            b = false;
                            break;
                        }
                    case 'q':
                        {
                            moveLeft(fromCoordinates);
                            b = false;
                            break;
                        }
                    case 'd':
                        {
                            moveRight(fromCoordinates);
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

        public Vector2 moveUp(Vector2 fromCoordinates)
        {
            Vector2 newCoord = new Vector2(0, fromCoordinates.Y);
            newCoord.X = (fromCoordinates.X - 1);
            return newCoord;
        }

        public Vector2 moveDown(Vector2 coord)
        {
            Vector2 newCoord = new Vector2(0, coord.Y);
            newCoord.X = (coord.X + 1);
            return newCoord;
        }

        public Vector2 moveRight(Vector2 coord)
        {
            Vector2 newCoord = new Vector2(coord.X, 0);
            newCoord.Y = (coord.Y + 1);
            return newCoord;
        }

        public Vector2 moveLeft(Vector2 coord)
        {
            Vector2 newCoord = new Vector2(coord.X, 0);
            newCoord.Y = (coord.Y - 1);
            return newCoord;
        }

    }
}
