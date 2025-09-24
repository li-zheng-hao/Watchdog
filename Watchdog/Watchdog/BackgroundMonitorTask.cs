using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Watchdog
{
    internal class BackgroundMonitorTask
    {

        public void Start()
        {
            while (true)
            {
                try
                {
                    foreach (var service in GlobalSetting.Current.Services)
                    {
                        var process = Process.GetProcessesByName(service.ProcessName);
                        if (process.Length == 0)
                        {
                            GlobalLog.AddLog("启动程序" + service.ProcessName);
                            try
                            {
                                Process.Start(service.ExePath);
                            }catch(Exception ex)
                            {
                                GlobalLog.AddLog("启动失败" + ex.Message);
                            }
                        }
                    }
                    GlobalLog.AddLog($"检查完成,休眠{GlobalSetting.Current.CheckInterval}秒");
                }
                catch(Exception ex)
                {
                    // 记录异常日志或处理异常
                    GlobalLog.AddLog("监控异常"+ex.Message);
                }
                finally
                {
                    Thread.Sleep(GlobalSetting.Current.CheckInterval * 1000);
                }

            }
        }

       
    }
}
