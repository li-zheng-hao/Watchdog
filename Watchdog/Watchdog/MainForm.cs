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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadServiceConfig();
            GlobalLog.LogAdded += GlobalLog_LogAdded;
            Task.Run(() =>
            {
                BackgroundMonitorTask task = new BackgroundMonitorTask();
                task.Start();
            });
        }

        private void GlobalLog_LogAdded(object sender, string e)
        {
            if(GlobalLog.Logs.Count > 100)
            {
                GlobalLog.Logs.RemoveRange(0, 90);
            }
            // 使用 Invoke 确保在UI线程中更新控件
            if (this.textBox1.InvokeRequired)
            {
                this.textBox1.Invoke(new Action(() => {
                    this.textBox1.Text = string.Join("\r\n", GlobalLog.Logs);
                }));
            }
            else
            {
                this.textBox1.Text = string.Join("\r\n", GlobalLog.Logs);
            }
        }

        private void LoadServiceConfig()
        {
            this.listBox1.Items.Clear();
            foreach (var item in GlobalSetting.Current.Services)
            {
                this.listBox1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new SettingForm().ShowDialog();
        }
        /// <summary>
        /// 新增监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            new AddOrUpdateServiceSettingForm().ShowDialog();
            LoadServiceConfig();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var select = this.listBox1.SelectedItem as ServiceConfig;
            if (select != null)
            {
                new AddOrUpdateServiceSettingForm(select).ShowDialog();
                LoadServiceConfig();
            }
            else
            {
                MessageBox.Show("请选择要编辑的服务");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
             var select = this.listBox1.SelectedItem as ServiceConfig;
            if (select != null)
            {
                GlobalSetting.Current.Services.Remove(select);
                SettingHelper.SaveSettings();
                LoadServiceConfig();
            }
            else
            {
                MessageBox.Show("请选择要删除的服务");
            }
        }
    }
}
