using System;
using System.Collections.Generic;
using System.IO;
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
            List<RoomType> bonusRoomList = new List<RoomType>();
            
            while (bonusRoomList.Count() < 4)
            {
                RoomType r = RoomFactory.RandomizeType();
                if(!bonusRoomList.Contains(r))
                {
                    bonusRoomList.Add(r);
                }
            }
            return bonusRoomList;
        }

        public int GetScore()
        {
            float f = (FromRoomtypeToBoolean.Values.Where(x => x).Count() / 10.0f);
            return (int)(CurrentScore * (1 + f));
        }

        public static int GetBestScore()
        {
            string path = $"{Directory.GetCurrentDirectory()}\\file.txt";
            var str = File.ReadLines(path).FirstOrDefault();
            int i = 0;
            Int32.TryParse(str, out i);
            return i;
        }

        private void SetBestScore(int i)
        {
            string path = $"{Directory.GetCurrentDirectory()}\\file.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            File.WriteAllText(path, i.ToString());
        }

        public void UpdateScore(Room room)
        {
            IncreaseScore(room.Area);
            SwitchRoomTypeBoolWhenPut(room.TypeOfRoom);
            int bestScore = GetBestScore();
            if(CurrentScore > bestScore)
            {
                SetBestScore(CurrentScore);
            }
        }
    }
}
