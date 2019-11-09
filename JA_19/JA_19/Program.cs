﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_19
{
    class Program
    {
        //Prop & Constructors//
        static void Main(string[] args)
        {
            Layout background = Layout.EmptyLayout(new Vector2(32, 32));
            Room room = new Room(3, new Vector2(0, 0), new Vector2(3, 8));

            DisplayHelper.DisplayGameState(background, room);
        }
    }
}
