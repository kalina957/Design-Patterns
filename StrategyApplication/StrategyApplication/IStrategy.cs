using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyApplication
{
    interface IStrategy
    {
        int GetProcessToBeRemoved(List<Process> numbers);
    }
}
