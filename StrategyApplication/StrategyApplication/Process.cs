using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyApplication
{
    class Process
    {
        public int id { get; set; }
        public int seekTime { get; set; }

        public Process(int id, int seekTime){
          this.id = id;
          this.seekTime = seekTime;
        }
    }
}