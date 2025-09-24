using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog
{
    public static class GlobalLog
    {
        public static List<string> Logs = new List<string>();

        public static event EventHandler<string> LogAdded;

        public static void AddLog(string log)
        {
            Logs.Add($"{DateTime.Now:yyyy:MM:dd HH:mm:ss}-{log}");
            LogAdded?.Invoke(null, log);
        }
    }
}
