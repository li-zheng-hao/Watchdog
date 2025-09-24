using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog
{
    public class GlobalSetting
    {
        public static GlobalSetting Current { get; set; } = new GlobalSetting();   
        public bool IsAutoStartup { get; set; } = false;

        /// <summary>
        /// 检查间隔
        /// </summary>
        public int CheckInterval { get; set; } = 15;

        /// <summary>
        /// 服务列表
        /// </summary>
        public List<ServiceConfig> Services { get; set; } = new List<ServiceConfig>();
    }
}
