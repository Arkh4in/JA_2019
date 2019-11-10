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
            while (MainExecution()) { }
        }

        private bool MainExecution()
        {
            if (_currentRoom == null)
            {
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
