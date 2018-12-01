using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.taizhang
{
    public partial class 无图纸退回 : Form
    {
        public string id;
        public 无图纸退回(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql2 = "update tb_caigouliaodan  set 备注='" + textBox1.Text + "',当前状态='57' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
