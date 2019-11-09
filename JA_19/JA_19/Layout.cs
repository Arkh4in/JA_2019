using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class Layout
    {
        // Prop & Constructors //
        public List<Vector2> DoorCoordinatesList { get; private set; }

        public char[,] LayoutArray { get; private set;  }

        public Layout(int sizeX, int sizeY, int doorAmount)
        {
            DoorCoordinatesList = new List<Vector2>();
            for(int i = 0; i < doorAmount; i++)
            {
                //TODO : set the coordinates
                RandomDoorCoordinates randomCoordinates = new RandomDoorCoordinates(sizeX, sizeY);
                DoorCoordinatesList.Add(new Vector2(randomCoordinates.randomX, randomCoordinates.randomY));
            }

            char[,] cArray = new char[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    cArray[i, j] = 'a';
                }
            }

            LayoutArray = cArray;
        }

        // Display //
        //TODO : to remove, use display helper
        public void Display()
        {
            foreach (char c in LayoutArray)
            {
                Console.WriteLine(c);
            }
        }
    }
}
