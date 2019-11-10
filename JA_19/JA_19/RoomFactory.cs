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
                if (_random == null)
                {
                    _random = new Random(DateTime.Now.Millisecond);
                }
                return _random;
            }
        }

        private static Dictionary<RoomType, RoomSettings> _fromRoomTypeToRoomSettings;
        public static Dictionary<RoomType, RoomSettings> FromRoomTypeToRoomSettings
        {
            get
            {
                if(_fromRoomTypeToRoomSettings == null)
                {
                    _fromRoomTypeToRoomSettings = CreateRoomSettingsDictionary();
                }
                return _fromRoomTypeToRoomSettings;
            }
        }

        public static Dictionary<RoomType, RoomSettings> CreateRoomSettingsDictionary()
        {
            return new Dictionary<RoomType, RoomSettings>()
           {
                {RoomType.Bedroom,    new RoomSettings(4, 4, 5, 5, 1, 2, Settings.BedroomKey)},
                {RoomType.Bathroom,   new RoomSettings(4, 4, 5, 5, 1, 2, Settings.BathroomKey)},
                {RoomType.Livingroom, new RoomSettings(6, 6, 9, 10, 1, 3, Settings.LivingroomKey)},
                {RoomType.Kitchen,    new RoomSettings(5, 5, 6, 6, 1, 2, Settings.KitchenKey)},
                {RoomType.Garden,     new RoomSettings(7, 7, 10, 10, 2, 3, Settings.GardenKey)},
                {RoomType.Corridor,   new RoomSettings(3, 6, 4, 10, 2, 4, Settings.CorridorKey)},
                {RoomType.Toilets,    new RoomSettings(3, 3, 4, 4, 1, 1, Settings.ToiletsKey)},
                {RoomType.Officeroom, new RoomSettings(4, 4, 5, 5, 1, 2, Settings.OfficeroomKey)},
           };
        }

        public static Vector2 RandomDoorCoordinates(RoomSettings roomSettings, Vector2 roomSize)
        {
            Vector2 vec1 = new Vector2(_Random.Next(1, roomSize.X - 1), 0);
            Vector2 vec2 = new Vector2(_Random.Next(1, roomSize.X - 1), roomSize.Y - 1);
            Vector2 vec3 = new Vector2(0, _Random.Next(1, roomSize.Y - 1));
            Vector2 vec4 = new Vector2(roomSize.X - 1, _Random.Next(1, roomSize.Y - 1));

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
            var settings = FromRoomTypeToRoomSettings[r];
            var roomSize = CreateRandomRoomSize(settings);
            Room room = new Room(new Vector2(0, 0), roomSize, settings.TypeKey);
            int doorsAmount = RandomizeDoorsAmount(settings);

            for (int i = 0; i < doorsAmount; i++)
            {
                Vector2 randomDoor = RandomDoorCoordinates(settings, roomSize);
                room.AddDoor(randomDoor);
            }
            return room;
        }

        public static Room CreateInitRoom()
        {
            Room room = new Room(
                new Vector2(0, 0),
                new Vector2(8, 3),
                Settings.BaseRoomKey);
            room.AddDoor(new Vector2(0, 1));
            room.AddDoor(new Vector2(7, 1));
            room.AddDoor(new Vector2(3, 0));
            room.AddDoor(new Vector2(3, 2));
            return room;
        }
    }
}
