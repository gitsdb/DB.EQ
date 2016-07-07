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
    public partial class ExecForm : Form
    {
        public ExecForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = DB.R.Core.DataConnectionUITool.SetConnenctUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          bool isOK=  DB.R.Core.DataConnectionUITool.ConnectionTest(textBox1.Text);
            if (isOK) MessageBox.Show("链接成功！");
        }
    }
}
