using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyApplication
{
    class SSTF : IStrategy
    {
        public SSTF()
        {
            throw new System.NotImplementedException();
        }

        public int GetProcessToBeRemoved(List<Process> processes)
        {
            List<int> seekTimes = new List<int>();
            foreach (Process p in processes)
            {
                seekTimes.Add(p.seekTime);
            }

            Process min = processes[0];
            foreach (Process p in processes)
            {
                if (p.seekTime < min.seekTime)
                {
                    min = p;
                }
            }
            return min.id;
        }
    }
}
