using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    class RandomDoorCoordinates
    {
        public int randomX { get; set; }

        public int randomY { get; set; }

        public RandomDoorCoordinates(int sizeX, int sizeY)
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
            randomX = randomVector.X;
            randomY = randomVector.Y;
        }
    }
}
