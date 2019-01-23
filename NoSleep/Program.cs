using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WindowsInput;
using WindowsInput.Native;

namespace NoSleep
{
    class Program
    {

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
            int interval = 59000;
            Timer timer = new Timer();
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
        }
    }
}
