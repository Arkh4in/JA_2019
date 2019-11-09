using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class GameplayLoop
    {
        private Room _currentRoom;
        private Layout _background;

        public GameplayLoop()
        {
            _background = Layout.EmptyLayout(Settings.BackgroundSize);

            _background.Content[0, 0] = Settings.WallKey;
            _background.Content[2, 9] = Settings.DoorKey;
        }

        public void MainLoop()
        {
            while(true)
            {
                MainExecution();
            }
        }

        private void MainExecution()
        {
            if (_currentRoom == null)
            {
                _currentRoom = SelectRoom();
            }
            else
            {
                DisplayHelper.DisplayGameState(_background, _currentRoom);
                Controller.Move(_currentRoom, _background);
            }
        }

        //Methods//

        public Room SelectRoom()
        {
            return RoomFactory.CreateRandomRoom();
            //var roomSelection = RoomSelection(Settings.RoomSelectionAmount);
            //return roomSelection[Controller.SelectRoomIndex(Settings.RoomSelectionAmount)];
        }

        private List<Room> RoomSelection(int roomAmount)
        {
            //TODO : call factory
            return new List<Room>(roomAmount);
        }
    }
}
