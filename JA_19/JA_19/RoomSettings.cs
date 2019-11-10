using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public enum RoomType { Bathroom, Bedroom, Livingroom, Kitchen, Garden, Corridor, Toilets, Officeroom }

    class RoomSettings
    {
        public static int MinSizeX;
        public static int MinSizeY;
        public static int MaxSizeX ;
        public static int MaxSizeY;
        public static int MinDoorsAmount;
        public static int MaxDoorsAmount;
        public static Dictionary<RoomType, RoomSettings> FromRoomTypeToRoomSettings { get; private set; }

        public RoomSettings(int minSizeX, int minSizeY, int maxSizeX, int maxSizeY, int minDoorsAmount, int maxDoorsAmount)
        {
            MinSizeX = minSizeX;
            MinSizeY = minSizeY;
            MaxSizeX = maxSizeX;
            MaxSizeY = maxSizeY;
            MinDoorsAmount = minDoorsAmount;
            MaxDoorsAmount = maxDoorsAmount;
        }
        public void Init()
        { 
            RoomSettings BedroomSettings = new RoomSettings(2, 2, 3, 3, 1, 2);
            RoomSettings BathroomSettings = new RoomSettings(2, 2, 3, 3, 1, 2);
            RoomSettings LivingroomSettings = new RoomSettings(4, 4, 7, 8, 1, 3);
            RoomSettings KitchenSettings = new RoomSettings(3, 3, 4, 4, 1, 2);
            RoomSettings GardenSettings = new RoomSettings(5, 5, 8, 8, 2, 3);
            RoomSettings CorridorSettings = new RoomSettings(1, 4, 2, 8, 2, 4);
            RoomSettings ToiletsSettings = new RoomSettings(1, 1, 2, 2, 1, 1);
            RoomSettings OfficeroomSettings = new RoomSettings(2, 2, 3, 3, 1, 2);

            Dictionary<RoomType, RoomSettings> fromRoomTypeToRoomSettings = new Dictionary<RoomType, RoomSettings>()
            {
                {RoomType.Bathroom, BathroomSettings},
                {RoomType.Bedroom, BedroomSettings},
                {RoomType.Livingroom, LivingroomSettings},
                {RoomType.Kitchen, KitchenSettings},
                {RoomType.Garden, GardenSettings},
                {RoomType.Corridor, CorridorSettings},
                {RoomType.Toilets, ToiletsSettings},
                {RoomType.Officeroom, OfficeroomSettings},
            };

            FromRoomTypeToRoomSettings = fromRoomTypeToRoomSettings;
        }
    }
}

