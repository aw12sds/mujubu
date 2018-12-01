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
    public partial class shaixuan : Form
    {
        public shaixuan()
        {
            InitializeComponent();
        }
        public String gonglinghao;
        private void button1_Click(object sender, EventArgs e)
        {
           gonglinghao = textBox1.Text.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
