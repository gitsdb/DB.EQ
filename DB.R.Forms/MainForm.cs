using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB.R.Forms
{
    public partial class MainForm : Form
    {
        System.Threading.Timer _t1 ;

        private delegate void SetTextCallback();


        public MainForm()
        {
            InitializeComponent();
        }


   
        private void MainForm_Load(object sender, EventArgs e)
        {
              this._t1=new System.Threading.Timer(new TimerCallback(T1_Elapsed),null,0,1000);
            _t1.Change(0, 1000);

            tabControl1.TabPages.Clear();
        }

        private void SetTimeText()
        {
           // toolStripStatusLabel1.Text = $"当前时间： {System.DateTime.Now.ToString("yyyy-M-d dddd HH:mm:ss")}";
            if (this.menuStrip1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTimeText);
                this.Invoke(d, null);
            }
            else
            {
                toolStripStatusLabel1.Text = $"当前时间： {System.DateTime.Now.ToString("yyyy-M-d dddd HH:mm:ss")}";
              //  this.textBox1.Text = text;
            }

        }
        private void T1_Elapsed(object sender)
        {
            //  this.SetTimeText();
            var thread = new Thread(new ThreadStart(SetTimeText));
            thread.Start();
        }

        private void 数据源配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecForm  form1=new ExecForm();
            form1.Show();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tn = e.Node; //点击的节点
         
                switch (tn.Text)
                {
                case "系统配置":
                    ExecForm form1 = new ExecForm();
                        form1.TopLevel = false;
                        TabPage tabPage = new TabPage();
                    tabPage.Name = tn.Text;
                    tabPage.Text= tn.Text;
                    //把form1添加到tabPage中
                    tabPage.Controls.Add(form1);
                    form1.Show();
                    //添加选项卡tabPage到TabControl中
                    tabControl1.TabPages.Add(tabPage);
                    break;
                }

        }

        #region 用户操作名称显示
        

        #endregion


    }
}
