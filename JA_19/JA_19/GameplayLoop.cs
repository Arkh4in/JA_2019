using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class GameplayLoop
    {
        public Room CurrentlySelectedRoom { get; set; }
        public List<Room> RoomSelection { get; set; }

        //Prop & Constructors//
        public GameplayLoop(Room room, List<Room> roomSelection)
        {
            CurrentlySelectedRoom = room;
            RoomSelection = roomSelection;
        }

        //Methods//

        public void SelectRoom()
        {
            if (CurrentlySelectedRoom == null)
            { 
                Console.WriteLine("Quelle pièce souhaitez-vous sélectionner ?");

                bool b = true;
                int answer;

                while (b)
                {
                    answer = Convert.ToInt32(Console.ReadLine());

                    switch (answer)
                    {
                        case 1:
                            {
                                CurrentlySelectedRoom = RoomSelection[0];
                                b = false;
                                break;
                            }
                        case 2:
                            {
                                CurrentlySelectedRoom = RoomSelection[1];
                                b = false;
                                break;
                            }
                        case 3:
                            {
                                CurrentlySelectedRoom = RoomSelection[2];
                                b = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Veuillez choisir une pièce à l'aide de la touche 1, 2 ou 3.");
                                continue;
                            }
                    }
                }
            }
        }

        public void UnselectCurrentRoom()
        {
            CurrentlySelectedRoom = null;
        }

        public void SetGameplayLoop(List<Room> roomSelection)
        {
            Controller controller = new Controller();
            SelectRoom();
            controller.Move(CurrentlySelectedRoom);

            bool isPositionValid = true;

            //TODO : create IsPositionValid()

            if (isPositionValid)
            {
                UnselectCurrentRoom();
            }

            //TODO : Change background to add the new room
        }

    }
}
