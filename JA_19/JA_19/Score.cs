using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class Score
    {
        public static int CurrentScore { get; private set; }

        public static List<RoomType> BonusRoomToPut { get; private set; }

        public static Dictionary<RoomType, bool> FromRoomtypeToBoolean { get; private set; }


        public Score()
        {
            CurrentScore = 0;
            BonusRoomToPut = CreateRandomBonusRoomList();

            FromRoomtypeToBoolean = new Dictionary<RoomType, bool>()
           {
               {RoomType.Bedroom, false},
               {RoomType.Bathroom, false},
               {RoomType.Livingroom, false},
               {RoomType.Kitchen, false},
               {RoomType.Garden, false},
               {RoomType.Corridor, false},
               {RoomType.Toilets, false},
               {RoomType.Officeroom, false}
           };
        }

        public void IncreaseScore(int Score)
        {
            CurrentScore = CurrentScore + Score;
        }

        public bool IsEveryRoomTypePut()
        {
            int count = 0;
            foreach (RoomType roomType in FromRoomtypeToBoolean.Keys)
            {
                if (FromRoomtypeToBoolean[roomType] == true)
                {
                    count++;
                }
            }
            return (count == 8);
        }

        public bool IsBonusFullfiled()
        {
            int count = 0;
            foreach (RoomType roomsToPut in BonusRoomToPut)
            {
                foreach (RoomType roomTypes in FromRoomtypeToBoolean.Keys)
                {
                    if (roomsToPut == roomTypes && FromRoomtypeToBoolean[roomTypes] == true)
                    {
                        count++;
                    }
                }
            }
            return (count == 4);
        }

        public void SwitchRoomTypeBoolWhenPut(RoomType r)
        {
            FromRoomtypeToBoolean[r] = true;
        }



        public List<RoomType> CreateRandomBonusRoomList()
        {
            List<RoomType> bonusRoom = new List<RoomType>();

            while (bonusRoom.Count() < 4)
            {
                RoomType r = RoomFactory.RandomizeType();
                foreach (RoomType roomType in bonusRoom)
                {
                    if (r == roomType)
                    {
                        continue;
                    }
                    else
                    {
                        bonusRoom.Add(r);
                        continue;
                    }
                }
            }
            return bonusRoom;
        }
    }
}
