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

        private void Init()
        {
            _currentRoom = null;
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
                    Init();
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
            MoveResult result = MoveResult.None;
            if (_currentRoom == null)
            {
                DisplayHelper.DisplayGameState(_background, _currentRoom);
                _currentRoom = SelectRoom(out result);
            }
            else
            {
                DisplayHelper.DisplayGameState(_background, _currentRoom);
                DisplayHelper.DisplayBottom(DisplayHelper.CommandType.Move);
                Controller.Move(_currentRoom, _background, out result);

                if(result == MoveResult.Placed)
                {
                    _currentRoom = null;
                }
            }
            if (result == MoveResult.GaveUp)
            {
                DisplayHelper.DisplayGameOver();
                return false;
            }
            return true;
        }

        //Methods//

        public Room SelectRoom(out MoveResult mr)
        {
            var roomSelection = RoomSelection(Settings.RoomSelectionAmount);
            DisplayHelper.DisplayBottom(DisplayHelper.CommandType.Select, roomSelection);
            return roomSelection[Controller.SelectRoomIndex(Settings.RoomSelectionAmount, out mr)];
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
