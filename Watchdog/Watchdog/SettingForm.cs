using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watchdog
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            this.checkBox1.Checked = GlobalSetting.Current.IsAutoStartup;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                GlobalSetting.Current.IsAutoStartup = true;
            }
            else
            {
                GlobalSetting.Current.IsAutoStartup = false;
            }

            SetStartup(this.checkBox1.Checked);
            MessageBox.Show("设置成功");
            SettingHelper.SaveSettings();
        }


        private void SetStartup(bool isAutoStartup)
        {
            try
            {
                // 获取当前应用程序的启动路径
                string exePath = Application.ExecutablePath;
                // 注册表启动项路径
                string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(registryKey, true))
                {
                    if (isAutoStartup)
                    {
                        // 设置开机自启动
                        key.SetValue("Watchdog", exePath);
                    }
                    else
                    {
                        // 移除开机自启动
                        key.DeleteValue("Watchdog", false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置开机自启动失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
