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
            // https://gavindraper.com/2011/03/01/retrieving-accurate-cpu-usage-in-c/
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", "MyComputer");
            cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            return (int)cpuCounter.NextValue();
        }
    }
}
