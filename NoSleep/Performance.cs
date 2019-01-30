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
        public int GetCpuUsage()
        {
            int cpuUsage = 0;
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuUsage = (int)cpuCounter.NextValue();
            return cpuUsage;
        }
    }
}
