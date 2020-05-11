using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyApplication
{
    class FCFS :IStrategy
    {
        public FCFS()
        {
            throw new System.NotImplementedException();
        }

        public int GetProcessToBeRemoved(List<Process> processes)
        {
            List<int> ids = new List<int>();
            foreach(Process p in processes)
            {
                ids.Add(p.id);
            }

            if (processes.Count != 0)
            {
                return ids[0];
            }
            return 0;
        }
    }
}
