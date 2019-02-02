using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSleep
{
    class Performance
    {
        private const int SleepTime = 1000;

        public int GetCpuUsage()
        {
            // https://gavindraper.com/2011/03/01/retrieving-accurate-cpu-usage-in-c/
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            // To count correct CPU usage: take two measures and put a pause between them
            cpuCounter.NextValue();
            System.Threading.Thread.Sleep(SleepTime);
            int cpuUsage = (int)cpuCounter.NextValue();
            return cpuUsage;
        }

        public int GetMemoryUsage()
        {
            var memoryCounter = new PerformanceCounter("Memory", "Available MBytes");
            return (int)memoryCounter.NextValue();
        }

        public static int GetSleepTime()
        {
            return SleepTime;
        }
    }
}
