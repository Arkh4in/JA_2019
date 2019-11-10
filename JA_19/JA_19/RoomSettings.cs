using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public enum RoomType { Bathroom, Bedroom, Livingroom, Kitchen, Garden, Corridor, Toilets, Officeroom }

    public class RoomSettings
    {
        //create one and only RoomSettings at the gameInitialization?                 

        public int MinSizeX;
        public int MinSizeY;
        public int MaxSizeX;
        public int MaxSizeY;
        public int MinDoorsAmount;
        public int MaxDoorsAmount;
        public int SizeXBackground = 32;
        public int SizeYBackground = 32;



        public static Dictionary<RoomType, RoomSettings> FromRoomTypeToRoomSettings { get; private set; }

        public RoomSettings(RoomType r)
        {
            Init(r);
        }

        public RoomSettings(int minSizeX, int minSizeY, int maxSizeX, int maxSizeY, int minDoorsAmount, int maxDoorsAmount)
        {
            MinSizeX = minSizeX;
            MinSizeY = minSizeY;
            MaxSizeX = maxSizeX;
            MaxSizeY = maxSizeY;
            MinDoorsAmount = minDoorsAmount;
            MaxDoorsAmount = maxDoorsAmount;
        }

        public void Init(RoomType r)
        {

            Dictionary<RoomType, RoomSettings> fromRoomTypeToRoomSettings = new Dictionary<RoomType, RoomSettings>();

            switch (r)
            {
                case RoomType.Bathroom:
                    {
                        var BathroomSettings = new RoomSettings(2, 2, 3, 3, 1, 2);
                        FromRoomTypeToRoomSettings[RoomType.Bathroom] = BathroomSettings;
                        break;
                    }
                case RoomType.Bedroom:
                    {
                        var BedroomSettings = new RoomSettings(2, 2, 3, 3, 1, 2);
                        FromRoomTypeToRoomSettings[RoomType.Bedroom] = BedroomSettings;
                        break;
                    }
                case RoomType.Livingroom:
                    {
                        var LivingroomSettings = new RoomSettings(4, 4, 7, 8, 1, 3);
                        FromRoomTypeToRoomSettings[RoomType.Livingroom] = LivingroomSettings;
                        break;
                    }
                case RoomType.Kitchen:
                    {
                        var KitchenSettings = new RoomSettings(3, 3, 4, 4, 1, 2);
                        FromRoomTypeToRoomSettings[RoomType.Kitchen] = KitchenSettings;
                        break;
                    }
                case RoomType.Garden:
                    {
                        var GardenSettings = new RoomSettings(5, 5, 8, 8, 2, 3);
                        FromRoomTypeToRoomSettings[RoomType.Garden] = GardenSettings;
                        break;
                    }
                case RoomType.Corridor:
                    {
                        var CorridorSettings = new RoomSettings(1, 4, 2, 8, 2, 4);
                        FromRoomTypeToRoomSettings[RoomType.Corridor] = CorridorSettings;
                        break;
                    }
                case RoomType.Toilets:
                    {
                        var ToiletsSettings = new RoomSettings(1, 1, 2, 2, 1, 1);
                        FromRoomTypeToRoomSettings[RoomType.Toilets] = ToiletsSettings;
                        break;
                    }
                case RoomType.Officeroom:
                    {
                        var OfficeroomSettings = new RoomSettings(2, 2, 3, 3, 1, 2);
                        FromRoomTypeToRoomSettings[RoomType.Officeroom] = OfficeroomSettings;
                        break;
                    }
                default:
                    throw (new NotImplementedException());
            }
        }
    }
}

