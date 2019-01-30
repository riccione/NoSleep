using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSleep
{
    class MessageHelper
    {
        private int counter = Properties.Settings.Default.Counter;

        public string GetMessage()
        {
            Performance p = new Performance;
            string cpu = Convert.ToString(p.GetCpuUsage());
            string time = CountUsageTime();
            string output = Program.prefix
                + time
                + " | " 
                + cpu;
            return output;
        }

        private string CountUsageTime()
        {
            int milliSecs = IterateCounter() * Program.interval;
            int hours = milliSecs / 3600000;
            int mins = (milliSecs % 3600000) / 60000;
            // Make sure you use the appropriate decimal separator
            string time = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", hours, mins, milliSecs % 60000 / 1000, milliSecs % 1000);
            return time;
        }

        private int IterateCounter()
        {
            counter++;
            Properties.Settings.Default.Counter = counter;
            return counter;
        }
    }
}
