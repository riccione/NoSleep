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
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            // The method nextValue() always returns a 0 value on the first call. So you have to call this method a second time.
            cpuCounter.NextValue();
            int cpuUsage = (int)cpuCounter.NextValue();
            return cpuUsage;
        }

        public int GetMemoryUsage()
        {
            var memoryCounter = new PerformanceCounter("Memory", "Available MBytes");
            return (int)memoryCounter.NextValue();
        }
    }
}
