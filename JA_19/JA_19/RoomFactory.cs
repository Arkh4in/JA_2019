using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class RoomFactory
    {
        private static Random _random;
        private static Random _Random
        {
            get
            {
                if (_random == null)
                {
                    _random = new Random(DateTime.Now.Millisecond);
                }
                return _random;
            }
        }

        public static RoomSettings BathroomSettings = RoomSettings.FromRoomTypeToRoomSettings[RoomType.Bathroom];
        public static RoomSettings BedroomSettings = RoomSettings.FromRoomTypeToRoomSettings[RoomType.Bedroom];
        public static RoomSettings LivingroomSettings = RoomSettings.FromRoomTypeToRoomSettings[RoomType.Livingroom];
        public static RoomSettings KitchenSettings = RoomSettings.FromRoomTypeToRoomSettings[RoomType.Kitchen];
        public static RoomSettings CorridorSettings = RoomSettings.FromRoomTypeToRoomSettings[RoomType.Corridor];
        public static RoomSettings GardenSettings = RoomSettings.FromRoomTypeToRoomSettings[RoomType.Garden];
        public static RoomSettings ToiletsSettings = RoomSettings.FromRoomTypeToRoomSettings[RoomType.Toilets];
        public static RoomSettings OfficeroomSettings = RoomSettings.FromRoomTypeToRoomSettings[RoomType.Officeroom];

        public static Vector2 RandomDoorCoordinates(RoomSettings roomSettings)
        {
            Vector2 vec1 = new Vector2(_Random.Next(1, roomSettings.SizeXBackground - 1), 0);
            Vector2 vec2 = new Vector2(_Random.Next(1, roomSettings.SizeXBackground - 1), roomSettings.SizeYBackground - 1);
            Vector2 vec3 = new Vector2(0, _Random.Next(1, roomSettings.SizeYBackground - 1));
            Vector2 vec4 = new Vector2(roomSettings.SizeXBackground - 1, _Random.Next(1, roomSettings.SizeYBackground - 1));

            List<Vector2> vectorList = new List<Vector2>();

            vectorList.Add(vec1);
            vectorList.Add(vec2);
            vectorList.Add(vec3);
            vectorList.Add(vec4);

            Vector2 randomVector = vectorList[_Random.Next(0, 4)];
            return randomVector;
        }

        public static Vector2 CreateRandomRoomSize(RoomSettings roomSettings)
        {
            int randX = _Random.Next(roomSettings.MinSizeX, roomSettings.MaxSizeX);
            int randY = _Random.Next(roomSettings.MinSizeY, roomSettings.MaxSizeY);

            Vector2 vector = new Vector2(randX, randY);
            return vector;

        }

        public static int RandomizeDoorsAmount(RoomSettings roomSettings)
        {
            return _Random.Next(roomSettings.MinDoorsAmount, roomSettings.MaxDoorsAmount + 1);
        }

        public static RoomType RandomizeType()
        {
            Array valuesTypesArray = RoomType.GetValues(typeof(RoomType));

            int index = _Random.Next(0, 8);

            return (RoomType)valuesTypesArray.GetValue(index);
        }

        public static Room CreateRandomRoom()//no coordinates redundance gestion : if 2 doors position match, one door less, who cares?
        {
            RoomType r = RandomizeType();
            switch (r)
            {
                case RoomType.Bathroom:
                    {
                        Room room = new Room(new Vector2(0, 0), CreateRandomRoomSize(BathroomSettings));
                        int doorsAmount = RandomizeDoorsAmount(BathroomSettings);

                        for (int i = 0; i < doorsAmount; i++)
                        {
                            Vector2 randomDoor = RandomDoorCoordinates(BathroomSettings);
                            room.AddDoor(randomDoor);
                            return room;
                        }
                        break;
                    }
                case RoomType.Bedroom:
                    {
                        Room room = new Room(new Vector2(0, 0), CreateRandomRoomSize(BedroomSettings));
                        int doorsAmount = RandomizeDoorsAmount(BedroomSettings);

                        for (int i = 0; i < doorsAmount; i++)
                        {
                            Vector2 randomDoor = RandomDoorCoordinates(BedroomSettings);
                            room.AddDoor(randomDoor);
                            return room;
                        }
                        break;
                    }
                case RoomType.Livingroom:
                    {
                        Room room = new Room(new Vector2(0, 0), CreateRandomRoomSize(LivingroomSettings));
                        int doorsAmount = RandomizeDoorsAmount(LivingroomSettings);

                        for (int i = 0; i < doorsAmount; i++)
                        {
                            Vector2 randomDoor = RandomDoorCoordinates(LivingroomSettings);
                            room.AddDoor(randomDoor);
                            return room;
                        }
                        break;
                    }
                case RoomType.Kitchen:
                    {
                        Room room = new Room(new Vector2(0, 0), CreateRandomRoomSize(KitchenSettings));
                        int doorsAmount = RandomizeDoorsAmount(KitchenSettings);

                        for (int i = 0; i < doorsAmount; i++)
                        {
                            Vector2 randomDoor = RandomDoorCoordinates(KitchenSettings);
                            room.AddDoor(randomDoor);
                            return room;
                        }
                        break;
                    }
                case RoomType.Garden:
                    {
                        Room room = new Room(new Vector2(0, 0), CreateRandomRoomSize(GardenSettings));
                        int doorsAmount = RandomizeDoorsAmount(GardenSettings);

                        for (int i = 0; i < doorsAmount; i++)
                        {
                            Vector2 randomDoor = RandomDoorCoordinates(GardenSettings);
                            room.AddDoor(randomDoor);
                            return room;
                        }
                        break;
                    }
                case RoomType.Corridor:
                    {
                        Room room = new Room(new Vector2(0, 0), CreateRandomRoomSize(CorridorSettings));
                        int doorsAmount = RandomizeDoorsAmount(CorridorSettings);

                        for (int i = 0; i < doorsAmount; i++)
                        {
                            Vector2 randomDoor = RandomDoorCoordinates(CorridorSettings);
                            room.AddDoor(randomDoor);
                            return room;
                        }
                        break;
                    }
                case RoomType.Toilets:
                    {
                        Room room = new Room(new Vector2(0, 0), CreateRandomRoomSize(ToiletsSettings));
                        int doorsAmount = RandomizeDoorsAmount(ToiletsSettings);

                        for (int i = 0; i < doorsAmount; i++)
                        {
                            Vector2 randomDoor = RandomDoorCoordinates(ToiletsSettings);
                            room.AddDoor(randomDoor);
                            return room;
                        }
                        break;
                    }
                case RoomType.Officeroom:
                    {
                        Room room = new Room(new Vector2(0, 0), CreateRandomRoomSize(OfficeroomSettings));
                        int doorsAmount = RandomizeDoorsAmount(OfficeroomSettings);

                        for (int i = 0; i < doorsAmount; i++)
                        {
                            Vector2 randomDoor = RandomDoorCoordinates(OfficeroomSettings);
                            room.AddDoor(randomDoor);
                            return room;
                        }
                        break;
                    }
                default:
                    {
                        throw (new NotImplementedException());
                    }
            }
            throw (new NotImplementedException());
        }
    }
}
