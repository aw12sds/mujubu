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
    public partial class erpauto : Form
    {
        public erpauto()
        {
            InitializeComponent();
        }

        private void erpauto_Load(object sender, EventArgs e)
        {
            string sql = "select MAX(编码) from tb_caigouliaodan where 料单类型 like '%模具部%' and Len(编码)='8'";
            string ERPMAX = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            string A = int.Parse(ERPMAX)+1+"";
            textBox1.Text = A;
        }
    }
}
