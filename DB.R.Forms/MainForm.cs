using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB.R.Forms
{
    public partial class MainForm : Form
    {
        System.Timers.Timer t1 = new System.Timers.Timer(1000);
        public MainForm()
        {
            InitializeComponent();
        }


   
        private void MainForm_Load(object sender, EventArgs e)
        {
            t1.Elapsed += T1_Elapsed;
            t1.Enabled = true; //是否触发Elapsed事件
            t1.Start();
        }
        private void T1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            toolStripStatusLabel1.Text = "当前时间： " + System.DateTime.Now.ToString("yyyy-M-d dddd HH:mm:ss");
        }

        private void 数据源配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecForm  form1=new ExecForm();
            form1.Show();
        }
    }
}
