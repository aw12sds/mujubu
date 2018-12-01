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
    public partial class updateclient : Form
    {
        public string id;
        public string name;
        public updateclient(string id,string name)
        {
            InitializeComponent();
            this.id = id;
            this.name = name;
        }

        private void updateclient_Load(object sender, EventArgs e)
        {
            tbUpdate.Text = name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "update tb_client set name ='" + tbUpdate.Text + "' where id = '" + id + "'";
            string rs = Convert.ToString(SQLhelp.ExecuteNonquery2(sql, CommandType.Text));
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
