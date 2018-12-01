using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mujubu.客户
{
    public partial class addclient : Form
    {
        public addclient()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "insert into tb_client(name)values('" + tbName.Text + "')";
            string rs = Convert.ToString(SQLhelp.ExecuteNonquery2(sql, CommandType.Text));

            if (rs != "")
            {
                MessageBox.Show("插入成功！");
                this.Close();
                this.DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("插入失败！");
            }
        }
    }
}
