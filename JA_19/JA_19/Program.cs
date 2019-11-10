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
            InitWindow();
            GameplayLoop gl = new GameplayLoop();
            gl.MainLoop();
        }

        private static void InitWindow()
        {
            Console.SetWindowSize(Settings.BackgroundSize.Y * 2 + 1, Settings.BackgroundSize.X + 15);

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                ");
            Console.WriteLine("         __  __   ___   ___  ___   ___  ___   _    ___  ___     ");
            Console.WriteLine("        |  \\/  | / _ \\ | _ \\| __| / __|| _ \\ /_\\  / __|| __|    ");
            Console.WriteLine("        | |\\/| || (_) ||   /| _|  \\__ \\|  _// _ \\| (__ | _|     ");
            Console.WriteLine("        |_|  |_| \\___/ |_|_\\|___| |___/|_| /_/ \\_\\\\___||___|    ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                                                ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                ");
        }
    }
}
