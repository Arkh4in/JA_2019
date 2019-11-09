using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    public class DisplayHelper
    {
        public void Test()
        {
            char[,] cArray = new char[32, 32];
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    cArray[i, j] = 'b';
                }
            }

            char[,] cArray2 = new char[10, 8]
            {
                {'g', 'g', 'c', 'g', 'g', 'g', 'g', 'g' },
                {'g', 'f', 'f', 'f', 'f', 'f', 'f', 'g' },
                {'g', 'f', 'f', 'a', 'f', 'f', 'f', 'g' },
                {'c', 'f', 'f', 'a', 'f', 'f', 'f', 'g' },
                {'g', 'f', 'f', 'a', 'f', 'f', 'f', 'g' },
                {'g', 'f', 'f', 'a', 'f', 'f', 'f', 'c' },
                {'g', 'f', 'f', 'a', 'f', 'f', 'f', 'g' },
                {'g', 'f', 'f', 'a', 'f', 'f', 'f', 'g' },
                {'g', 'f', 'f', 'f', 'f', 'f', 'f', 'g' },
                {'g', 'g', 'g', 'g', 'c', 'g', 'g', 'g' }
            };

            char[,] cArray3 = new char[5, 5]
            {
                {'g', 'g', 'c', 'g', 'g' },
                {'g', 'f', 'f', 'f', 'g' },
                {'g', 'f', 'f', 'f', 'c' },
                {'g', 'f', 'f', 'f', 'g' },
                {'g', 'g', 'g', 'c', 'g' }
            };

            MergeLayouts(cArray, cArray2, 10, 10, 10, 8);
            MergeLayouts(cArray, cArray3, 20, 20, 5, 5);

            MergeLayouts(cArray, cArray2, 20, 0, 10, 8);
            MergeLayouts(cArray, cArray3, 0, 20, 5, 5);


            Console.SetWindowSize(33, 33);

            var v = DateTime.Now;

            for (int c = 0; c < 100; c++)
            {
                Console.SetCursorPosition(0, 0);
                int currentColor = cArray[0, 0];
                Console.BackgroundColor = (ConsoleColor)(currentColor - 97);
                for (int i = 0; i < 32; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        if (currentColor != cArray[i, j])
                        {
                            currentColor = cArray[i, j];
                            Console.BackgroundColor = (ConsoleColor)(currentColor - 97);
                        }
                        Console.Write(" ");
                    }
                    Console.Write("\n");
                }
            }
            var delta = (DateTime.Now - v).TotalMilliseconds;
        }

        public void MergeLayouts(char[,] bg, char[,] room, int pX, int pY, int sX, int sY)
        {
            for (int i = 0; i < sX; i++)
            {
                for (int j = 0; j < sY; j++)
                {
                    if (room[i, j] != 'a')
                    {
                        bg[pX + i, pY + j] = room[i, j];
                    }
                }
            }
        }
    }
}
