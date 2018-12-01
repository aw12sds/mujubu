using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.工艺
{
    public partial class xiugaituhaohemingcheng1 : Form
    {
        public string id;
        public xiugaituhaohemingcheng1(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void xiugaituhaohemingcheng1_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_mujubu_lingjian where id='" + id + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.textEdit1.Text = dt.Rows[0]["图号"].ToString();
            this.textEdit2.Text = dt.Rows[0]["零件名称"].ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string tuhao = textEdit1.Text;
            string mingcheng = textEdit2.Text;
            string sql = "update tb_mujubu_lingjian set 图号='" + tuhao + "' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            this.Close();
        }
    }
}
