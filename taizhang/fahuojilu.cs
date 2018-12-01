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
    public partial class fahuojilu : Form
    {
        public string 定位;
        public fahuojilu(string id)
        {
            InitializeComponent();
            this.定位 = id;
        }

        private void fahuojilu_Load(object sender, EventArgs e)
        {
            string Sql1 = "select id,定位,部门,发货数量,发货时间 from tb_fahuojilu where 定位='" + 定位 + "'";
            DataTable dt2 = SQLhelp.GetDataTable(Sql1, CommandType.Text);
            gridControl1.DataSource = dt2;
        }
    }
}
