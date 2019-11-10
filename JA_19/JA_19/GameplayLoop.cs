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
            _background = new Layout(Settings.BackgroundSize);
            Room initRoom = RoomFactory.CreateInitRoom();

            _background.Content = LayoutHelper.MergeLayouts(
                _background, 
                initRoom.Layout, 
                new Vector2(Settings.BackgroundSize.X / 2, Settings.BackgroundSize.Y / 2 - 1), 
                initRoom.Layout.Size).Content;
        }

        public void MainLoop()
        {
            int i = 0;
            while (i != 2)
            {
                DisplayHelper.DisplayMainMenu();
                i = Controller.SelectMainMenuIndex();
                if(i == 0)
                {
                    while (MainExecution()) { }
                }
                if(i == 1)
                {
                    DisplayHelper.DisplayCredit();
                }
            }
        }

        private bool MainExecution()
        {
            if (_currentRoom == null)
            {
                DisplayHelper.DisplayGameState(_background, _currentRoom);
                _currentRoom = SelectRoom();
            }
            else
            {
                DisplayHelper.DisplayGameState(_background, _currentRoom);
                DisplayHelper.DisplayBottom(DisplayHelper.CommandType.Move);
                MoveResult result;
                Controller.Move(_currentRoom, _background, out result);

                if(result == MoveResult.Placed)
                {
                    _currentRoom = null;
                }
                else if( result == MoveResult.GaveUp)
                {
                    return false;
                }
            }
            return true;
        }

        //Methods//

        public Room SelectRoom()
        {
            var roomSelection = RoomSelection(Settings.RoomSelectionAmount);
            DisplayHelper.DisplayBottom(DisplayHelper.CommandType.Select, roomSelection);
            return roomSelection[Controller.SelectRoomIndex(Settings.RoomSelectionAmount)];
        }

        private List<Room> RoomSelection(int roomAmount)
        {
            var roomList = new List<Room>(roomAmount);
            for (int i = 0; i < roomAmount; i++)
            {
                roomList.Add(RoomFactory.CreateRandomRoom());
            }
            return roomList;
        }
    }
}
