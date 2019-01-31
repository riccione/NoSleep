using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using WindowsInput;
using WindowsInput.Native;

namespace NoSleep
{
    class Program
    {
        private int counter = Properties.Settings.Default.Counter;
        // time Interval in milliseconds
        public const int Interval = 59000;
        public const string Prefix = "kami@kalypso:~$";

        static void Main(string[] args)
        {
            InitTimer();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string str = Prefix + "NoSleep started";
            Console.WriteLine(str);

            // Doesn't close the console with F15
            while (Console.ReadKey(true).Key == ConsoleKey.F15)
            {
                Console.Read();
            }
        }

        private static void InitTimer()
        {
            /*
             *  Perform KeyPress method every Interval
             */
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(KeyPress);
            timer.Interval = Interval;
            timer.Enabled = true;
            //timer.AutoReset = true;
        }

        private static void KeyPress(Object source, ElapsedEventArgs e)
        {
            /*  
             *  Simulate key down (F15) using InputSimulator library from 
             *  NuGet packages
             */
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.KeyPress(VirtualKeyCode.F15);
            MessageHelper mh = new MessageHelper();
            RunningBackgroundThread();
        }

        private static void MessageToConsole()
        {
            MessageHelper mh = new MessageHelper();
            mh.GetMessage();
        }

        private static void RunningBackgroundThread()
        {
            Thread backgroundThread = new Thread(MessageToConsole)
            {
                IsBackground = true
            };
            backgroundThread.Start();
        }
    }
}
