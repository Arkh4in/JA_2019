using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public static class RoomFactory
    {
        public static Vector2 RandomDoorCoordinates(int sizeX, int sizeY)
        {
            Random random = new Random();

            Vector2 vec1 = new Vector2(random.Next(1, sizeX - 2), 0);
            Vector2 vec2 = new Vector2(random.Next(1, sizeX - 2), sizeY - 1);
            Vector2 vec3 = new Vector2(0, random.Next(1, sizeY - 2));
            Vector2 vec4 = new Vector2(sizeX - 1, random.Next(1, sizeY - 2));

            List<Vector2> vectorList = new List<Vector2>();

            vectorList.Add(vec1);
            vectorList.Add(vec2);
            vectorList.Add(vec3);
            vectorList.Add(vec4); 

            Vector2 randomVector = vectorList[random.Next(0, 3)];
            return randomVector;
        }

        public static Vector2 CreateRandomRoomSize()
        {
            Random r = new Random();
            int randX = r.Next(Settings.minSizeX, Settings.maxSizeX);
            int randY = r.Next(Settings.minSizeY, Settings.maxSizeY);

            Vector2 vector = new Vector2(randX, randY);
            return vector;
            
        }

        public static int RandomizeDoorsAmount()
        {
            Random r = new Random();
            return r.Next(Settings.minDoorsAmount, Settings.maxDoorsAmount);
        }

        public static Room CreateRandomRoom()
        {
            Random r = new Random();

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
