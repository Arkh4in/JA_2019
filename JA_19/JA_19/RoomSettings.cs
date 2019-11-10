using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public enum RoomType { Bathroom, Bedroom, Livingroom, Kitchen, Garden, Corridor, Toilets, Officeroom }

    public struct RoomSettings
    {
        //create one and only RoomSettings at the gameInitialization?                 

        public int MinSizeX;
        public int MinSizeY;
        public int MaxSizeX;
        public int MaxSizeY;
        public int MinDoorsAmount;
        public int MaxDoorsAmount;
        public char TypeKey;
        
        public RoomSettings(int minSizeX, int minSizeY, int maxSizeX, int maxSizeY, int minDoorsAmount, int maxDoorsAmount, char typeKey)
        {
            MinSizeX = minSizeX;
            MinSizeY = minSizeY;
            MaxSizeX = maxSizeX;
            MaxSizeY = maxSizeY;
            MinDoorsAmount = minDoorsAmount;
            MaxDoorsAmount = maxDoorsAmount;
            TypeKey = typeKey;
        }
    }
}

