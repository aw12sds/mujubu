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
    public partial class caigouerpshengpi : Form
    {
        public caigouerpshengpi(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        public string id;
        private void button1_Click(object sender, EventArgs e)
        {
            String sql = "update tb_caigouliaodan  set 模具部状态='4',模具部erp='"+ textBox1.Text+" where id ='" + id + "'";
            SQLhelp.ExecuteNonquery2(sql, CommandType.Text);
        }
    }
}
