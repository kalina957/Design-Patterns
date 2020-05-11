using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyApplication
{
    class SCAN_Disk_Elevator : IStrategy
    {
        private bool left = true;
        private int last;
        private int index;

        public SCAN_Disk_Elevator()
        {
            throw new System.NotImplementedException();
        }

        public int GetProcessToBeRemoved(List<Process> processes)
        {
            List<int> listSorted= new List<int>();

            foreach (Process p in processes)
            {
                listSorted.Add(p.id);
            }


            listSorted.Sort();

            if (left)
            {
                while (listSorted[index] > last)
                {
                    index--;
                    if (index == -1)
                    {
                        index = 0;
                        left = true;
                        break;
                    }
                }
            }
            else
            {
                while (listSorted[index] < last)
                {
                    index++;
                    if (index >= listSorted.Count - 1)
                    {
                        left = false;
                        last = listSorted[index];
                        break;
                    }
                }
            }
            return listSorted[index];
        }
    }
}
