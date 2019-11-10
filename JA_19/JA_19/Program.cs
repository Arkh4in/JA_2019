using System;
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
            Console.SetWindowSize(Settings.BackgroundSize.Y * 2 + 1, Settings.BackgroundSize.X + 15);
            GameplayLoop gl = new GameplayLoop();
            gl.MainLoop();
        }
    }
}
