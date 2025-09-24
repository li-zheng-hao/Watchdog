using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watchdog
{
    internal class SettingHelper
    {
        public static void SaveSettings()
        {
            var settingPath=AppDomain.CurrentDomain.BaseDirectory+"setting.json";
            var str=JsonConvert.SerializeObject(GlobalSetting.Current);
            File.WriteAllText(settingPath,str);
        }
        public static void LoadSettings()
        {
            var settingPath=AppDomain.CurrentDomain.BaseDirectory+"setting.json";
            if(File.Exists(settingPath))
            {
                var str=File.ReadAllText(settingPath);
                GlobalSetting.Current=JsonConvert.DeserializeObject<GlobalSetting>(str);
            }
        }
    }
}
