using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public static class RoomFactory
    {
        private static Random _random;
        private static Random _Random
        {
            get
            {
                if(_random == null)
                {
                    _random = new Random(DateTime.Now.Millisecond);
                }
                return _random;
            }
        }
        public static Vector2 RandomDoorCoordinates(int sizeX, int sizeY)
        {
            Vector2 vec1 = new Vector2(_Random.Next(1, sizeX - 1), 0);
            Vector2 vec2 = new Vector2(_Random.Next(1, sizeX - 1), sizeY - 1);
            Vector2 vec3 = new Vector2(0, _Random.Next(1, sizeY - 1));
            Vector2 vec4 = new Vector2(sizeX - 1, _Random.Next(1, sizeY - 1));

            List<Vector2> vectorList = new List<Vector2>();

            vectorList.Add(vec1);
            vectorList.Add(vec2);
            vectorList.Add(vec3);
            vectorList.Add(vec4); 

            Vector2 randomVector = vectorList[_Random.Next(0, 3)];
            return randomVector;
        }

        public static Vector2 CreateRandomRoomSize()
        {
            int randX = _Random.Next(Settings.minSizeX, Settings.maxSizeX);
            int randY = _Random.Next(Settings.minSizeY, Settings.maxSizeY);

            Vector2 vector = new Vector2(randX, randY);
            return vector;
            
        }

        public static int RandomizeDoorsAmount()
        {
            return _Random.Next(Settings.minDoorsAmount, Settings.maxDoorsAmount + 1);
        }

        public static Room CreateRandomRoom()
        {
            Vector2 randSize = CreateRandomRoomSize();
            Room room = new Room(new Vector2(0, 0), randSize);

            int doorsAmount = RandomizeDoorsAmount();
            List<Vector2> doorsCoordinatesList = new List<Vector2>();

            for (int i = 0; i < doorsAmount; i++)
            {
                Vector2 randomDoor = RandomDoorCoordinates(randSize.X, randSize.Y);
                doorsCoordinatesList.Add(randomDoor);
                //TODO check if already existing coordinates
                room.AddDoor(randomDoor);
            }

            return room;
        }
    }
}
