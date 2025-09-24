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
    public partial class AddOrUpdateServiceSettingForm : Form
    {
        ServiceConfig _config;
        bool _isUpdate = false;
        public AddOrUpdateServiceSettingForm()
        {
            InitializeComponent();
            _config=new ServiceConfig();
        }
        public AddOrUpdateServiceSettingForm(ServiceConfig config)
        {
            InitializeComponent();
            _config = config;
            _isUpdate = true;
            this.textBox1.Text = config.ExePath;
            this.textBox2.Text = config.Arguments;
            this.textBox3.Text = config.ProcessName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _config.ExePath = this.textBox1.Text;
            _config.Arguments = this.textBox2.Text;
            _config.ProcessName = this.textBox3.Text;
            if (_isUpdate)
            {
                SettingHelper.SaveSettings();
                MessageBox.Show("修改成功");
                this.Close();
                return;
            }
            else
            {
                GlobalSetting.Current.Services.Add(_config);
                SettingHelper.SaveSettings();
                MessageBox.Show("添加成功");
            }
            this.Close();
        }
    }
}
