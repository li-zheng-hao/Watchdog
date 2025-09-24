using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog
{
    public class ServiceConfig
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString("N");
        public string ExePath { get; set; }
        public string ProcessName { get; set; }
        public string Arguments { get; set; }

        public override string ToString()
        {
            return ProcessName;
        }
    }
}
