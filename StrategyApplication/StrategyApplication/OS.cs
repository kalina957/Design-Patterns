using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyApplication
{
    class OS
    {
        public int ProcessToBeRemoved { get; private set; }
        private IStrategy strategy { get; set; }

        public OS(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public OS()
        {
            throw new System.NotImplementedException();
        }

        public List<Process> ResetScheduling(List<Process> processes)
        {
            ProcessToBeRemoved = strategy.GetProcessToBeRemoved(processes);

            Random r = new Random();
            int randomId = r.Next(14, 45);
            int randomSeekTime = r.Next(10, 20);

            List<int> randomIds = new List<int>();

            Boolean rnd = false;

            foreach (Process p in processes)
            {
                randomIds.Add(p.id);
            }
            while (rnd == false)
            {
                if (randomIds.Contains(randomId))
                {
                    randomId = r.Next(14, 25);
                }
                else { rnd = true; }
            }

            foreach (Process p in processes)
            {
                if (p.id == ProcessToBeRemoved)
                {
                    processes.Remove(p);
                    break;
                }
            }

            processes.Add(new Process(randomId, randomSeekTime));
            return processes;
        }
    }
}
