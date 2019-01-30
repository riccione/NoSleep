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
        // time interval in milliseconds
        public const int interval = 59000;

        static void Main(string[] args)
        {
            InitTimer();
            Console.WriteLine("NoSleep started");

            // Doesn't close the console with F15
            while (Console.ReadKey(true).Key == ConsoleKey.F15)
            {
                Console.Read();
            }
        }

        private static void InitTimer()
        {
            /*
             *  Perform KeyPress method every interval
             */
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(KeyPress);
            timer.Interval = interval;
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
            string msg = mh.GetMessage();
            Console.WriteLine(msg);
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
